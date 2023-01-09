using UnityEngine;

namespace GameDev.Core
{
    [UnityEngine.CreateAssetMenuAttribute(fileName = MainMenuUIInfo.Configuration.FileName.MAINMENUUIFSM, menuName = MainMenuUIInfo.Configuration.MenuName.MAINMENUUIFSM)]
    public class MainMenuUIFSMConfiguration : ScriptableObject
    {
        public MainMenuUIFSM.Configuration configuration;
    }
}