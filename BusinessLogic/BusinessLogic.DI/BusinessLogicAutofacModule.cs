using Autofac;
using BusinessLogic.Contract.Interfaces;
using BusinessLogic.Services;

namespace BusinessLogic.DI
{
    public class BusinessLogicAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CopyFilesService>()
                .As<ICopyFilesService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PrintService>()
                .As<IPrintService>()
                .InstancePerLifetimeScope();
        }
    }
}