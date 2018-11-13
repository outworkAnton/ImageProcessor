using Autofac;
using DataAccess.Contract.Interfaces;

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
