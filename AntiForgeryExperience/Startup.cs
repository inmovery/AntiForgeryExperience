using AntiForgeryExperience.Repositories;

namespace AntiForgeryExperience;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.Configure<CookiePolicyOptions>(options =>
        {
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });

        services.Configure<AppSettings>(Configuration);

        services.AddAntiforgery(antiForgeryOptions =>
        {
            var cookieBuilder = new CookieBuilder
            {
                Name = "x-csrf-token",
                HttpOnly = false,
                IsEssential = true,
                SameSite = SameSiteMode.Lax,
                SecurePolicy = CookieSecurePolicy.SameAsRequest
            };

            antiForgeryOptions.Cookie = cookieBuilder;
            antiForgeryOptions.HeaderName = "x-csrf-token";
            antiForgeryOptions.FormFieldName = "x-csrf-token";
            antiForgeryOptions.SuppressXFrameOptionsHeader = false;
        });

        services.AddRazorPages();

		services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = Configuration.GetConnectionString("MsSqlDatabase");
            options.UseSqlServer(connectionString);
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IBookRepository, BookRepository>();

        services.AddControllers();

	    services.AddResponseCompression(options =>
        {
	        options.EnableForHttps = true;
	        options.MimeTypes = new[] { MediaTypeNames.Application.Octet };
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
	    app.UsePathBase("/");

	    app.UseHttpsRedirection();
	    app.UseStaticFiles();

        app.UseCookiePolicy();
        app.UseRouting();

	    app.UseAuthorization();
        app.UseAntiForgery();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapRazorPages();
        });
    }
}