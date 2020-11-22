using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.TinyIoc;
using TestTaskBE.BusinessLogic.Factories;
using TestTaskBE.BusinessLogic.Interfaces.Factories;
using TestTaskBE.BusinessLogic.Interfaces.Services;
using TestTaskBE.BusinessLogic.Interfaces.WebProviders;
using TestTaskBE.BusinessLogic.Providers;
using TestTaskBE.BusinessLogic.Services;
using TestTaskBE.Common.Configuration;

namespace TestTaskBE.Web
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        private readonly IConfiguration _configuration;

        public CustomBootstrapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Configure<NancyData>(_configuration.GetSection("Configuration"));
            container.Register<IStoryService, StoryService>();
            container.Register<IWebProvider, WebProvider>();
            container.Register<IMapperFactory, MapperFactory>();
        }
    }

    internal static class ContainerExtensions
    {
        public static void Configure<TOptions>(this TinyIoCContainer container, IConfiguration config) where TOptions : class, new()
        {
            var options = new TOptions();
            config.Bind(options);
            container.Register(options);
        }
    }
}
