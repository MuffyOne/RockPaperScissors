using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Regions;
using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MainModule.ViewModels
{
    public class GameViewModel : BindableBase, INavigationAware
    {
        #region fields
        private IGame _game;
        private IUnityContainer _unityContainer;
        private IPlayer _playerOne;
        private IPlayer _playerTwo;
        private int _currentTurn;
        private string _inGameMessage;
        private string _playerOneChoice;
        private string _playerTwoChoice;
        private string _countDownMessage;  
        private ObservableCollection<MoveModel> _moves;
        private int? _nextPlayerOneMove;
        private int? _nextPlayerTwoMove;
        private Visibility _playerOneHumanChoiceVisibility;
        private Visibility _playerTwoHumanChoiceVisibility;
        private int _playerOneScore;
        private int _playerTwoScore;
        private string _numerberOfTurns;
        #endregion


        #region properties
        public IPlayer PlayerOne
        {
            get { return _playerOne; }
            set { SetProperty(ref _playerOne, value); }
        }

        public IPlayer PlayerTwo
        {
            get { return _playerTwo; }
            set { SetProperty(ref _playerTwo, value); }
        }

        public IGame Game
        {
            get { return _game; }
            set { SetProperty(ref _game, value); }
        }

        public int CurrentTurn
        {
            get { return _currentTurn; }
            set { SetProperty(ref _currentTurn, value); }
        }

        public string InGameMessage
        {
            get { return _inGameMessage; }
            set { SetProperty(ref _inGameMessage, value); }
        }

        public string PlayerOneChoice
        {
            get { return _playerOneChoice; }
            set { SetProperty(ref _playerOneChoice, value); }
        }

        public int PlayerOneScore
        {
            get { return _playerOneScore; }
            set { SetProperty(ref _playerOneScore, value); }
            
        }

        public int PlayerTwoScore
        {
            get { return _playerTwoScore; }
            set { SetProperty(ref _playerTwoScore, value); }

        }

        public string PlayerTwoChoice
        {
            get { return _playerTwoChoice; }
            set { SetProperty(ref _playerTwoChoice, value); }
        }

        public string CountDownMessage
        {
            get { return _countDownMessage; }
            set { SetProperty(ref _countDownMessage, value); }
        }

        public Visibility PlayerOneHumanChoiceVisibility
        {
            get { return _playerOneHumanChoiceVisibility; }
            set { SetProperty(ref _playerOneHumanChoiceVisibility, value); }
        }

        public Visibility PlayerTwoHumanChoiceVisibility
        {
            get { return _playerTwoHumanChoiceVisibility; }
            set { SetProperty(ref _playerTwoHumanChoiceVisibility, value); }
        }

        public ObservableCollection<MoveModel> Moves
        {
            get { return _moves; }
            set { SetProperty(ref _moves, value); }
        }

        public string NumerberOfTurns
        {
            get { return _numerberOfTurns; }
            set { SetProperty(ref _numerberOfTurns, value); }
        }
        #endregion

        #region Commands and handlers
        public ICommand PlayerOneMakesChoiceCommand {get; set;}
        public ICommand PlayerTwoMakesChoiceCommand {get; set;}

        private void PreExecute()
        {
            // IsBusy = true;
        }

        private void PostExecute(Task task)
        {
            // if (task.IsFaulted)
            // {
            // }
            // IsBusy = false;
        }

        private async Task PlayerOneMakesChoice(object arg)
        {
            PlayerOneHumanChoiceVisibility = Visibility.Hidden;
            _nextPlayerOneMove = (int)arg;
            if (PlayerTwo.PlayerType != RockPaperScissors.Common.Enums.PlayerType.HumanPlayer
                || _nextPlayerTwoMove != null)
            {
                await PlayCurrentRound();
            }
        }
        private async Task PlayerTwoMakesChoice(object arg)
        {
            PlayerTwoHumanChoiceVisibility = Visibility.Hidden;
            _nextPlayerTwoMove = (int)arg;
            if (PlayerOne.PlayerType != RockPaperScissors.Common.Enums.PlayerType.HumanPlayer
                || _nextPlayerOneMove != null)
            {
                await PlayCurrentRound();
            }
        }

        private async Task PlayCurrentRound()
        {
            if (PlayerOne.PlayerType != RockPaperScissors.Common.Enums.PlayerType.HumanPlayer)
            {
                _nextPlayerOneMove = PlayerOne.GetNextMove(Game.Rules);
            }
            MoveModel move = Game.Rules.MoveList.FirstOrDefault(i => i.RuleValue == _nextPlayerOneMove);
            string nextPlayerOneMoveDescription = move.Description;


            if (PlayerTwo.PlayerType != RockPaperScissors.Common.Enums.PlayerType.HumanPlayer)
            {
                _nextPlayerTwoMove = PlayerTwo.GetNextMove(Game.Rules);
            }
            move = Game.Rules.MoveList.FirstOrDefault(i => i.RuleValue == _nextPlayerTwoMove);
            string nextPlayerTwoMoveDescription = move.Description;

            await TurnCountDown();
            PlayerOneChoice = nextPlayerOneMoveDescription;
            PlayerTwoChoice = nextPlayerTwoMoveDescription;
            DisplayWinningMove(_nextPlayerOneMove.Value, _nextPlayerTwoMove.Value);
            
            await DecideNextAction();
        }
        #endregion

        #region constructor
        public GameViewModel(IUnityContainer unityContainer, IGame game)
        {
            _game = game;
            PlayerOneHumanChoiceVisibility = Visibility.Hidden;
            PlayerTwoHumanChoiceVisibility = Visibility.Hidden;
            _unityContainer = unityContainer;
            PlayerOneMakesChoiceCommand = new SimpleAsyncCommandWithParameter(PreExecute, PlayerOneMakesChoice, PostExecute);
            PlayerTwoMakesChoiceCommand = new SimpleAsyncCommandWithParameter(PreExecute, PlayerTwoMakesChoice, PostExecute);

        }
        #endregion

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            InGameMessage = "";
            PlayerOneChoice = "";
            PlayerTwoChoice = "";
            PlayerOneHumanChoiceVisibility = Visibility.Hidden;
            PlayerTwoHumanChoiceVisibility = Visibility.Hidden;
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            Game = _unityContainer.Resolve<IGame>();
            PlayerOne = Game.PlayerOne;
            PlayerTwo = Game.PlayerTwo;
            Moves = new ObservableCollection<MoveModel>(Game.Rules.MoveList);
            NumerberOfTurns = Game.NumerberOfTurns.ToString();
            await SetUpGame();
        }

        private async Task SetUpGame()
        {
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
            CurrentTurn = 0;
            await NextRound();
        }

        private async Task NextRound()
        {
            CurrentTurn++;
            _nextPlayerOneMove = null;
            _nextPlayerTwoMove = null;
            if(_playerOne.PlayerType == RockPaperScissors.Common.Enums.PlayerType.HumanPlayer)
            {
                PlayerOneHumanChoiceVisibility = Visibility.Visible;
            }
            if (_playerTwo.PlayerType == RockPaperScissors.Common.Enums.PlayerType.HumanPlayer)
            {
                PlayerTwoHumanChoiceVisibility = Visibility.Visible;
            }
            if (PlayerOne.PlayerType != RockPaperScissors.Common.Enums.PlayerType.HumanPlayer && PlayerTwo.PlayerType != RockPaperScissors.Common.Enums.PlayerType.HumanPlayer)
            {
                await PlayCurrentRound();
            }
        }

       
        private async Task DecideNextAction()
        {
            var winner = Game.GetGameWinner(PlayerOneScore, PlayerTwoScore);
            if (winner == -1)
            {
                await NextRound();
            }
            else
            {
                if (winner == 0)
                {
                    InGameMessage = "Game drawn";
                }
                else
                {
                    string playerName = winner == 1 ? PlayerOne.PlayerName : PlayerTwo.PlayerName;
                    InGameMessage = string.Format("{0} won the game!", playerName);
                }
            }
        }
        
        private async Task TurnCountDown()
        {
            int i = 3;
            while (i != 0)
            {
                CountDownMessage = "Next turn in " + i;
                await Task.Delay(1000);
                i--;
            }
            CountDownMessage = "";
        }

        private void DisplayWinningMove(int nextPlayerOneMove, int nextPlayerTwoMove)
        {
            var winningMove = Game.Rules.GetWinningMove(nextPlayerOneMove, nextPlayerTwoMove);
            switch (winningMove)
            {
                case 0:
                    {
                        PlayerOneScore++;
                        PlayerTwoScore++;
                        InGameMessage = "DRAW";
                        break;
                    }
                case 1:
                    {
                        PlayerOneScore++;
                        InGameMessage = string.Format("{0} won the turn", PlayerOne.PlayerName);
                        break;
                    }
                case 2:
                    {
                        PlayerTwoScore++;
                        InGameMessage = string.Format("{0} won the turn", PlayerTwo.PlayerName);
                        break;
                    }
                default:
                    break;

            }
        }
    }
}
