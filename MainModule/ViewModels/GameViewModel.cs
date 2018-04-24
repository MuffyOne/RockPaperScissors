using Microsoft.Practices.Unity;
using Prism.Regions;
using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.Models;

namespace MainModule.ViewModels
{
    public class GameViewModel : INavigationAware
    {
        #region fields
        private IGame _game;
        private IUnityContainer _unityContainer;

        #endregion

        #region properties
        private Player playerOne { get; set; }
        private Player playerTwo { get; set; }
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
            playerOne = _game.GetPlayerOne();
            playerTwo = _game.GetPlayerTwo();
        }
        #endregion
    }
}
