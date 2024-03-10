using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication11.Filters
{
    public class UniqueUsersFilter : IAsyncActionFilter
    {
        private static readonly HashSet<string> _uniqueUsers = new();
        private readonly string _uniqueUsersFilePath = "UniqueUsers.txt";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userIp = context.HttpContext.Connection.RemoteIpAddress.ToString();
            
            lock (_uniqueUsers)
            {
                if (_uniqueUsers.Add(userIp))
                {
                    var userCountMessage = $"Unique Users: {_uniqueUsers.Count}\n";
                    File.WriteAllText(_uniqueUsersFilePath, userCountMessage);
                }
            }

            await next();
        }
    }
}