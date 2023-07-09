namespace AntiForgeryExperience.Security.AntiForgery;

public class GenerateAntiForgeryTokenCookieAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        const string key = "x-csrf-token";

        var antiForgery = context.HttpContext.RequestServices.GetService(typeof(IAntiforgery)) as IAntiforgery;

        var tokens = antiForgery?.GetAndStoreTokens(context.HttpContext);

        var value = tokens?.RequestToken!;
        var cookieOptions = new CookieOptions
        {
            HttpOnly = false,
            IsEssential = true,
            SameSite = SameSiteMode.Lax
        };

        context.HttpContext.Response.Cookies.Append(key, value, cookieOptions);
    }
}