using MainModule;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using ToolBar;
using Microsoft.Practices.Unity;
using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Models;

namespace RockPaperScissors
{
    public class BootStrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return new Shell();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Shell mainWindowShell = (Shell)Shell;
            InitializeContainer();
            Application.Current.MainWindow = mainWindowShell;
            Application.Current.MainWindow.Show();
        }

        private void InitializeContainer()
        {
            Container.RegisterType<IGame, Game>(new ContainerControlledLifetimeManager());
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(ToolBarModule));
            moduleCatalog.AddModule(typeof(MainModuleModule));
        }
    }
}
