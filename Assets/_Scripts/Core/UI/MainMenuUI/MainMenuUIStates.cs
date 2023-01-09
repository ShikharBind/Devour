using UnityEngine.UI;
using UnityEngine;
using System;

namespace GameDev.Core
{
    public class MainMenuUIStates
    {
        public abstract class BaseState : MainMenuUIFSM.IMainMenuState
        {
            private string m_name;
            protected MainMenuUIFSM m_stateMachine;
            protected Button m_entryButton, m_backButton;
            protected GameObject m_UIPanel;
            public string StateName
            {
                get { return m_name; }
            }

            public MainMenuUIFSM StateMachine
            {
                get { return m_stateMachine; }
            }

            public BaseState(string a_name, MainMenuUIFSM a_stateMachine, GameObject a_UIPanel,
                                             Button a_entryButton = null, Button a_backButton = null)
            {
                m_name = a_name;
                m_stateMachine = a_stateMachine;
                m_UIPanel = a_UIPanel;
            }



            public void OnEnter()
            {
                m_UIPanel.SetActive(true);
            }
            public void OnUpdate() { }
            public void OnExit()
            {
                m_UIPanel.SetActive(false);
            }
        }
        public class MainState : BaseState
        {
            public MainState(MainMenuUIFSM a_stateMachine, GameObject a_UIPanel) : base("main", a_stateMachine, a_UIPanel) { }
        }

        public class LevelsState : BaseState
        {
            public LevelsState(MainMenuUIFSM a_stateMachine, GameObject a_UIPanel, Button a_entryButton, Button a_backButton)
             : base("levels", a_stateMachine, a_UIPanel)
            {
                m_entryButton = a_entryButton;
                m_entryButton.onClick.AddListener(OnButtonPressed);
                m_backButton = a_backButton;
                m_backButton.onClick.AddListener(OnBack);
            }
            
            public void OnButtonPressed()
            {
                m_stateMachine.ChangeState(m_stateMachine.components.levelsState);
            }

            public void OnBack()
            {
                m_stateMachine.ChangeState(m_stateMachine.components.mainState);
            }
        }

        public class InfoState : BaseState
        {
            public InfoState(MainMenuUIFSM a_stateMachine, GameObject a_UIPanel, Button a_entryButton, Button a_backButton)
             : base("info", a_stateMachine, a_UIPanel, a_backButton, a_backButton)
            {
                m_entryButton = a_entryButton;
                m_entryButton.onClick.AddListener(OnButtonPressed);
                m_backButton = a_backButton;
                m_backButton.onClick.AddListener(OnBack);
            }
            
            public void OnButtonPressed()
            {
                m_stateMachine.ChangeState(m_stateMachine.components.infoState);
            }

            public void OnBack()
            {
                m_stateMachine.ChangeState(m_stateMachine.components.mainState);
            }
        }

        public class CreditsState : BaseState
        {
            public CreditsState(MainMenuUIFSM a_stateMachine, GameObject a_UIPanel, Button a_entryButton, Button a_backButton)
             : base("credits", a_stateMachine, a_UIPanel, a_backButton, a_backButton)
            {
                m_entryButton = a_entryButton;
                m_entryButton.onClick.AddListener(OnButtonPressed);
                m_backButton = a_backButton;
                m_backButton.onClick.AddListener(OnBack);
            }
            
            public void OnButtonPressed()
            {
                m_stateMachine.ChangeState(m_stateMachine.components.creditsState);
            }

            public void OnBack()
            {
                m_stateMachine.ChangeState(m_stateMachine.components.mainState);
            }
        }
    }
}