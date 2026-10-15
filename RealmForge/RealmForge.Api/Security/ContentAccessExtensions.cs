using Microsoft.AspNetCore.Mvc;
using RealmForge.Domain.Common;

namespace RealmForge.Api.Security
{
	public static class ContentAccessExtensions
	{
		///	<summary>
		///	Returns a 403 ProblemDetails when the current user may not modify the entity, otherwise null.
		///	</summary>
		public static ActionResult? EnsureCanModify(this ControllerBase controller, ContentAccess access, GameEntity entity)
		{
			if (entity.IsOfficialSRD)
			{
				return controller.Problem(statusCode: StatusCodes.Status403Forbidden, title: "Official SRD content is read-only.");
			}

			if (!access.CanModify(entity, controller.User))
			{
				return controller.Problem(statusCode: StatusCodes.Status403Forbidden, title: "You can only modify your own Homebrew content.");
			}

			return null;
		}
	}
}
