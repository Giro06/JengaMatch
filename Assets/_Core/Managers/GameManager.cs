using System;

namespace Giroo.Core
{
    public class GameManager
    {
        public event Action OnGameLoading;
        public event Action OnGameWaitForStart;
        public event Action OnGameStart;
        public event Action OnGameSuccess;
        public event Action OnGameFail;
        public event Action OnGameComplete;
        public event Action OnGameRestart;
        public event Action<GameState> OnGameStateChanged;

        private GameState _gameState;

        public void GameLoading()
        {
            OnGameLoading?.Invoke();
            ChangeGameState(GameState.Loading);
        }

        public void GameLoaded()
        {
            OnGameWaitForStart?.Invoke();
            ChangeGameState(GameState.WaitForStart);
        }

        public void GameStart()
        {
            OnGameStart?.Invoke();
            ChangeGameState(GameState.Running);
        }

        public void GameSuccess()
        {
            OnGameSuccess?.Invoke();
            ChangeGameState(GameState.Completed);
        }

        public void GameFail()
        {
            OnGameFail?.Invoke();
            ChangeGameState(GameState.Completed);
        }

        public void GameComplete()
        {
            OnGameComplete?.Invoke();
            ChangeGameState(GameState.Completed);
        }

        public void GameRestart()
        {
            OnGameRestart?.Invoke();
            ChangeGameState(GameState.Completed);
        }


        private void ChangeGameState(GameState gameState)
        {
            _gameState = gameState;
            OnGameStateChanged?.Invoke(_gameState);
        }

        public GameState GetGameState()
        {
            return _gameState;
        }
    }

    public enum GameState
    {
        Loading,
        WaitForStart,
        Running,
        Completed
    }
}