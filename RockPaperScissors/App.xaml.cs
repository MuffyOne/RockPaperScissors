using System.Windows;

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private BootStrapper _bootstrapper;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _bootstrapper = new BootStrapper();
            _bootstrapper.Run();

        }
    }
}
