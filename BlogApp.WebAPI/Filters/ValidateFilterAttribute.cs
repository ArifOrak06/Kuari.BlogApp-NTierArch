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
                var errorDto = new ErrorDto(errors, true);
                context.Result = new BadRequestObjectResult(Response<NoDataDto>.Fail(400, errorDto));
            }
      
        }
    }
}
