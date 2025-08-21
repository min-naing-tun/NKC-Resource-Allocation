using Microsoft.IdentityModel.Tokens;
using NKC_Resource_Allocation.Database.Helper;
using NKC_Resource_Allocation.Utilities;

namespace NKC_Resource_Allocation.Middleware
{
    public class Guard
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _scopeFactory;
        private bool _hasRun = false;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Guard(RequestDelegate next, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            HttpRequest request = context.Request;

            bool apiRequestFlag = request.Path.Value!.Contains("api");

            if (apiRequestFlag)
            {
                string requestAPIKey = request.Headers["APIKey"].ToString();

                if (!requestAPIKey.IsNullOrEmpty())
                {
                    if(requestAPIKey != new KeyConfig().GetApiKey())
                    {
                        context.Response.StatusCode = 401;
                        return;
                    }
                }
                else
                {
                    context.Response.StatusCode = 401;
                    return;
                }
            }
            await _next(context);
        }
    }
}
