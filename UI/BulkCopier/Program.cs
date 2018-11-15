using System;
using System.Windows.Forms;
using Autofac;
using BusinessLogic.DI;
using DataAccess.DI;

namespace BulkCopier
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(CreateContainer().Resolve<MainForm>());
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DataAccessAutofacModule());
            builder.RegisterModule(new BusinessLogicAutofacModule());
            builder.RegisterType<MainForm>().AsSelf();
            return builder.Build();
        }
    }
}
