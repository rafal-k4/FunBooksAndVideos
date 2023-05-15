using FunBooksAndVideos.Infrastructure;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos_eCommerceShop.Tests.Integration;

public class CustomWebApiFactory : WebApplicationFactory<IEntryPointMarker>
{

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices((webHost, services) =>
        {
            services.AddMassTransitTestHarness();
            services.AddDbContext<OrdersDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemory-TestDB");
            });
        });
        base.ConfigureWebHost(builder);
    }
}
