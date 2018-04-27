using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using RockPaperScissors.Common.Enums;
using RockPaperScissors.Common.Helpers;
using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.Models;
using RockPaperScissors.Common.Resources;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using MainModule.Views;
using RockPaperScissors.Common.PlayersImplementation;
using RockPaperScissors.Common.Rules;

namespace MainModule.ViewModels
{
    public class NewGameViewModel : BindableBase
    {
        #region fields
        private ObservableCollection<PlayerTypeBinder> _playerOnePlayerType;
        private ObservableCollection<PlayerTypeBinder> _playerTwoPlayerType;
        private readonly IRegionManager _regionManager;
        private readonly IGame _game;
        private string _playerOneName;
        private string _playerTwoName;
        #endregion

        #region properties
        public ICommand StartNewGameCommand { get; set; }

        private IRegion MainRegion { get { return _regionManager.Regions[RegionNames.MainRegion]; } }
        public ObservableCollection<PlayerTypeBinder> PlayerOnePlayerType
        {
            get { return _playerOnePlayerType; }
            set { SetProperty(ref _playerOnePlayerType, value); }
        }

        public ObservableCollection<PlayerTypeBinder> PlayerTwoPlayerType
        {
            get { return _playerTwoPlayerType; }
            set { SetProperty(ref _playerTwoPlayerType, value); }
        }

        public string PlayerOneName
        {
            get { return _playerOneName; }
            set { SetProperty(ref _playerOneName, value); }
        }

        public string PlayerTwoName
        {
            get { return _playerTwoName; }
            set { SetProperty(ref _playerTwoName, value); }
        }
        #endregion

        #region constructor
        public NewGameViewModel(IRegionManager regionManager, IGame game)
        {
            _regionManager = regionManager;
            _game = game;
            InitializeCommands();
            InitializePlayersTypes();
        }
        #endregion

        #region methods
        /*The filters to select which type of player you want is created dynamically starting from the Enum list describing the 
        list of available player type, if you add a new type of player you don't have to update the view
        */
        private void InitializePlayersTypes()
        {
            Guid guidPlayerOne = Guid.NewGuid();
            Guid guidPlayerTwo = Guid.NewGuid();
            PlayerOnePlayerType = new ObservableCollection<PlayerTypeBinder>();
            PlayerTwoPlayerType = new ObservableCollection<PlayerTypeBinder>();
            foreach (PlayerType playerType in Enum.GetValues(typeof(PlayerType)))
            {
                PlayerTypeBinder playerOneTypeBinder = new PlayerTypeBinder
                {
                    PlayerType = playerType,
                    Group = guidPlayerOne,
                    IsChecked = playerType == PlayerType.HumanPlayer ? true : false,
                    Description = EnumHelper.GetEnumDescription(playerType)
                };
                PlayerOnePlayerType.Add(playerOneTypeBinder);

                PlayerTypeBinder playerTwoTypeBinder = new PlayerTypeBinder
                {
                    PlayerType = playerType,
                    Group = guidPlayerTwo,
                    IsChecked = playerType == PlayerType.ComputerPlayer ? true : false,
                    Description = EnumHelper.GetEnumDescription(playerType)
                };
                PlayerTwoPlayerType.Add(playerTwoTypeBinder);
            }
        }

        private void InitializeCommands()
        {
            StartNewGameCommand = new DelegateCommand(OnStartNewGameCommand);
        }

        private void OnStartNewGameCommand()
        {
            PlayerTypeBinder binderPlOne = PlayerOnePlayerType.FirstOrDefault(i => i.IsChecked);
            IPlayer playerOne = CreatePlayer(binderPlOne.PlayerType);
            playerOne.PlayerName = PlayerOneName;
            playerOne.PlayerType = binderPlOne.PlayerType;

            PlayerTypeBinder binderPlTwo = PlayerTwoPlayerType.FirstOrDefault(i => i.IsChecked);
            IPlayer playerTwo = CreatePlayer(binderPlTwo.PlayerType);
            playerTwo.PlayerName = PlayerTwoName;
            playerTwo.PlayerType = binderPlTwo.PlayerType;

            //TODO: Bind this to a property of the options to make the number of turns selectable.
            //PS: changing this value manualy already works

            _game.NumerberOfTurns = 3;
            _game.PlayerOne = playerOne;
            _game.PlayerTwo = playerTwo;
            _game.Rules = new RockPaperScissorsRules();
            MainRegion.NavigateTo(typeof(GameView));
        }

        private IPlayer CreatePlayer(PlayerType playerType)
        {
            switch (playerType)
            {
                case PlayerType.ComputerPlayer:
                    return new ComputerPlayer();
                case PlayerType.HumanPlayer:
                    return new HumanPlayer();
                case PlayerType.TacticalPlayer:
                    return new TacticalPlayer();
                default:
                    throw new Exception("This player type has not been implemented");
            }
        }

        #endregion
    }
}
