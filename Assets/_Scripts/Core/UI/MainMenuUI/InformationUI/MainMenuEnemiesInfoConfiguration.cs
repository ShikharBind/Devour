using UnityEngine;

namespace GameDev.Core
{
    [UnityEngine.CreateAssetMenuAttribute(fileName = InformationUIInfo.Configuration.FileName.INFORMATIONENEMIES, menuName = InformationUIInfo.Configuration.MenuName.INFORMATIONENEMIES)]
    public class MainMenuEnemiesInfoConfiguration : ScriptableObject
    {
        public MainMenuEnemiesInfo.Configuration configuration;
    }
}