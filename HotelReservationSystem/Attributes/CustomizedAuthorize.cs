using HotelReservationSystem.Constants;
using HotelReservationSystem.Enums;
using HotelReservationSystem.Services.RoleFeatureServices;
using HotelReservationSystem.Services.UserRoleServices;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StayCation.API.VerticalSlicing.Common.Attributes
{
    public class CustomizedAuthorize : ActionFilterAttribute
    {
        private readonly Feature _feature;
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleFeatureService _roleFeatureService;

        public CustomizedAuthorize(Feature feature, IUserRoleService userRoleService, IRoleFeatureService roleFeatureService)
        {
            _feature = feature;
            _userRoleService = userRoleService;
            _roleFeatureService = roleFeatureService;
        }

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            var loggedUser = context.HttpContext.User;

            var userIdClaim = loggedUser.FindFirst(CustomClaimTypes.Id)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }

            int userId = int.Parse(userIdClaim);

            var roleIDs = await _userRoleService.GetRolesByUserId(userId);

            if (roleIDs == null || !roleIDs.Any())
            {
                throw new UnauthorizedAccessException("No roles found for the user.");
            }

            var hasAccess = false;

            foreach (var roleID in roleIDs)
            {
                hasAccess = await _roleFeatureService.CheckRoleFeatureAccess(roleID, _feature);

                if (hasAccess)
                {
                    break;
                }
            }

            if (!hasAccess)
            {
                throw new UnauthorizedAccessException("User does not have access to this feature.");
            }

            base.OnActionExecuting(context);
        }
    }
}
