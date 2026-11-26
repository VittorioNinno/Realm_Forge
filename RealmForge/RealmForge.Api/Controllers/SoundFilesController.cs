using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	The audio files uploaded for the soundboards, played by the browsers at the table: an audio element sends no
	///	token, so a file is read by its id alone (random, known only to the campaign), with ranges for seeking.
	///	</summary>
	[ApiController]
	[Route("api/sound-files")]
	public class SoundFilesController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;

		public SoundFilesController(RealmForgeDbContext context)
		{
			_context = context;
		}

		//	GET: api/sound-files/{id}
		[HttpGet("{id:guid}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetFile(Guid id)
		{
			var file = await _context.CampaignSoundFiles.AsNoTracking().Where(f => f.Id == id).Select(f => new { f.ContentType, f.Data }).FirstOrDefaultAsync();
			if (file is null)
			{
				return NotFound();
			}
			//	A file never changes (a new upload is a new id)
			Response.Headers.CacheControl = "public, max-age=31536000, immutable";
			return File(file.Data, file.ContentType, enableRangeProcessing: true);
		}
	}
}
