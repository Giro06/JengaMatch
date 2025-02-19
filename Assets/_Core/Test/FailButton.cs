using UnityEngine;

namespace Giroo.Core.Test
{
    public class FailButton : MonoBehaviour
    {
        public void Fail()
        {
            Game.gameManager.GameFail();
        }
    }
}