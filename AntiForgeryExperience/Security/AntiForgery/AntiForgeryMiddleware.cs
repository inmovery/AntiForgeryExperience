namespace AntiForgeryExperience.Security.AntiForgery;

public class AntiForgeryMiddleware
{
	private readonly IAntiforgery _antiForgery;
	private readonly RequestDelegate _next;

	public AntiForgeryMiddleware(RequestDelegate next, IAntiforgery antiForgery)
	{
		_next = next;
		_antiForgery = antiForgery;
	}

	public async Task InvokeAsync(HttpContext httpContext)
	{
		const string key = "x-csrf-token";

		var requestPath = httpContext.Request.Path;

		if (requestPath.StartsWithSegments("/api"))
		{
			var tokenSet = _antiForgery.GetAndStoreTokens(httpContext);

			var value = tokenSet.RequestToken!;
			var cookieOptions = new CookieOptions
			{
				HttpOnly = false,
				IsEssential = true,
				SameSite = SameSiteMode.Lax
			};

			httpContext.Response.Cookies.Append(key, value, cookieOptions);
		}
		else
		{
			try
			{
				if (httpContext.Request.Headers.ContainsKey(key))
				{
					await _antiForgery.ValidateRequestAsync(httpContext);
				}
			}
			catch (AntiforgeryValidationException exception)
			{
				// ignored
			}
		}

		await _next.Invoke(httpContext);
	}
}