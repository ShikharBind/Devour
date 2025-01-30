namespace GameDev.Core
{
    public struct GameManagerInfo
    {
        public struct Configuration
        {
            public struct FileName
            {
                public const string GAMEMANAGER = "CONFIG.GameManagerConfiguration.";
                public const string GAMEMANAGERFSM = "CONFIG.GameManagerFSM.";
                public const string ENEMYMANAGER = "CONFIG.EnemyManager.";
            }

            public struct MenuName
            {
                public const string GAMEMANAGER = "Game/GameManager/Configuration";
                public const string GAMEMANAGERFSM = "Game/GameManager/FSM";
                public const string ENEMYMANAGER = "Game/GameManager/EnemyManager";
            }
        }
    }
}