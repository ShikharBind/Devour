using UnityEngine;

namespace GameDev.Common
{
    public class FSM
    {
        public interface IState
        {
            string StateName { get; }
            void OnEnter() { }
            void OnUpdate() { }
            void OnExit() { }
        }

        public interface IStateMachine
        {
            void Start() { } //set initial state
            void Update() { } //update of current state if not null
            void ChangeState(IState newState) { } // OnExit -> set new state -> OnEter
        }
        public interface IStates { }
    }
}