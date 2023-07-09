namespace AntiForgeryExperience.Security.AntiForgery;

public class AntiForgeryManager : IAntiForgeryManager
{
    private readonly IAntiforgery _antiForgery;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AntiForgeryManager(IAntiforgery antiForgery, IHttpContextAccessor httpContextAccessor)
    {
        _antiForgery = antiForgery;
        _httpContextAccessor = httpContextAccessor;
    }

    public string GenerateToken()
    {
        return _antiForgery.GetAndStoreTokens(_httpContextAccessor.HttpContext!).RequestToken!;
    }

    public AntiforgeryTokenSet GetTokenSet()
    {
        return _antiForgery.GetTokens(_httpContextAccessor.HttpContext!);
    }
}