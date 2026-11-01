using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Localization;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Infrastructure.Persistence.Trash;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Text;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Homebrew rule modules: house rules written as data (RuleEffect) that the characters choose and the campaigns
	///	share. Same rules as the other Homebrew: the author (or an administrator) changes them, the visibility and the
	///	shares decide who reads them; deleted ones go to the bin.
	///	</summary>
	[ApiController]
	[Route("api/modules")]
	public class RuleModulesController : ControllerBase
	{
		public const int MaxModulesPerUser = 50;
		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;
		private readonly ShareService _shares;

		public RuleModulesController(RealmForgeDbContext context, ContentAccess access, ShareService shares)
		{
			_context = context;
			_access = access;
			_shares = shares;
		}

		//	GET: api/modules?lang=2
		[HttpGet]
		public async Task<ActionResult<List<RuleModuleResponseDto>>> GetModules([FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var query = ContentAccess.ListedFor(_context.RuleModules.AsNoTracking().Include(m => m.Translations), User, await _shares.SharedWithAsync(User));
			var modules = await query.ToListAsync();
			var names = await PublicNames.LoadAsync(_context, modules.Select(m => m.AuthorId));
			return Ok(modules.Select(m =>
			{
				var tr = m.Translations.Localize(lang);
				return new RuleModuleResponseDto(m.Id, tr?.Name ?? "?", MarkdownPreview.ToPlainText(tr?.Description, 160), m.Ruleset,
					Read(m.Effects).Select(e => e.Kind).Distinct().ToList(), _access.CanModify(m, User), m.Visibility,
					m.AuthorId is null ? null : names.GetValueOrDefault(m.AuthorId));
			}).OrderBy(m => m.Name, StringComparer.CurrentCultureIgnoreCase).ToList());
		}

		//	GET: api/modules/{id}?lang=2
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<RuleModuleDetailDto>> GetModule(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var module = await _context.RuleModules.AsNoTracking().Include(m => m.Translations).FirstOrDefaultAsync(m => m.Id == id);
			if (module is null || !_access.CanView(module, User, await _shares.SharedWithAsync(User)))
			{
				return NotFound();
			}
			var names = await PublicNames.LoadAsync(_context, new[] { module.AuthorId });
			return Ok(ToDetail(module, lang, names));
		}

		//	POST: api/modules
		[HttpPost]
		[Authorize]
		[RequireConfirmedEmail]
		public async Task<ActionResult<RuleModuleDetailDto>> CreateModule([FromBody] SaveRuleModuleDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (Validate(dto) is { } error)
			{
				return error;
			}
			var userId = ContentAccess.GetUserId(User);
			if (await _context.RuleModules.CountAsync(m => m.AuthorId == userId) >= MaxModulesPerUser)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxModulesPerUser} rule modules per account.");
			}
			var module = new RuleModule
			{
				Ruleset = dto.Ruleset,
				IsOfficialSRD = false,
				AuthorId = userId,
				Visibility = dto.Visibility,
				Effects = RuleEffectJson.Write(dto.Effects),
				Translations = dto.Translations.Select(t => new RuleModuleTranslation
				{
					Language = t.Language,
					Name = t.Name.Trim(),
					Description = t.Description?.Trim() ?? string.Empty
				}).ToList()
			};
			_context.RuleModules.Add(module);
			await _context.SaveChangesAsync();
			var names = await PublicNames.LoadAsync(_context, new[] { userId });
			return CreatedAtAction(nameof(GetModule), new { id = module.Id }, ToDetail(module, lang, names));
		}

		//	PUT: api/modules/{id}
		[HttpPut("{id:guid}")]
		[Authorize]
		[RequireConfirmedEmail]
		public async Task<IActionResult> UpdateModule(Guid id, [FromBody] SaveRuleModuleDto dto)
		{
			if (Validate(dto) is { } error)
			{
				return error;
			}
			var module = await _context.RuleModules.Include(m => m.Translations).FirstOrDefaultAsync(m => m.Id == id);
			if (module is null)
			{
				return NotFound();
			}
			if (this.EnsureCanModify(_access, module) is { } denied)
			{
				return denied;
			}
			module.Ruleset = dto.Ruleset;
			module.Visibility = dto.Visibility;
			module.Effects = RuleEffectJson.Write(dto.Effects);
			module.UpdatedAt = DateTimeOffset.UtcNow;

			var languages = dto.Translations.Select(t => t.Language).ToHashSet();
			foreach (var tr in module.Translations.Where(t => !languages.Contains(t.Language)).ToList())
			{
				module.Translations.Remove(tr);
			}
			foreach (var t in dto.Translations)
			{
				if (module.Translations.FirstOrDefault(x => x.Language == t.Language) is { } existing)
				{
					existing.Name = t.Name.Trim();
					existing.Description = t.Description?.Trim() ?? string.Empty;
				}
				else
				{
					_context.RuleModuleTranslations.Add(new RuleModuleTranslation
					{
						RuleModuleId = module.Id,
						Language = t.Language,
						Name = t.Name.Trim(),
						Description = t.Description?.Trim() ?? string.Empty
					});
				}
			}
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/modules/{id} — to the bin
		[HttpDelete("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> DeleteModule(Guid id, [FromServices] TrashBin bin)
		{
			var module = await _context.RuleModules.Include(m => m.Translations).FirstOrDefaultAsync(m => m.Id == id);
			if (module is null)
			{
				return NotFound();
			}
			if (this.EnsureCanModify(_access, module) is { } denied)
			{
				return denied;
			}
			await bin.AddAsync(module, "module", ContentAccess.GetUserId(User) ?? string.Empty, module.Id);
			_context.RuleModules.Remove(module);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		internal static List<RuleEffect> Read(string? json) => RuleEffectJson.Read(json);

		private ActionResult? Validate(SaveRuleModuleDto dto)
		{
			dto.Effects ??= new();
			dto.Translations ??= new();
			if (dto.Translations.Count == 0 || dto.Translations.Any(t => !Enum.IsDefined(t.Language) || string.IsNullOrWhiteSpace(t.Name) || t.Name.Trim().Length > 100
				|| (t.Description?.Length ?? 0) > 8000) || dto.Translations.Select(t => t.Language).Distinct().Count() != dto.Translations.Count)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A module needs a name (at most 100 characters) per language.");
			}
			if (!Enum.IsDefined(dto.Ruleset) || !Enum.IsDefined(dto.Visibility))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown edition or visibility.");
			}
			if (RuleEffectRules.Validate(dto.Effects) is { } code)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid effect.", detail: code);
			}
			return null;
		}

		private RuleModuleDetailDto ToDetail(RuleModule m, LanguageCode lang, Dictionary<string, string> names)
		{
			var tr = m.Translations.Localize(lang);
			return new RuleModuleDetailDto(m.Id, tr?.Name ?? "?", tr?.Description ?? string.Empty, m.Ruleset, Read(m.Effects),
				m.Translations.OrderBy(t => t.Language).Select(t => new RuleModuleTranslationDto { Language = t.Language, Name = t.Name, Description = t.Description }).ToList(),
				_access.CanModify(m, User), m.Visibility, m.AuthorId is null ? null : names.GetValueOrDefault(m.AuthorId));
		}
	}
}
