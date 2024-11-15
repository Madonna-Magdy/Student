using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Repositories
{
    public class DependencyInjection : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();
        }

    }
}
