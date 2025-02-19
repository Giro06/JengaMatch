using UnityEngine;

namespace Giroo.Core.Test
{
    public class WinButton : MonoBehaviour
    {
        public void Win()
        {
            Game.gameManager.GameSuccess();
        }
    }
}