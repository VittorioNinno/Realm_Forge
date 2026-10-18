using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Move Earth (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MoveEarth2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "move-earth");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "move-earth", "en"),
					Language = LanguageCode.En,
					Name = "Move Earth",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 2 hours",
					MaterialComponent = "an iron blade and a small bag containing a mixture of soils—clay, loam, and sand",
					Description = "Choose an area of terrain no larger than 40 feet on a side within range. You can reshape dirt, sand, or clay in the area in any manner you choose for the duration. You can raise or lower the area's elevation, create or fill in a trench, erect or flatten a wall, or form a pillar. The extent of any such changes can't exceed half the area's largest dimension. So, if you affect a 40-foot square, you can create a pillar up to 20 feet high, raise or lower the square's elevation by up to 20 feet, dig a trench up to 20 feet deep, and so on. It takes 10 minutes for these changes to complete.\n\nAt the end of every 10 minutes you spend concentrating on the spell, you can choose a new area of terrain to affect.\n\nBecause the terrain's transformation occurs slowly, creatures in the area can't usually be trapped or injured by the ground's movement.\n\nThis spell can't manipulate natural stone or stone construction. Rocks and structures shift to accommodate the new terrain. If the way you shape the terrain would make a structure unstable, it might collapse.\n\nSimilarly, this spell doesn't directly affect plant growth. The moved earth carries any plants along with it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "move-earth", "it"),
					Language = LanguageCode.It,
					Name = "Muovere il Terreno",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 2 ore",
					MaterialComponent = "una lama di ferro e un sacchetto contenente un miscuglio di terre: argilla, terriccio e sabbia",
					Description = "L'incantatore sceglie un'area di terreno entro gittata non più grande di 12 metri di lato. Per la durata, può rimodellare a suo piacimento la terra, la sabbia o l'argilla nell'area. Può alzare o abbassare il livello dell'area, creare o riempire un fossato, erigere o spianare un muro o formare un pilastro. L'entità di tali cambiamenti non può superare la metà della dimensione maggiore dell'area. Quindi, se influenza un quadrato di 12 metri di lato, può creare un pilastro alto fino a 6 metri, alzare o abbassare il livello del quadrato fino a 6 metri, scavare un fossato profondo fino a 6 metri e così via. Questi cambiamenti richiedono 10 minuti per completarsi.\n\nAl termine di ogni periodo di 10 minuti trascorso a mantenere la concentrazione sull'incantesimo, l'incantatore può scegliere una nuova area di terreno da influenzare.\n\nPoiché la trasformazione del terreno avviene lentamente, di norma le creature nell'area non possono essere intrappolate o ferite dal movimento del suolo.\n\nQuesto incantesimo non può manipolare la pietra naturale o le costruzioni di pietra. Le rocce e le strutture si spostano per adattarsi al nuovo terreno. Se il modo in cui l'incantatore modella il terreno rende instabile una struttura, questa potrebbe crollare.\n\nAllo stesso modo, questo incantesimo non influenza direttamente la crescita delle piante. La terra spostata porta con sé le eventuali piante.",
					HigherLevels = null
				}
			}
		};
	}
}
