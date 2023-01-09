using System;
using UnityEngine;
using UnityEngine.UI;
using GameDev.Architecture;
using GameDev.Common;

namespace GameDev.Core
{
    public class MainMenuUIFSM : FSM.IStateMachine
    {
        public interface IMainMenuState : FSM.IState
        {
            MainMenuUIFSM StateMachine { get; }
        }

        [Serializable]
        public struct Configuration : IConfiguration
        {
            // [ValueReference]
            // public PlayerCCConfiguration ccConfiguration;
        }

        [Serializable]
        public struct Reference : IReference
        {
            [SerializeField]
            public GameObject mainUI, levelsUI, infoUI, creditsUI;
            public Button levelsButton, infoButton, creditsButton, levelsBackButton, infoBackButton, creditsBackButton;
        }

        public class State : IState
        {
            public IMainMenuState currentState;
        }

        public class Components : IComponents
        {
            public MainMenuUIStates.MainState mainState;
            public MainMenuUIStates.LevelsState levelsState;
            public MainMenuUIStates.InfoState infoState;
            public MainMenuUIStates.CreditsState creditsState;
        }

        public Configuration configuration { get; private set; }
        public Reference reference { get; private set; }
        public State state { get; private set; }
        public Components components { get; private set; }

        public MainMenuUIFSM(Configuration a_configuration = default, Reference a_reference = default)
        {
            this.configuration = a_configuration;
            this.reference = a_reference;
            this.state = new State();
            this.components = new Components();

            components.mainState = new MainMenuUIStates.MainState(this, reference.mainUI);
            components.levelsState = new MainMenuUIStates.LevelsState(this, reference.levelsUI, 
                                                                        reference.levelsButton, reference.levelsBackButton);
            components.creditsState = new MainMenuUIStates.CreditsState(this, reference.creditsUI, 
                                                                        reference.creditsButton, reference.creditsBackButton);
            components.infoState = new MainMenuUIStates.InfoState(this, reference.infoUI, 
                                                                        reference.infoButton, reference.infoBackButton);

        }

        public void SetConfiguration(Configuration configuration)
        {
            this.configuration = configuration;
        }


        public void Enable()
        {
            state.currentState = components.mainState;
            if (state.currentState != null) state.currentState.OnEnter();
        }

        public void Disable() { }

        public void Update()
        {
            if (state.currentState != null) state.currentState.OnUpdate();
        }

        public void ChangeState(FSM.IState a_newState)
        {
            state.currentState.OnExit();
            state.currentState = a_newState as IMainMenuState;
            state.currentState.OnEnter();
        }
    }
}
