using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Yarm.RecipeSources;
using Yarm.RecipeSources.Factory;
using Yarm.Wasm.RecipeSources;

namespace Yarm.Wasm;

public static class ModuleConfigurations
{
    public static void ConfigureServices(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddMudServices();
        builder.Services.AddFluxor(opt =>
        {
            opt.ScanAssemblies(typeof(Program).Assembly);
            opt.UseRouting();

            opt.UseReduxDevTools(rdt =>
            {
                rdt.Name = "Yarm";
                rdt.EnableStackTrace();
            });
        }); 
        builder.Services.AddLocalStorageServices();
        builder.Services.AddRecipeSources();
    }

    private static void AddRecipeSources(this IServiceCollection services)
    {
        services.AddScoped<IRecipeSource, LocalStorageRecipeSource>();
        
        services.AddScoped<IRecipeSourceFactory, DefaultRecipeSourceFactory>();
    }
}