using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;

namespace Olympiads.Web.Requirements;

public class AdministratorRequirement : IAuthorizationRequirement
{
    public string[] AdminEmails { get; }
	public AdministratorRequirement(string[] adminEmails)
	{
		AdminEmails = adminEmails;
	}
}

public class AdministratorRequirementHandler : AuthorizationHandler<AdministratorRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdministratorRequirement requirement)
    {
        var right = context.User.FindFirst(c => c.Type == ClaimTypes.Email && requirement.AdminEmails.Contains(c.Value));

        if (right != null)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        return Task.CompletedTask;
    }
}