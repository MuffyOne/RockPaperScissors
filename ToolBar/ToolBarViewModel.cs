using MainModule.Views;
using Prism.Commands;
using Prism.Regions;
using RockPaperScissors.Common.Helpers;
using RockPaperScissors.Common.Resources;
using System.Linq;
using System.Windows.Input;

namespace ToolBar
{
    public class ToolBarViewModel
    {
        #region fields
        private readonly IRegionManager _regionManager;
        #endregion

        #region properties
        public ICommand NewGameCommand { get; set; }

        private IRegion MainRegion { get { return _regionManager.Regions[RegionNames.MainRegion]; } }
        #endregion

        #region constructor
        public ToolBarViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            NewGameCommand = new DelegateCommand(OnNewGameCommand);
        }

        private void OnNewGameCommand()
        {
            if (MainRegion.ActiveViews.FirstOrDefault() is NewGameView)
            {
                return;
            }
            MainRegion.NavigateTo(typeof(NewGameView));
        }
        #endregion
    }
}
