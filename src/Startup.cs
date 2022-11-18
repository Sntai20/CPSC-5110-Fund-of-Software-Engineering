namespace ContosoCrafts.WebSite
{
    using ContosoCrafts.WebSite.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// This class controls the startup behavior of the website.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Get method for Configuration property
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddRazorPages().AddRazorRuntimeCompilation();
            _ = services.AddServerSideBlazor();
            _ = services.AddHttpClient();
            _ = services.AddControllers();
            _ = services.AddTransient<JsonFileArticleService>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }
            else
            {
                _ = app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                _ = app.UseHsts();
            }

            _ = app.UseHttpsRedirection();

            _ = app.UseStaticFiles();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapRazorPages();
                _ = endpoints.MapControllers();
                _ = endpoints.MapBlazorHub();

                // endpoints.MapGet("/articles", (context) => 
                // {
                //     var articles = app.ApplicationServices.GetService<JsonFileArticleService>().GetArticles();
                //     var json = JsonSerializer.Serialize<IEnumerable<Article>>(articles);
                //     return context.Response.WriteAsync(json);
                // });
            });
        }
    }
}
