using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace StokTakip;

public class StokTakipWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<StokTakipWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
