using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Regions;
using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.Models;

namespace MainModule.ViewModels
{
    public class GameViewModel : BindableBase, INavigationAware 
    {
        #region fields
        private IGame _game;
        private IUnityContainer _unityContainer;
        private IPlayer _playerOne;
        private IPlayer _playerTwo;
        #endregion

        #region properties
        public IPlayer PlayerOne {
            get { return _playerOne; }
            set { SetProperty(ref _playerOne, value); }
        }

        public IPlayer PlayerTwo {
            get { return _playerTwo; }
            set { SetProperty(ref _playerTwo, value); }
        }

        public IGame Game
        {
            get { return _game; }
            set { SetProperty(ref _game, value); }
        }
        #endregion

        #region constructor
        public GameViewModel(IUnityContainer unityContainer, IGame game)
        {
            _game = game;
            _unityContainer = unityContainer;
        }
        #endregion

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
            PlayerOne = _game.GetPlayerOne();
            PlayerTwo = _game.GetPlayerTwo();
           
        }
        
    }
}
