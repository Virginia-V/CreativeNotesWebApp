using CreativeNotes.API.Infrastructure.Middlewares;

namespace CreativeNotes.API.Infrastructure.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app) => app.UseMiddleware<ExceptionHandlingMiddleware>();

    }
}
