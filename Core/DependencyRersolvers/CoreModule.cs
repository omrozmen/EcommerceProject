using System;
using System.Collections.Generic;
using System.Text;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Microsoft;
using Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyRersolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            //Startup method --old
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
