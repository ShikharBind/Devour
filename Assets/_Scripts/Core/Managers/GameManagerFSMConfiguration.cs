using UnityEngine;

namespace GameDev.Core
{
    [UnityEngine.CreateAssetMenuAttribute(fileName = GameManagerInfo.Configuration.FileName.GAMEMANAGERFSM, menuName = GameManagerInfo.Configuration.MenuName.GAMEMANAGERFSM)]
    public class GameManagerFSMConfiguration : ScriptableObject
    {
        public GameManagerFSM.Configuration configuration;
    }
}