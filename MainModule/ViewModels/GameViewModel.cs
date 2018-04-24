using Microsoft.Practices.Unity;
using Prism.Regions;
using RockPaperScissors.Common.Interfaces;

namespace MainModule.ViewModels
{
    public class GameViewModel : INavigationAware
    {
        #region fields
        private IGame _game;
        private IUnityContainer _unityContainer;
        #endregion

        #region constructor
        public GameViewModel(IUnityContainer unityContainer, IGame game)
        {
            _game = game;
            _unityContainer = unityContainer;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _game = _unityContainer.Resolve<IGame>();
        }
        #endregion
    }
}
