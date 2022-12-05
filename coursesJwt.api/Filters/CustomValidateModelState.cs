using coursesJwt.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace coursesJwt.api.Filters
{
    public class CustomValidateModelState : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var validateFieldsViewModel = new ValidateFieldsViewModelOutput(context.ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage));
                context.Result = new BadRequestObjectResult(validateFieldsViewModel);
            }
        }
    }
}
