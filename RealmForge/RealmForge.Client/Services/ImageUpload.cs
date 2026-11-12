using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	A picture from a file to the account's images: reduced by the browser (512 px on the longest side, JPEG) first.
	///	</summary>
	public static class ImageUpload
	{
		private sealed record Resized(string Url, int Width, int Height);

		public static async Task<UserImageDto?> SendAsync(ImageDataService images, IJSRuntime js, IBrowserFile file, string? name = null)
		{
			try
			{
				await using var stream = file.OpenReadStream(maxAllowedSize: 20_000_000);
				using var memory = new MemoryStream();
				await stream.CopyToAsync(memory);
				var source = $"data:{file.ContentType};base64,{Convert.ToBase64String(memory.ToArray())}";
				var resized = await js.InvokeAsync<Resized>("rfResizeImage", source, 512);
				if (string.IsNullOrEmpty(resized.Url))
				{
					return null;
				}
				var title = string.IsNullOrWhiteSpace(name) ? Path.GetFileNameWithoutExtension(file.Name) : name.Trim();
				return await images.UploadAsync(title.Length > 100 ? title[..100] : title, resized.Url, resized.Width, resized.Height);
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
