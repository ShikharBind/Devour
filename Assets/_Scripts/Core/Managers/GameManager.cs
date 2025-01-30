using System;
using System.Collections.Generic;
using UnityEngine;
using GameDev.Common;
using GameDev.Architecture;

namespace GameDev.Core
{
    /// <summary>
    /// Nice, easy to understand enum-based game manager. For larger and more complex games, look into
    /// state machines. But this will serve just fine for most games.
    /// </summary>
    public class GameManager
    {
        [Serializable]
        public struct Configuration : IConfiguration
        {
            public GameManagerFSMConfiguration fsmConfiguration;
            public EnemyManagerConfiguration enemyManagerConfiguration;
        }

        [Serializable]
        public struct Reference : IReference
        {
            public GameManagerFSM.Reference fsmReference;
            // public EnemyManager.Reference enemyManagerReference;
        }

        public class State : IState { 

        }

        public class Components : IComponents
        {
            public GameManagerFSM fsm;
            public FoodSelectionSystem foodSelectionSystem;
            public EnemyManager enemyManager;
            public ProgressSaver progressSaver;
        }

        public Configuration configuration;
        public Reference reference;
        public State state { get; private set; }
        public Components components { get; private set; }

        public GameManager(Configuration a_configuration = default, Reference a_reference = default)
        {
            this.configuration = a_configuration;
            this.reference = a_reference;
            this.state = new State();
            this.components = new Components();

            components.fsm = new GameManagerFSM(configuration.fsmConfiguration.configuration, reference.fsmReference);
            components.foodSelectionSystem = new FoodSelectionSystem();
            components.progressSaver = new ProgressSaver();
            
            EnemyManager.Reference enemyManagerReference = new EnemyManager.Reference();
            enemyManagerReference.unitManager = UnitManager.Instance;
            enemyManagerReference.levelSystem = LevelSystem.Instance;
            components.enemyManager = new EnemyManager(configuration.enemyManagerConfiguration.configuration, enemyManagerReference);
        }

        public void SetConfiguration(Configuration a_configuration)
        {
            this.configuration = a_configuration;
        }

        public void Enable()
        {
            components.fsm.Enable();
        }

        public void Disable()
        {
            // components.input.Disable();
        }

        public void Update()
        {
            components.fsm.Update();
        }
    }
}