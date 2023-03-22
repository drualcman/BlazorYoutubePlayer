using BlazorIndexedDb;

namespace BlazorYoutubePlayerViewer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.AddBlazorIndexedDbContext<DBContext>();
            builder.Services.AddScoped<IYoutubePlayerRepository, YoutubePlayerRepository>();

            var app = builder.Build();
            await app.UseBlazorIndexedDbContext<DBContext>();
            await app.RunAsync();
        }
    }
}
