using juultimesedler_be.Services;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Web.Common.ApplicationBuilder;

namespace juultimesedler_be
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args)
                .Build()
                .Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) => {
                    services.AddScoped<IProjectsService, ProjectsService>();
                })
                .ConfigureUmbracoDefaults()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(
                        services => services.AddCors(
                            options => options.AddPolicy(
                                "MyCors", policy =>
                                    {
                                        policy
                                        .AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                    }
                            )
                        )
                    );
                    webBuilder.UseStaticWebAssets();
                    webBuilder.UseStartup<Startup>();
                });
    }

    #region CORS
    public class MyComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    x =>    x.AllowAnyOrigin()
                             .AllowAnyHeader()
                             .AllowAnyMethod()
                );
            });

            builder.Services.Configure<UmbracoPipelineOptions>(options =>
            {
                options.AddFilter(new UmbracoPipelineFilter(nameof(MyComposer))
                {
                    PostPipeline = appBuilder => appBuilder.UseCors()
                });
            });
        }
    }
    #endregion
}
