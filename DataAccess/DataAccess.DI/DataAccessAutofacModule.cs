using Autofac;
using DataAccess.Contract.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DI
{
    public class DataAccessAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CopyFilesRepository>()
                .As<IDataAccessRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
