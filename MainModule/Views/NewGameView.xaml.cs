using MainModule.ViewModels;
using System.Windows.Controls;

namespace MainModule.Views
{
    /// <summary>
    /// Interaction logic for NewGameView.xaml
    /// </summary>
    public partial class NewGameView : UserControl
    {
        public NewGameView(NewGameViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
