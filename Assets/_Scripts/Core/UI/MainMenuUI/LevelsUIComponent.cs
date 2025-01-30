using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameDev.Core
{
    public class LevelsUIComponent : MonoBehaviour
    {
        public void SetLevel(int a_levelNumber)
        {
            LevelSystem.Instance.SetLevel(a_levelNumber);
            SceneManager.LoadScene("FoodSelectionScene");
        }
    }
}
