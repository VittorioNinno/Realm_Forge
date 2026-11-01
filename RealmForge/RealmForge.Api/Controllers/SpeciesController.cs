using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using RealmForge.Api.Localization;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Infrastructure.Persistence.Trash;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Species with their traits and subspecies: localized list and detail, and Homebrew create/update/delete.
	///	Subspecies of Base species can be added as Homebrew (see SubspeciesController).
	///	</summary>
	[ApiController]
	[Route("api/[controller]")]
	public class SpeciesController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;
		private readonly ShareService _shares;

		public SpeciesController(RealmForgeDbContext context, ContentAccess access, ShareService shares)
		{
			_context = context;
			_access = access;
			_shares = shares;
		}

		//	GET: api/species?lang=1&ruleset=2&isOfficial=true
		[HttpGet]
		public async Task<ActionResult<IEnumerable<SpeciesResponseDto>>> GetAll(
			[FromQuery] LanguageCode lang = LanguageCode.It,
			[FromQuery] RulesetVersion? ruleset = null,
			[FromQuery] bool? isOfficial = null)
		{
			var query = _context.Species
				.Include(s => s.Translations)
				.Include(s => s.Traits)
				.Include(s => s.Subspecies)
				.AsSplitQuery()
				.AsNoTracking()
				.AsQueryable();

			if (ruleset.HasValue)
			{
				query = query.Where(s => s.Ruleset == ruleset.Value);
			}

			if (isOfficial.HasValue)
			{
				query = query.Where(s => s.IsOfficialSRD == isOfficial.Value);
			}

			//	Private Homebrew of other users and link-only entries are not listed
			query = ContentAccess.ListedFor(query, User, await _shares.SharedWithAsync(User));

			var speciesList = await query.ToListAsync();

			var result = speciesList.Select(s =>
			{
				var translation = s.Translations.Localize(lang);

				return new SpeciesResponseDto(
					s.Id,
					translation?.Name ?? "Unnamed",
					translation?.Description ?? string.Empty,
					s.BaseSpeedInFeet,
					s.AllowedSizes,
					s.CreatureType,
					s.Ruleset,
					s.IsOfficialSRD,
					translation?.Language ?? lang,
					s.Traits.Count,
					s.Subspecies.Count,
					CanEdit: _access.CanModify(s, User),
					Source: s.Source,
					Visibility: s.Visibility
				);
			});

			return Ok(result);
		}

		//	GET: api/species/{id}?lang=1
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<SpeciesDetailResponseDto>> GetById(
			Guid id,
			[FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var species = await _context.Species
				.Include(s => s.Translations)
				.Include(s => s.Traits)
					.ThenInclude(t => t.Translations)
				.Include(s => s.Subspecies)
					.ThenInclude(sub => sub.Translations)
				.Include(s => s.Subspecies)
					.ThenInclude(sub => sub.Traits)
						.ThenInclude(t => t.Translations)
				.AsSplitQuery()
				.AsNoTracking()
				.FirstOrDefaultAsync(s => s.Id == id);

			//	Private entries of other users answer 404, as if they did not exist
			if (species == null || !_access.CanView(species, User, await _shares.SharedWithAsync(User)))
			{
				return NotFound();
			}

			var translation = species.Translations.Localize(lang);

			var baseTraits = species.Traits
				.OrderBy(t => t.RequiredLevel)
				.Select(t =>
				{
					var traitTranslation = t.Translations.Localize(lang);

					return new TraitResponseDto(
						t.Id,
						traitTranslation?.Name ?? "Unnamed Trait",
						traitTranslation?.Description ?? string.Empty,
						t.RequiredLevel,
						t.Ruleset,
						t.IsOfficialSRD
					);
				})
				.ToList();

			//	Lineages follow the list rule: other users' private or link-only lineages are left out
			var sharedWithUser = await _shares.SharedWithAsync(User);
			var subspeciesList = species.Subspecies.Where(sub => _access.IsListed(sub, User, sharedWithUser, species)).Select(sub =>
			{
				var subTranslation = sub.Translations.Localize(lang);

				var exclusiveTraits = sub.Traits
					.OrderBy(t => t.RequiredLevel)
					.Select(t =>
					{
						var traitTranslation = t.Translations.Localize(lang);

						return new TraitResponseDto(
							t.Id,
							traitTranslation?.Name ?? "Unnamed Trait",
							traitTranslation?.Description ?? string.Empty,
							t.RequiredLevel,
							t.Ruleset,
							t.IsOfficialSRD
						);
					})
					.ToList();

				return new SubspeciesResponseDto(
					sub.Id,
					subTranslation?.Name ?? "Unnamed Subspecies",
					subTranslation?.Description ?? string.Empty,
					sub.BaseSpeedOverrideInFeet,
					sub.Ruleset,
					sub.IsOfficialSRD,
					exclusiveTraits,
					CanEdit: _access.CanModify(sub, User),
					Source: sub.Source,
					Visibility: sub.Visibility,
					Effects: RuleEffectJson.Read(sub.Effects)
				);
			})
			.ToList();

			var response = new SpeciesDetailResponseDto(
				species.Id,
				translation?.Name ?? "Unnamed",
				translation?.Description ?? string.Empty,
				species.BaseSpeedInFeet,
				species.AllowedSizes,
				species.CreatureType,
				species.Ruleset,
				species.IsOfficialSRD,
				translation?.Language ?? lang,
				baseTraits,
				subspeciesList,
				CanEdit: _access.CanModify(species, User),
				Source: species.Source,
				Visibility: species.Visibility,
				Effects: RuleEffectJson.Read(species.Effects)
			);

			return Ok(response);
		}

		//	POST: api/species
		[HttpPost]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<ActionResult<SpeciesResponseDto>> Create([FromBody] CreateSpeciesDto dto)
		{
			if (dto.Translations == null || !dto.Translations.Any())
			{
				return BadRequest("At least one translation must be provided.");
			}

			if (dto.AllowedSizes == null || !dto.AllowedSizes.Any())
			{
				return BadRequest("At least one size must be selected.");
			}

			if (RuleEffectRules.Validate(dto.Effects ?? new()) is { } effectError)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid effect.", detail: effectError);
			}

			var species = new Species
			{
				Effects = RuleEffectJson.Write(dto.Effects),
				BaseSpeedInFeet = dto.BaseSpeedInFeet,
				AllowedSizes = dto.AllowedSizes,
				CreatureType = dto.CreatureType,
				Ruleset = dto.Ruleset,
				IsOfficialSRD = false,
				AuthorId = ContentAccess.GetUserId(User),
				Visibility = dto.Visibility,
				Translations = dto.Translations.Select(t => new SpeciesTranslation
				{
					Language = t.Language,
					Name = t.Name,
					Description = t.Description
				}).ToList(),
				Traits = dto.BaseTraits?.Select(tr => new Trait
				{
					RequiredLevel = tr.RequiredLevel,
					Ruleset = tr.Ruleset,
					IsOfficialSRD = false,
					AuthorId = ContentAccess.GetUserId(User),
					Visibility = dto.Visibility,
					Translations = tr.Translations.Select(trt => new TraitTranslation
					{
						Language = trt.Language,
						Name = trt.Name,
						Description = trt.Description
					}).ToList()
				}).ToList() ?? new List<Trait>(),
				Subspecies = dto.Subspecies?.Select(sub => new Subspecies
				{
					BaseSpeedOverrideInFeet = sub.BaseSpeedOverrideInFeet,
					Ruleset = sub.Ruleset,
					IsOfficialSRD = false,
					AuthorId = ContentAccess.GetUserId(User),
					Visibility = dto.Visibility,
					Translations = sub.Translations.Select(sbt => new SubspeciesTranslation
					{
						Language = sbt.Language,
						Name = sbt.Name,
						Description = sbt.Description
					}).ToList(),
					Traits = sub.Traits?.Select(tr => new Trait
					{
						RequiredLevel = tr.RequiredLevel,
						Ruleset = tr.Ruleset,
						IsOfficialSRD = false,
						AuthorId = ContentAccess.GetUserId(User),
						Visibility = dto.Visibility,
						Translations = tr.Translations.Select(trt => new TraitTranslation
						{
							Language = trt.Language,
							Name = trt.Name,
							Description = trt.Description
						}).ToList()
					}).ToList() ?? new List<Trait>()
				}).ToList() ?? new List<Subspecies>()
			};

			_context.Species.Add(species);
			await _context.SaveChangesAsync();

			var firstTranslation = species.Translations.FirstOrDefault();

			var response = new SpeciesResponseDto(
				species.Id,
				firstTranslation?.Name ?? "Unnamed",
				firstTranslation?.Description ?? string.Empty,
				species.BaseSpeedInFeet,
				species.AllowedSizes,
				species.CreatureType,
				species.Ruleset,
				species.IsOfficialSRD,
				firstTranslation?.Language ?? LanguageCode.En,
				TraitCount: species.Traits.Count,
				SubspeciesCount: species.Subspecies.Count,
				CanEdit: _access.CanModify(species, User),
				Source: species.Source,
				Visibility: species.Visibility
			);

			return CreatedAtAction(nameof(GetById), new { id = species.Id }, response);
		}

		//	PUT: api/species/{id}
		[HttpPut("{id:guid}")]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<IActionResult> UpdateSpecies(Guid id, [FromBody] UpdateSpeciesDto dto)
		{
			if (id != dto.Id)
			{
				return BadRequest("ID mismatch between route and payload.");
			}

			var species = await _context.Species
				.Include(s => s.Translations)
				.FirstOrDefaultAsync(s => s.Id == id);

			if (species == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, species);
			if (denied != null)
			{
				return denied;
			}

			if (RuleEffectRules.Validate(dto.Effects ?? new()) is { } effectError)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid effect.", detail: effectError);
			}
			species.Effects = RuleEffectJson.Write(dto.Effects);

			//	Update core mechanical data
			species.BaseSpeedInFeet = dto.BaseSpeedInFeet;
			species.AllowedSizes = dto.AllowedSizes;
			species.CreatureType = dto.CreatureType;
			species.Ruleset = dto.Ruleset;
			species.Visibility = dto.Visibility;

			//	Safely update translations (Upsert approach)
			foreach (var tDto in dto.Translations)
			{
				var existingTranslation = species.Translations.FirstOrDefault(t => t.Language == tDto.Language);

				if (existingTranslation != null)
				{
					//	Update existing
					existingTranslation.Name = tDto.Name;
					existingTranslation.Description = tDto.Description;
				}
				else
				{
					//	Add new
					//	Added through the context so EF inserts it (a preset Guid key would otherwise be treated as an existing row)
					_context.SpeciesTranslations.Add(new SpeciesTranslation
					{
						SpeciesId = species.Id,
						Language = tDto.Language,
						Name = tDto.Name,
						Description = tDto.Description
					});
				}
			}

			//	Remove translations that are no longer present in the payload
			var dtoLanguages = dto.Translations.Select(t => t.Language).ToList();
			var translationsToRemove = species.Translations
				.Where(t => !dtoLanguages.Contains(t.Language))
				.ToList();

			if (translationsToRemove.Any())
			{
				_context.SpeciesTranslations.RemoveRange(translationsToRemove);
			}

			await _context.SaveChangesAsync();

			return NoContent();	//	204 Success
		}

		//	DELETE: api/species/{id}
		[HttpDelete("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> DeleteSpecies(Guid id, [FromServices] TrashBin bin)
		{
			var species = await _context.Species.FindAsync(id);

			if (species == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, species);
			if (denied != null)
			{
				return denied;
			}

			//	Kept in the bin for a few days, to be restored
			await bin.AddAsync(species, "species", ContentAccess.GetUserId(User) ?? string.Empty, species.Id);
			_context.Species.Remove(species);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}