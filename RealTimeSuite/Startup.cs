using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RealTimeSuite.Startup))]

namespace RealTimeSuite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseCors(CorsOptions.AllowAll);
            var hubConfiguration = new HubConfiguration { EnableDetailedErrors = true, EnableJSONP = true, EnableJavaScriptProxies = true };
            app.MapSignalR(hubConfiguration);
        }
    }
}
