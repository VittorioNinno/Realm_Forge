using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Localization;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Infrastructure.Persistence.Trash;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Homebrew subclasses: detail (for editing and share links), create, update and delete. A Homebrew subclass can extend
	///	a Base class or one of the author's own Homebrew classes, as lineages do for species.
	///	</summary>
	[ApiController]
	[Route("api/[controller]")]
	public class SubclassesController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;
		private readonly ShareService _shares;

		public SubclassesController(RealmForgeDbContext context, ContentAccess access, ShareService shares)
		{
			_context = context;
			_access = access;
			_shares = shares;
		}

		//	GET: api/subclasses/{id}?lang=2
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<SubclassResponseDto>> GetSubclass(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var subclass = await _context.Subclasses
				.AsNoTracking()
				.Include(s => s.Translations)
				.Include(s => s.Features).ThenInclude(f => f.Translations)
				.Include(s => s.CharacterClass).ThenInclude(c => c.Translations)
				.AsSplitQuery()
				.FirstOrDefaultAsync(s => s.Id == id);

			if (subclass == null || !_access.CanView(subclass, User, await _shares.SharedWithAsync(User)))
			{
				return NotFound();
			}

			var className = subclass.CharacterClass.Translations.Localize(lang)?.Name ?? "Unknown";
			return Ok(ClassesController.ToSubclassDto(subclass, className, lang, _access.CanModify(subclass, User)));
		}

		//	POST: api/subclasses
		[HttpPost]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<IActionResult> CreateSubclass([FromBody] SaveSubclassDto dto)
		{
			var error = Validate(dto);
			if (error != null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var parent = await _context.Classes.FindAsync(dto.ClassId);
			if (parent == null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Parent class not found.");
			}

			//	Subclasses can extend Base classes or the user's own Homebrew classes, not other users' content
			if (!parent.IsOfficialSRD && !_access.CanModify(parent, User))
			{
				return Problem(statusCode: StatusCodes.Status403Forbidden, title: "You can only add subclasses to Base classes or to your own Homebrew classes.");
			}

			var authorId = ContentAccess.GetUserId(User);
			var subclass = new Subclass
			{
				CharacterClassId = parent.Id,
				Ruleset = parent.Ruleset,
				IsOfficialSRD = false,
				AuthorId = authorId,
				Visibility = dto.Visibility,
				CasterProgression = dto.CasterProgression,
				SpellcastingAbility = dto.CasterProgression == CasterProgression.None ? null : dto.SpellcastingAbility,
				Translations = dto.Translations.Select(t => new SubclassTranslation
				{
					Language = t.Language,
					Name = t.Name.Trim(),
					Description = t.Description?.Trim() ?? string.Empty
				}).ToList(),
				Features = ClassesController.BuildFeatures(dto.Features, parent.Ruleset, authorId, dto.Visibility)
			};

			_context.Subclasses.Add(subclass);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetSubclass), new { id = subclass.Id }, new { subclass.Id });
		}

		//	PUT: api/subclasses/{id}
		[HttpPut("{id:guid}")]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<IActionResult> UpdateSubclass(Guid id, [FromBody] SaveSubclassDto dto)
		{
			if (id != dto.Id)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "ID mismatch between route and payload.");
			}

			var error = Validate(dto);
			if (error != null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var subclass = await _context.Subclasses
				.Include(s => s.Translations)
				.Include(s => s.Features)
				.AsSplitQuery()
				.FirstOrDefaultAsync(s => s.Id == id);

			if (subclass == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, subclass);
			if (denied != null)
			{
				return denied;
			}

			//	The parent class cannot change: a subclass is written for its class
			subclass.Visibility = dto.Visibility;
			subclass.CasterProgression = dto.CasterProgression;
			subclass.SpellcastingAbility = dto.CasterProgression == CasterProgression.None ? null : dto.SpellcastingAbility;

			var dtoLanguages = dto.Translations.Select(t => t.Language).ToHashSet();
			foreach (var stale in subclass.Translations.Where(t => !dtoLanguages.Contains(t.Language)).ToList())
			{
				subclass.Translations.Remove(stale);
			}

			foreach (var tDto in dto.Translations)
			{
				var existing = subclass.Translations.FirstOrDefault(t => t.Language == tDto.Language);

				if (existing != null)
				{
					existing.Name = tDto.Name.Trim();
					existing.Description = tDto.Description?.Trim() ?? string.Empty;
				}
				else
				{
					_context.SubclassTranslations.Add(new SubclassTranslation
					{
						SubclassId = subclass.Id,
						Language = tDto.Language,
						Name = tDto.Name.Trim(),
						Description = tDto.Description?.Trim() ?? string.Empty
					});
				}
			}

			_context.ClassFeatures.RemoveRange(subclass.Features);
			foreach (var feature in ClassesController.BuildFeatures(dto.Features, subclass.Ruleset, subclass.AuthorId, dto.Visibility))
			{
				feature.SubclassId = subclass.Id;
				_context.ClassFeatures.Add(feature);
			}

			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/subclasses/{id}
		[HttpDelete("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> DeleteSubclass(Guid id, [FromServices] TrashBin bin)
		{
			var subclass = await _context.Subclasses.Include(s => s.Features).FirstOrDefaultAsync(s => s.Id == id);

			if (subclass == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, subclass);
			if (denied != null)
			{
				return denied;
			}

			//	Kept in the bin for a few days, to be restored
			await bin.AddAsync(subclass, "subclass", ContentAccess.GetUserId(User) ?? string.Empty, subclass.Id);
			_context.ClassFeatures.RemoveRange(subclass.Features);
			_context.Subclasses.Remove(subclass);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		private static string? Validate(SaveSubclassDto dto)
		{
			if (dto.Translations.Count == 0 || dto.Translations.Any(t => string.IsNullOrWhiteSpace(t.Name)))
			{
				return "Every translation must have a name.";
			}

			if (dto.Translations.GroupBy(t => t.Language).Any(g => g.Count() > 1))
			{
				return "Only one translation per language is allowed.";
			}

			if (!Enum.IsDefined(dto.CasterProgression) || (dto.SpellcastingAbility is { } ability && !Enum.IsDefined(ability)))
			{
				return "Unknown caster progression or ability.";
			}

			if (dto.CasterProgression != CasterProgression.None && dto.SpellcastingAbility is null)
			{
				return "A spellcasting subclass needs a spellcasting ability.";
			}

			if (dto.Translations.Any(t => t.Name.Length > 150 || (t.Description?.Length ?? 0) > ClassesController.MaxTextLength))
			{
				return "A text is too long.";
			}

			return ClassesController.ValidateFeatures(dto.Features);
		}
	}
}
