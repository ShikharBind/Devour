using System;
using UnityEngine;
using GameDev.Architecture;
using GameDev.Common;

namespace GameDev.Core
{

    public class MainMenuUI
    {
        [Serializable]
        public struct Configuration : IConfiguration
        {
            // [ValueReference]
            // public PlayerCCConfiguration ccConfiguration;
            public MainMenuUIFSMConfiguration fsmConfiguration;
        }

        [Serializable]
        public struct Reference : IReference
        {
            public MainMenuUIFSM.Reference fsmReference;
        }

        public class State : IState
        {

        }

        public class Components : IComponents
        {
            public MainMenuUIFSM fsm;
        }

        public Configuration configuration { get; private set; }
        public Reference reference { get; private set; }
        public State state { get; private set; }
        public Components components { get; private set; }

        public MainMenuUI(Configuration a_configuration = default, Reference a_reference = default)
        {
            this.configuration = a_configuration;
            this.reference = a_reference;
            this.state = new State();
            this.components = new Components();

            components.fsm = new MainMenuUIFSM(configuration.fsmConfiguration.configuration, reference.fsmReference);
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

        public void Update() { }
    }
}
