namespace RealmForge.Client.Services
{
	public enum ApiErrorKind
	{
		Unreachable = 1,
		Forbidden = 2,
		Unauthorized = 5,
		Validation = 3,
		Server = 4
	}

	///	<summary>
	///	Holds the last API error so the layout can show it, instead of pages silently rendering empty lists.
	///	</summary>
	public class ApiErrorState
	{
		public ApiErrorKind? Current { get; private set; }

		public event Action? OnChange;

		public void Report(ApiErrorKind kind)
		{
			Current = kind;
			OnChange?.Invoke();
		}

		public void Clear()
		{
			if (Current is null)
			{
				return;
			}

			Current = null;
			OnChange?.Invoke();
		}
	}
}
