using System;
using UnityEngine;
using GameDev.Architecture;
using GameDev.Common;

namespace GameDev.Core
{
    public class GameManagerFSM : FSM.IStateMachine
    {
        public interface IGameState : FSM.IState
        {
            GameManagerFSM StateMachine { get; }
        }

        [Serializable]
        public struct Configuration : IConfiguration { }

        [Serializable]
        public struct Reference : IReference { }

        public class State : IState
        {
            public IGameState currentState;
        }

        public class Components : IComponents { }

        public class States : FSM.IStates
        {
            public GameStates.MainMenu mainMenu;
            public GameStates.FoodSelection foodSelection;
            public GameStates.StartGame startGame;
            public GameStates.InGame inGame;
            public GameStates.Win win;
            public GameStates.Lose lose;
            public GameStates.Pause pause;
        }

        public Configuration configuration;
        public Reference reference;
        public State state { get; private set; }
        public Components components { get; private set; }
        public States states { get; private set; }

        public GameManagerFSM(Configuration a_configuration = default, Reference a_reference = default)
        {
            this.configuration = a_configuration;
            this.reference = a_reference;
            this.state = new State();
            this.components = new Components();
            this.states = new States();

            states.mainMenu = new GameStates.MainMenu(this);
            states.foodSelection = new GameStates.FoodSelection(this);
            states.startGame = new GameStates.StartGame(this);
            states.inGame = new GameStates.InGame(this);
            states.win = new GameStates.Win(this);
            states.lose = new GameStates.Lose(this);
            states.pause = new GameStates.Pause(this);

        }

        public void SetConfiguration(Configuration configuration)
        {
            this.configuration = configuration;
        }


        public void Enable()
        {
            state.currentState = states.mainMenu;
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
            state.currentState = a_newState as IGameState;
            state.currentState.OnEnter();
        }
    }
}