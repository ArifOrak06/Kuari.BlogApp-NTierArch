using BlogApp.SharedLibrary.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogApp.WebAPI.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                
                context.Result = new BadRequestObjectResult(CustomResponseDto<NoDataDto>.Fail(400, errors));
            }
      
        }
    }
}
