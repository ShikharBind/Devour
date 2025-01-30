using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using GameDev.Architecture;

namespace GameDev.Core
{
    public class GameStates
    {
        public abstract class BaseState : GameManagerFSM.IGameState
        {
            private string m_name;
            protected GameManagerFSM m_stateMachine;
            public string StateName
            {
                get { return m_name; }
            }

            public GameManagerFSM StateMachine
            {
                get { return m_stateMachine; }
            }

            public BaseState(string a_name, GameManagerFSM a_stateMachine)
            {
                m_name = a_name;
                m_stateMachine = a_stateMachine;
            }

            public virtual void OnEnter() { }
            public virtual void OnUpdate() { }
            public virtual void OnExit() { }
        }

        public class MainMenu : BaseState
        {
            public struct Reference : IReference
            {

            }
            public MainMenu(GameManagerFSM a_stateMachine) : base("mainmenu", a_stateMachine) { }
            public override void OnEnter()
            {
                base.OnEnter();
                SceneManager.LoadScene("MainMenuScene");
            }
        }

        public class FoodSelection : BaseState
        {
            public FoodSelection(GameManagerFSM a_stateMachine) : base("foodSelection", a_stateMachine) { }
            public override void OnEnter()
            {
                base.OnEnter();
                SceneManager.LoadScene("FoodSelectionScene");
            }
        }

        public class StartGame : BaseState
        {
            // Do some start setup, could be environment, cinematics etc
            // Eventually call ChangeState again with your next state
            public StartGame(GameManagerFSM a_stateMachine) : base("startGame", a_stateMachine) { }
            public override void OnEnter()
            {
                base.OnEnter();
                m_stateMachine.ChangeState(m_stateMachine.states.inGame);
            }
        }

        public class InGame : BaseState
        {
            public InGame(GameManagerFSM a_stateMachine) : base("inGame", a_stateMachine) { }
        }

        public class Win : BaseState
        {
            public Win(GameManagerFSM a_stateMachine) : base("Win", a_stateMachine) { }
        }

        public class Lose : BaseState
        {
            public Lose(GameManagerFSM a_stateMachine) : base("lose", a_stateMachine) { }
        }

        public class Pause : BaseState
        {
            public Pause(GameManagerFSM a_stateMachine) : base("pause", a_stateMachine) { }
        }

        // public class LevelsState : BaseState
        // {
        //     public LevelsState(GameManagerFSM a_stateMachine, GameObject a_UIPanel, Button a_entryButton, Button a_backButton)
        //      : base("levels", a_stateMachine, a_UIPanel)
        //     {
        //         m_entryButton = a_entryButton;
        //         m_entryButton.onClick.AddListener(OnButtonPressed);
        //         m_backButton = a_backButton;
        //         m_backButton.onClick.AddListener(OnBack);
        //     }

        //     public void OnButtonPressed()
        //     {
        //         m_stateMachine.ChangeState(m_stateMachine.components.levelsState);
        //     }

        //     public void OnBack()
        //     {
        //         m_stateMachine.ChangeState(m_stateMachine.components.mainState);
        //     }
        // }
    }
}