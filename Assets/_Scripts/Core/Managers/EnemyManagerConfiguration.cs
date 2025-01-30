using UnityEngine;

namespace GameDev.Core
{
    [UnityEngine.CreateAssetMenuAttribute(fileName = GameManagerInfo.Configuration.FileName.ENEMYMANAGER, menuName = GameManagerInfo.Configuration.MenuName.ENEMYMANAGER)]
    public class EnemyManagerConfiguration : ScriptableObject
    {
        public EnemyManager.Configuration configuration;
    }
}