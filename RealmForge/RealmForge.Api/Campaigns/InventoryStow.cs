using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Characters;

namespace RealmForge.Api.Campaigns
{
	///	<summary>
	///	Puts an item into a character's inventory as the sheet expects it: on the entry of the same equipment (or of the
	///	same free item) when there is one; a magic item with its rules read from the compendium.
	///	</summary>
	public static class InventoryStow
	{
		public const int MaxInventory = 300;

		private static readonly JsonSerializerOptions MechanicsJson = new(JsonSerializerDefaults.Web);

		public static async Task<bool> StowAsync(RealmForgeDbContext context, CharacterSheetState sheet, Guid? equipmentId, Guid? magicItemId, string name, int quantity,
			string? notes = null)
		{
			InventoryItem? existing = equipmentId is { } id
				? sheet.Inventory.FirstOrDefault(i => i.EquipmentId == id && i.Magic is null)
				: magicItemId is null
					? sheet.Inventory.FirstOrDefault(i => i.EquipmentId is null && i.Magic is null && i.Name == name)
					: null;
			if (existing is not null)
			{
				existing.Quantity += quantity;
				return true;
			}
			if (sheet.Inventory.Count >= MaxInventory)
			{
				return false;
			}
			var entry = new InventoryItem { EquipmentId = equipmentId, Name = equipmentId is null ? name : null, Quantity = quantity, Notes = notes };
			if (magicItemId is { } magicId && await context.MagicItems.AsNoTracking().FirstOrDefaultAsync(m => m.Id == magicId) is { } magic)
			{
				entry.Magic = ReadMechanics(magic.Mechanics) ?? new MagicItemProperties();
				entry.Magic.Rarity = magic.Rarity ?? entry.Magic.Rarity;
				entry.Magic.RequiresAttunement = magic.RequiresAttunement;
			}
			else if (magicItemId is not null)
			{
				entry.Magic = new MagicItemProperties();
			}
			sheet.Inventory.Add(entry);
			return true;
		}

		public static MagicItemProperties? ReadMechanics(string? json)
		{
			if (string.IsNullOrWhiteSpace(json))
			{
				return null;
			}
			try
			{
				return JsonSerializer.Deserialize<MagicItemProperties>(json, MechanicsJson);
			}
			catch (JsonException)
			{
				return null;
			}
		}
	}
}
