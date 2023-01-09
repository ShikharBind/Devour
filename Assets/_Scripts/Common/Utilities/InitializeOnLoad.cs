using UnityEngine;

namespace GameDev.Common
{
    //TODO: Initialize systems here
    class InitializeOnLoad
    {
        [RuntimeInitializeOnLoadMethod]
        static void OnRuntimeMethodLoad()
        {
            UnityEngine.Object.Instantiate(Resources.Load("Systems"));
            // Debug.Log("After Scene is loaded and game is running");
        }
    }
}