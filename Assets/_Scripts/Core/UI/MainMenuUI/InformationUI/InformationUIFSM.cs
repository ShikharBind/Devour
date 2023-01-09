using System;
using UnityEngine;
using UnityEngine.UI;
using GameDev.Architecture;
using GameDev.Common;

namespace GameDev.Core
{
    public class InformationUIFSM : FSM.IStateMachine
    {
        public interface IInformationState : FSM.IState
        {
            InformationUIFSM StateMachine { get; }
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
            public GameObject infoPanel, foodsPanel, enemiesPanel, infoButton, foodsButton, enemiesButton;
        }

        public class State : IState
        {
            public IInformationState currentState;
        }

        public class Components : IComponents
        {
            public InformationUIStates.InfoState infoState;
            public InformationUIStates.FoodsState foodsState;
            public InformationUIStates.EnemiesState enemiesState;
        }

        public Configuration configuration { get; private set; }
        public Reference reference { get; private set; }
        public State state { get; private set; }
        public Components components { get; private set; }

        public InformationUIFSM(Configuration a_configuration = default, Reference a_reference = default)
        {
            this.configuration = a_configuration;
            this.reference = a_reference;
            this.state = new State();
            this.components = new Components();
            
            components.infoState = new InformationUIStates.InfoState(this, reference.infoPanel, reference.infoButton);
            components.foodsState = new InformationUIStates.FoodsState(this, reference.foodsPanel, reference.foodsButton);
            components.enemiesState = new InformationUIStates.EnemiesState(this, reference.enemiesPanel, reference.enemiesButton);

        }

        public void SetConfiguration(Configuration configuration)
        {
            this.configuration = configuration;
        }


        public void Enable()
        {
            state.currentState = components.infoState;
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
            state.currentState = a_newState as IInformationState;
            state.currentState.OnEnter();
        }
    }
}
