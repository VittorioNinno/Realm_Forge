using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RealmForge.Infrastructure.Identity;

namespace RealmForge.Api.Security
{
	///	<summary>
	///	Creating or editing content requires a confirmed e-mail address. Signed-in users with an
	///	unconfirmed address get 403 with the "X-RealmForge-Error: EmailNotConfirmed" header, so the
	///	client can tell this case apart from an ownership error. Checked against the database, so a
	///	confirmation applies immediately without a new token.
	///	</summary>
	public class RequireConfirmedEmailFilter : IAsyncActionFilter
	{
		public const string ErrorHeader = "X-RealmForge-Error";
		public const string ErrorCode = "EmailNotConfirmed";

		private readonly UserManager<ApplicationUser> _users;

		public RequireConfirmedEmailFilter(UserManager<ApplicationUser> users)
		{
			_users = users;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (context.HttpContext.User.Identity?.IsAuthenticated == true)
			{
				var user = await _users.GetUserAsync(context.HttpContext.User);

				if (user is { EmailConfirmed: false })
				{
					context.HttpContext.Response.Headers[ErrorHeader] = ErrorCode;
					context.Result = new ObjectResult(new ProblemDetails
					{
						Status = StatusCodes.Status403Forbidden,
						Title = "E-mail not confirmed",
						Detail = "Confirm your e-mail address before creating or editing content."
					})
					{ StatusCode = StatusCodes.Status403Forbidden };
					return;
				}
			}

			await next();
		}
	}

	///	<summary>
	///	Applies <see cref="RequireConfirmedEmailFilter"/> to an action.
	///	</summary>
	public class RequireConfirmedEmailAttribute : ServiceFilterAttribute
	{
		public RequireConfirmedEmailAttribute() : base(typeof(RequireConfirmedEmailFilter)) { }
	}
}
