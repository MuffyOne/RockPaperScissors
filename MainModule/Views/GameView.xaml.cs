using MainModule.ViewModels;
using System.Windows.Controls;

namespace MainModule.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public GameView(GameViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
