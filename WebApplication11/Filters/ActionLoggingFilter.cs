using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication11.Filters
{
    public class ActionLoggingFilter : IAsyncActionFilter
    {
        private readonly string _logFilePath = "ActionLog.txt";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var accessTime = DateTime.UtcNow;

            var logMessage = $"{accessTime}: {actionName}\n";

            await File.AppendAllTextAsync(_logFilePath, logMessage);
            
            var resultContext = await next();
        }
    }
}