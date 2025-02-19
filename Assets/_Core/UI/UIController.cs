using System;
using UnityEngine;

namespace Giroo.Core.UI
{
    public class UIController : MonoBehaviour
    {
        public GameObject StartCanvasParent;
        public GameObject InGameCanvasParent;
        public GameObject GameSuccessParent;
        public GameObject GameFailParent;
        
        public void OnEnable()
        {
            CloseCanvas();
        }

        public void Init()
        {
            Game.gameManager.OnGameWaitForStart += OpenStartCanvas;
            Game.gameManager.OnGameStart += OpenInGameCanvas;
            Game.gameManager.OnGameSuccess += OpenGameSuccess;
            Game.gameManager.OnGameFail += OpenGameFail;
        }

        public void GameStartButton()
        {
            Game.gameManager.GameStart();
        }

        public void NextLevelButton()
        {
            Game.gameManager.GameComplete();
        }

        public void RestartLevelButton()
        {
            Game.gameManager.GameRestart();
        }

        public void OpenStartCanvas()
        {
            CloseCanvas();
            StartCanvasParent.SetActive(true);
        }

        public void OpenInGameCanvas()
        {
            CloseCanvas();
            InGameCanvasParent.SetActive(true);
        }

        public void OpenGameSuccess()
        {
            CloseCanvas();
            GameSuccessParent.SetActive(true);
        }

        public void OpenGameFail()
        {
            CloseCanvas();
            GameFailParent.SetActive(true);
        }

        public void CloseCanvas()
        {
            StartCanvasParent.SetActive(false);
            InGameCanvasParent.SetActive(false);
            GameSuccessParent.SetActive(false);
            GameFailParent.SetActive(false);
        }
    }
}