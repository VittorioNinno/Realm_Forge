using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.DTOs;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	The account's images: pictures for tokens, monsters and NPCs. The file of an image is served to anyone who has its
	///	id (an unguessable link, as for the tokens seen by the whole table), cached for good: an image never changes.
	///	</summary>
	[ApiController]
	[Route("api/images")]
	[Authorize]
	public class ImagesController : ControllerBase
	{
		private static readonly string[] Types = { "image/jpeg", "image/png", "image/webp" };

		private readonly RealmForgeDbContext _context;

		public ImagesController(RealmForgeDbContext context)
		{
			_context = context;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/images
		[HttpGet]
		public async Task<ActionResult<List<UserImageDto>>> GetImages()
		{
			var images = await _context.UserImages.AsNoTracking().Where(i => i.OwnerId == UserId).OrderByDescending(i => i.CreatedAt)
				.Select(i => new { i.Id, i.Name, i.Width, i.Height, i.CreatedAt }).ToListAsync();
			var choices = await _context.MonsterImageChoices.AsNoTracking().Where(c => c.OwnerId == UserId).ToListAsync();
			return Ok(images.Select(i => new UserImageDto(i.Id, i.Name, i.Width, i.Height, i.CreatedAt,
				choices.Where(c => c.ImageId == i.Id).Select(c => c.MonsterId).ToList())).ToList());
		}

		//	POST: api/images
		[HttpPost]
		public async Task<ActionResult<UserImageDto>> AddImage([FromBody] SaveImageDto dto)
		{
			if (Invalid(dto, needsImage: true) is { } error)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}
			if (await _context.UserImages.CountAsync(i => i.OwnerId == UserId) >= UserImage.MaxPerAccount)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {UserImage.MaxPerAccount} images.");
			}
			var image = new UserImage { OwnerId = UserId, Name = dto.Name.Trim(), Image = dto.Image!, Width = dto.Width, Height = dto.Height };
			_context.UserImages.Add(image);
			await _context.SaveChangesAsync();
			return Ok(new UserImageDto(image.Id, image.Name, image.Width, image.Height, image.CreatedAt, new()));
		}

		//	PUT: api/images/{id} — the name
		[HttpPut("{id:guid}")]
		public async Task<IActionResult> RenameImage(Guid id, [FromBody] SaveImageDto dto)
		{
			var image = await _context.UserImages.FirstOrDefaultAsync(i => i.Id == id && i.OwnerId == UserId);
			if (image is null)
			{
				return NotFound();
			}
			if (Invalid(dto, needsImage: false) is { } error)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}
			image.Name = dto.Name.Trim();
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/images/{id} — the monsters it pictured go back to their own portrait; the tokens to their initials
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteImage(Guid id)
		{
			var image = await _context.UserImages.FirstOrDefaultAsync(i => i.Id == id && i.OwnerId == UserId);
			if (image is null)
			{
				return NotFound();
			}
			await _context.CampaignTokens.Where(t => t.ImageId == id).ExecuteUpdateAsync(s => s.SetProperty(t => t.ImageId, (Guid?)null));
			_context.UserImages.Remove(image);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	GET: api/images/{id}/file — the picture itself
		[HttpGet("{id:guid}/file")]
		[AllowAnonymous]
		public async Task<IActionResult> GetFile(Guid id)
		{
			var data = await _context.UserImages.AsNoTracking().Where(i => i.Id == id).Select(i => i.Image).FirstOrDefaultAsync();
			if (data is null || !TryDecode(data, out var type, out var bytes))
			{
				return NotFound();
			}
			Response.Headers.CacheControl = "public, max-age=31536000, immutable";
			return File(bytes, type);
		}

		//	GET: api/images/monsters — monster id → image id, the account's choices
		[HttpGet("monsters")]
		public async Task<ActionResult<Dictionary<Guid, Guid>>> GetChoices() =>
			Ok(await _context.MonsterImageChoices.AsNoTracking().Where(c => c.OwnerId == UserId).ToDictionaryAsync(c => c.MonsterId, c => c.ImageId));

		//	PUT: api/images/monsters/{monsterId} — the picture of a monster or an NPC, for the account
		[HttpPut("monsters/{monsterId:guid}")]
		public async Task<IActionResult> Choose(Guid monsterId, [FromBody] ChooseImageDto dto)
		{
			if (!await _context.Monsters.AnyAsync(m => m.Id == monsterId))
			{
				return NotFound();
			}
			var choice = await _context.MonsterImageChoices.FirstOrDefaultAsync(c => c.OwnerId == UserId && c.MonsterId == monsterId);
			if (dto.ImageId is not { } imageId)
			{
				if (choice is not null)
				{
					_context.MonsterImageChoices.Remove(choice);
				}
			}
			else
			{
				if (!await _context.UserImages.AnyAsync(i => i.Id == imageId && i.OwnerId == UserId))
				{
					return NotFound();
				}
				if (choice is null)
				{
					_context.MonsterImageChoices.Add(new MonsterImageChoice { OwnerId = UserId, MonsterId = monsterId, ImageId = imageId });
				}
				else
				{
					choice.ImageId = imageId;
				}
			}
			await _context.SaveChangesAsync();
			return NoContent();
		}

		private static string? Invalid(SaveImageDto dto, bool needsImage)
		{
			if (string.IsNullOrWhiteSpace(dto.Name) || dto.Name.Trim().Length > 100)
			{
				return "A name of at most 100 characters is required.";
			}
			if (!needsImage)
			{
				return null;
			}
			if (dto.Image is null || dto.Image.Length > UserImage.MaxImageLength || !TryDecode(dto.Image, out _, out _))
			{
				return "A JPEG, PNG or WebP picture of at most 300 KB is required.";
			}
			return dto.Width is < 1 or > 4096 || dto.Height is < 1 or > 4096 ? "Width and height out of range." : null;
		}

		//	"data:image/jpeg;base64,…" → its type and bytes
		private static bool TryDecode(string data, out string type, out byte[] bytes)
		{
			type = string.Empty;
			bytes = Array.Empty<byte>();
			var comma = data.IndexOf(',');
			if (!data.StartsWith("data:", StringComparison.Ordinal) || comma < 0 || !data[..comma].EndsWith(";base64", StringComparison.Ordinal))
			{
				return false;
			}
			type = data[5..data.IndexOf(';')];
			if (!Types.Contains(type))
			{
				return false;
			}
			try
			{
				bytes = Convert.FromBase64String(data[(comma + 1)..]);
				return bytes.Length > 0;
			}
			catch (FormatException)
			{
				return false;
			}
		}
	}
}
