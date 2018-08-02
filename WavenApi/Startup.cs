using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WavenApi.Services;
using WavenApi.Services.NewFolder;

namespace WavenApi
{
	public class Startup
	{

		public IContainer ApplicationContainer { get; private set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			// Create the container builder with Autofac.
			ApplicationContainer = ConfigureAutofac(services);
			return new AutofacServiceProvider(ApplicationContainer);
		}

		private IContainer ConfigureAutofac(IServiceCollection services)
		{
			var builder = new ContainerBuilder();
			builder.Populate(services);

			builder.RegisterType<WavenService>().As<IWavenService>().SingleInstance();
			return builder.Build();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}




			app.UseMvc();

		}
	}
}
