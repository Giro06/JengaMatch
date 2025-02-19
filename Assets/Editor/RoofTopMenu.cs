using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Giroo.Core.Editor
{
    public static class RoofTopMenu
    {
        [UnityEditor.MenuItem("RoofTop Games/ClearPlayerPrefs %#D")]
        static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }

        [UnityEditor.MenuItem("RoofTop Games/Set FPS/60")]
        static void FPS60()
        {
            Application.targetFrameRate = 60;
        }

        [UnityEditor.MenuItem("RoofTop Games/Set FPS/30")]
        static void FPS30()
        {
            Application.targetFrameRate = 30;
        }

        [UnityEditor.MenuItem("RoofTop Games/Set FPS/15")]
        static void FPS15()
        {
            Application.targetFrameRate = 15;
        }
    }
}