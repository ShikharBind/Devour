using System;
using UnityEngine;
using GameDev.Architecture;
using GameDev.Common;

namespace GameDev.Core
{
    
    public class InformationUI
    {
        [Serializable]
        public struct Configuration : IConfiguration
        {
            // [ValueReference]
            // public PlayerCCConfiguration ccConfiguration;
            public InformationUIFSMConfiguration fsmConfiguration;
            public MainMenuFoodsInfoConfiguration foodsInfoConfiguration;
            public MainMenuEnemiesInfoConfiguration enemiesInfoConfiguration;
        }

        [Serializable]
        public struct Reference : IReference
        {
            public InformationUIFSM.Reference fsmReference;
            public MainMenuFoodsInfo.Reference foodsInfoReference;
            public MainMenuEnemiesInfo.Reference enemiesInfoReference;
        }

        public class State : IState
        {

        }

        public class Components : IComponents
        {
            public InformationUIFSM fsm;
            public MainMenuFoodsInfo foodsInfo;
            public MainMenuEnemiesInfo enemiesInfo;
        }

        public Configuration configuration { get; private set; }
        public Reference reference { get; private set; }
        public State state { get; private set; }
        public Components components { get; private set; }

        public InformationUI(Configuration a_configuration = default, Reference a_reference = default)
        {
            this.configuration = a_configuration;
            this.reference = a_reference;
            this.state = new State();
            this.components = new Components();

            
            components.foodsInfo = new MainMenuFoodsInfo(configuration.foodsInfoConfiguration.configuration, reference.foodsInfoReference);
            components.enemiesInfo = new MainMenuEnemiesInfo(configuration.enemiesInfoConfiguration.configuration, reference.enemiesInfoReference);
            components.fsm = new InformationUIFSM(configuration.fsmConfiguration.configuration, reference.fsmReference);
        }

        public void SetConfiguration(Configuration a_configuration)
        {
            this.configuration = a_configuration;
        }

        public void Enable()
        {
            components.fsm.Enable();
            components.foodsInfo.Enable();
            components.enemiesInfo.Enable();
        }

        public void Disable()
        {
            // components.input.Disable();
        }

        public void Update()
        {
        }
    }
}
