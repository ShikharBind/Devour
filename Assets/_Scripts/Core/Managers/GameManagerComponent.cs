using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameDev.Architecture;
using GameDev.Common;

namespace GameDev.Core
{
    public class GameManagerComponent : PersistentSingleton<GameManagerComponent>
    {
        [Serializable]
        public struct Configuration : IConfiguration
        {
            public GameManagerConfiguration gameManagerConfiguration;
        }

        [Serializable]
        public struct Reference : IReference
        {
            public GameManager.Reference gameManagerReference;
        }

        // public class State : IState { }

        public class Components : IComponents
        {
            public GameManager gameManager;
        }

        public Configuration configuration;
        public Reference reference;
        // public State state { get; private set; }
        public Components components { get; private set; }

        public void SetConfiguration(Configuration a_configuration)
        {
            this.configuration = a_configuration;
        }

        protected override void Awake()
        {
            base.Awake();
            // this.state = new State();
            this.components = new Components();
            components.gameManager = new GameManager(configuration.gameManagerConfiguration.configuration, reference.gameManagerReference);
        }

        private void Start()
        {
            components.gameManager.Enable();
            ////////////////////////////////////////////
            InitializeSpawnSlots();
            ChangeState(GameState.Starting);
            /////////////////////////////////////////////////
        }

        private void Update()
        {
            components.gameManager.Update();
        }

        public static event Action<GameState> OnBeforeStateChanged;
        public static event Action<GameState> OnAfterStateChanged;
        public List<List<bool>> heroSpawnSlots = new List<List<bool>>();
        [HideInInspector]
        public ScriptableHero currentsSelectedHero;

        // [SerializeField] private float timeGapInFire = 1f;

        public GameState State { get; private set; }

        public void ChangeState(GameState newState)
        {
            OnBeforeStateChanged?.Invoke(newState);

            Debug.Log($"New state: {newState}");

            State = newState;
            switch (newState)
            {
                case GameState.Starting:
                    HandleStarting();
                    break;
                case GameState.InGame:
                    break;
                case GameState.Win:
                    break;
                case GameState.Lose:
                    break;
                case GameState.Pause:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            OnAfterStateChanged?.Invoke(newState);
        }

        private void HandleStarting()
        {

            ChangeState(GameState.InGame);
        }

        private void InitializeSpawnSlots()
        {
            for (int i = 0; i < 10; i++)
            {
                heroSpawnSlots.Add(new List<bool>(new bool[5]));
            }
        }
    }


    [Serializable]
    public enum GameState
    {
        Starting = 0,
        InGame = 1,
        Win = 2,
        Lose = 3,
        Pause = 4,
    }
}
