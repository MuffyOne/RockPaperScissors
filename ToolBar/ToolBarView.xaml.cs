using System.Windows;
using System.Windows.Controls;

namespace ToolBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ToolBarView : UserControl
    {
        public ToolBarView(ToolBarViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
