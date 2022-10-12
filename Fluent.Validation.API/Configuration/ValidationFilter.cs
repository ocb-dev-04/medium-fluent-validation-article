using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fluent.Validation.API.Configuration;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            Dictionary<string, IEnumerable<string>> errorsInModelState = context.ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage));

            var errorResponse = errorsInModelState.Select(error => new
            {
                FieldName = error.Key,
                Message = error.Value,
            }).ToList();

            context.Result = new BadRequestObjectResult(errorResponse);
            return;
        }

        await next();
    }
}
