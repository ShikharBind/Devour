using UnityEngine;

namespace GameDev.Core
{
    [UnityEngine.CreateAssetMenuAttribute(fileName = GameManagerInfo.Configuration.FileName.GAMEMANAGER, menuName = GameManagerInfo.Configuration.MenuName.GAMEMANAGER)]
    public class GameManagerConfiguration : ScriptableObject
    {
        public GameManager.Configuration configuration;
    }
}