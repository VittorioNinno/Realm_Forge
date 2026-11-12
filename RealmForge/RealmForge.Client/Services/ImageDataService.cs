using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client for /api/images: the account's pictures and the pictures it chose for monsters and NPCs (kept in memory,
	///	the token picker and the monster pages read them often). FileUrl is the address of the picture itself.
	///	</summary>
	public class ImageDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<ImageDataService> _logger;
		private List<UserImageDto>? _images;
		private Dictionary<Guid, Guid>? _choices;

		public ImageDataService(HttpClient http, ILogger<ImageDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		//	Raised when the images or the choices change, for the pages that show them
		public event Action? Changed;

		public string FileUrl(Guid id) => new Uri(_http.BaseAddress!, $"api/images/{id}/file").ToString();

		public async Task<List<UserImageDto>> GetImagesAsync(bool fresh = false)
		{
			if (_images is not null && !fresh)
			{
				return _images;
			}
			try
			{
				_images = await _http.GetFromJsonAsync<List<UserImageDto>>("api/images") ?? new();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Loading the images failed");
				_images ??= new();
			}
			return _images;
		}

		public async Task<Dictionary<Guid, Guid>> GetChoicesAsync()
		{
			if (_choices is not null)
			{
				return _choices;
			}
			try
			{
				_choices = await _http.GetFromJsonAsync<Dictionary<Guid, Guid>>("api/images/monsters") ?? new();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Loading the monsters' pictures failed");
				return new();
			}
			return _choices;
		}

		//	The picture to show for a monster or an NPC: the account's choice, else its own portrait
		public async Task<string?> PictureOfAsync(Guid monsterId, string? portrait) =>
			(await GetChoicesAsync()).TryGetValue(monsterId, out var imageId) ? FileUrl(imageId) : portrait;

		public async Task<UserImageDto?> UploadAsync(string name, string dataUrl, int width, int height)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/images", new SaveImageDto { Name = name, Image = dataUrl, Width = width, Height = height });
				if (!response.IsSuccessStatusCode)
				{
					return null;
				}
				var image = await response.Content.ReadFromJsonAsync<UserImageDto>();
				if (image is not null)
				{
					(_images ??= new()).Insert(0, image);
					Changed?.Invoke();
				}
				return image;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Uploading an image failed");
				return null;
			}
		}

		public async Task<bool> RenameAsync(Guid id, string name)
		{
			var ok = await SendAsync(() => _http.PutAsJsonAsync($"api/images/{id}", new SaveImageDto { Name = name }));
			if (ok && _images?.FindIndex(i => i.Id == id) is { } index and >= 0)
			{
				_images[index] = _images[index] with { Name = name };
				Changed?.Invoke();
			}
			return ok;
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var ok = await SendAsync(() => _http.DeleteAsync($"api/images/{id}"));
			if (ok)
			{
				_images?.RemoveAll(i => i.Id == id);
				if (_choices is not null)
				{
					foreach (var key in _choices.Where(c => c.Value == id).Select(c => c.Key).ToList())
					{
						_choices.Remove(key);
					}
				}
				Changed?.Invoke();
			}
			return ok;
		}

		public async Task<bool> ChooseAsync(Guid monsterId, Guid? imageId)
		{
			var ok = await SendAsync(() => _http.PutAsJsonAsync($"api/images/monsters/{monsterId}", new ChooseImageDto { ImageId = imageId }));
			if (ok)
			{
				var choices = await GetChoicesAsync();
				if (imageId is { } chosen)
				{
					choices[monsterId] = chosen;
				}
				else
				{
					choices.Remove(monsterId);
				}
				_images = null;
				Changed?.Invoke();
			}
			return ok;
		}

		private async Task<bool> SendAsync(Func<Task<HttpResponseMessage>> send)
		{
			try
			{
				return (await send()).IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Images request failed");
				return false;
			}
		}
	}
}
