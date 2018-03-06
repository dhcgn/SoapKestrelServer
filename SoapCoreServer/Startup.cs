using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SoapCore;

namespace SoapCoreServer
{
    public class ServiceContractImpl : IServiceContract
    {
        public string Ping()
        {
            return DateTime.UtcNow.ToString("O");
        }
    }

    [ServiceContract]
    public interface IServiceContract
    {
        [OperationContract]
        string Ping();
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<ServiceContractImpl>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSoapEndpoint<ServiceContractImpl>("/Service.asmx", new BasicHttpBinding());

            app.Run(context =>
            {
                context.Response.Redirect("Service.asmx");
                return Task.Run(() => { });
            });
        }
    }
}
