using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDev.Common;

namespace GameDev.Core
{
    public class GameSM : MonoBehaviour, FSM.IStateMachine
    {
        private FSM.IState m_currentState;
        public FSM.IState CurrentState {get;}
        public exampleState movedState;

        public void Start(){
            m_currentState = movedState;
            if(m_currentState != null) m_currentState.OnEnter();
        }

        public void Update(){
            if(m_currentState != null) m_currentState.OnUpdate();
        }

        public void ChangeState(FSM.IState a_newState){
            m_currentState.OnExit();
            m_currentState = a_newState;
            m_currentState.OnEnter();
        }
    }
}