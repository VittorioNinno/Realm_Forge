using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Shared.DTOs;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using RealmForge.Api.Localization;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SpeciesController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;

		public SpeciesController(RealmForgeDbContext context, ContentAccess access)
		{
			_context = context;
			_access = access;
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
					CanEdit: _access.CanModify(s, User)
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

			if (species == null)
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

			var subspeciesList = species.Subspecies.Select(sub =>
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
					CanEdit: _access.CanModify(sub, User)
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
				CanEdit: _access.CanModify(species, User)
			);

			return Ok(response);
		}

		//	POST: api/species
		[HttpPost]
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

			var species = new Species
			{
				BaseSpeedInFeet = dto.BaseSpeedInFeet,
				AllowedSizes = dto.AllowedSizes,
				CreatureType = dto.CreatureType,
				Ruleset = dto.Ruleset,
				IsOfficialSRD = false,
				AuthorId = ContentAccess.GetUserId(User),
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
				CanEdit: _access.CanModify(species, User)
			);

			return CreatedAtAction(nameof(GetById), new { id = species.Id }, response);
		}

		//	PUT: api/species/{id}
		[HttpPut("{id:guid}")]
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

			//	Update core mechanical data
			species.BaseSpeedInFeet = dto.BaseSpeedInFeet;
			species.AllowedSizes = dto.AllowedSizes;
			species.CreatureType = dto.CreatureType;
			species.Ruleset = dto.Ruleset;

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
					species.Translations.Add(new SpeciesTranslation
					{
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
		public async Task<IActionResult> DeleteSpecies(Guid id)
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

			_context.Species.Remove(species);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}