using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDev.Common;

namespace GameDev.Core
{
    public class BaseGameState : FSM.IState
    {
        string name;
        public string StateName { get { return name; } }
        public FSM.IStateMachine stateMachine { get; }
        public BaseGameState(string a_name, GameSM a_stateMachine)
        {
            name = a_name;
            stateMachine = a_stateMachine;
        }

        public virtual void OnEnter() { }
        public virtual void OnUpdate() { }
        public virtual void OnExit() { }
    }

    public class exampleState : BaseGameState
    {
        public exampleState(GameSM a_stateMachine) : base("exampleState", a_stateMachine) { }
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}