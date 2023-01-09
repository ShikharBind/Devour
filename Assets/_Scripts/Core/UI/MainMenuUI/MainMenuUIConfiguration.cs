using UnityEngine;

namespace GameDev.Core
{
    [UnityEngine.CreateAssetMenuAttribute(fileName = MainMenuUIInfo.Configuration.FileName.MAINMENUUI, menuName = MainMenuUIInfo.Configuration.MenuName.MAINMENUUI)]
    public class MainMenuUIConfiguration : ScriptableObject
    {
        public MainMenuUI.Configuration configuration;
    }
}