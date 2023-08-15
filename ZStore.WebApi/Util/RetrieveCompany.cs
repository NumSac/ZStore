using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using ZStore.Domain.Models;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.WebApi.Util
{ 
    public class RetrieveCompany : IAsyncActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public RetrieveCompany(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var identity = context.HttpContext.User.Identity;
            if (identity != null)
            {
                var user = context.HttpContext.User;
                var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var userRepo = _unitOfWork.ApplicationUser;
                    var applicationUser = await userRepo.GetByIdAsync(userIdClaim);

                    if (applicationUser != null && applicationUser.Company != null)
                    {
                        // Store the ApplicationUser in HttpContext.Items or another suitable location
                        context.HttpContext.Items["Company"] = applicationUser.Company;
                    }
                }
            } else
            {
                throw new UnauthorizedAccessException();
            }

            await next(); // Continue with the action execution
        }
    }
}
