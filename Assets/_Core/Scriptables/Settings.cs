using UnityEngine;

namespace Giroo.Core.Scriptables
{
    [CreateAssetMenu(fileName = "DefaultSettings", menuName = "Core/Settings", order = 0)]
    public class Settings : ScriptableObject
    {
        public int test;
    }
}