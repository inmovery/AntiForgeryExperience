namespace AntiForgeryExperience.Extensions;

public static class AntiForgeryExtensions
{
    public static IApplicationBuilder UseAntiForgery(this IApplicationBuilder applicationBuilder)
    {
        return applicationBuilder.UseMiddleware<AntiForgeryMiddleware>();
    }
}