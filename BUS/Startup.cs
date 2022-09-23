using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(BUS.Startup))]

namespace BUS
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
