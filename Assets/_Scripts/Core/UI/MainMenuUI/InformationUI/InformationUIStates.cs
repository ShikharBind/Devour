using UnityEngine.UI;
using UnityEngine;
using System;

namespace GameDev.Core
{
    public class InformationUIStates
    {
        public abstract class BaseState : InformationUIFSM.IInformationState
        {
            private string m_name;
            protected InformationUIFSM m_stateMachine;
            protected GameObject m_UIPanel, m_Button;
            public string StateName
            {
                get { return m_name; }
            }

            public InformationUIFSM StateMachine
            {
                get { return m_stateMachine; }
            }

            public BaseState(string a_name, InformationUIFSM a_stateMachine, GameObject a_UIPanel, GameObject a_Button)
            {
                m_name = a_name;
                m_stateMachine = a_stateMachine;
                m_UIPanel = a_UIPanel;
                m_Button = a_Button;
            }

            public void OnEnter()
            {
                m_Button.GetComponent<Image>().color = new Color(100f / 255f, 100f / 255f, 100f / 255f, 1);
                m_UIPanel.SetActive(true);
            }
            public void OnUpdate() { }
            public void OnExit()
            {
                m_UIPanel.SetActive(false);
                m_Button.GetComponent<Image>().color = Color.white;
            }
        }

        public class InfoState : BaseState
        {
            public InfoState(InformationUIFSM a_stateMachine, GameObject a_UIPanel, GameObject a_Button)
             : base("info", a_stateMachine, a_UIPanel, a_Button)
            {
                a_Button.GetComponent<Button>().onClick.AddListener(OnButtonPressed);
            }
            
            public void OnButtonPressed()
            {
                m_stateMachine.ChangeState(m_stateMachine.components.infoState);
            }
        }

        public class FoodsState : BaseState
        {
            public FoodsState(InformationUIFSM a_stateMachine, GameObject a_UIPanel, GameObject a_Button)
             : base("foods", a_stateMachine, a_UIPanel, a_Button)
            {
                a_Button.GetComponent<Button>().onClick.AddListener(OnButtonPressed);
            }
            
            public void OnButtonPressed()
            {
                m_stateMachine.ChangeState(m_stateMachine.components.foodsState);
            }
        }

        public class EnemiesState : BaseState
        {
            public EnemiesState(InformationUIFSM a_stateMachine, GameObject a_UIPanel, GameObject a_Button)
             : base("enemies", a_stateMachine, a_UIPanel, a_Button)
            {
                a_Button.GetComponent<Button>().onClick.AddListener(OnButtonPressed);
            }
            
            public void OnButtonPressed()
            {
                m_stateMachine.ChangeState(m_stateMachine.components.enemiesState);
            }
        }
    }
}