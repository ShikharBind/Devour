using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using GameDev.Common;
using GameDev.Architecture;

namespace GameDev.Core
{
    public class LevelSystem : StaticInstance<LevelSystem>
    {
        [Serializable]
        public struct Configuration : IConfiguration { }

        [Serializable]
        public struct Reference : IReference
        {
            public ResourceSystem resources;
        }

        public class State : IState
        {
            public int level;
            public int enemyCountinLevel;
            public ScriptableLevel levelData;
            public Dictionary<ScriptableHero, int> foodsInPlateDictionary;
            public Dictionary<ScriptableEnemy, int> enemyCountDictionary;
        }

        public class Components : IComponents
        {

        }

        public Configuration configuration;
        public Reference reference;
        public State state { get; private set; }
        public Components components { get; private set; }

        public void SetConfiguration(Configuration a_configuration)
        {
            this.configuration = a_configuration;
        }

        private void UpdateConfiguration()
        {
            SetConfiguration(configuration);
        }

        protected override void Awake()
        {
            base.Awake();
            reference = new Reference();
            state = new State();
            components = new Components();

            reference.resources = ResourceSystem.Instance;

            // components.mainMenuUI = new MainMenuUI(configuration.mainMenuUIConfiguration.configuration, reference.mainMenuReference);
        }

        private void Start()
        {
            state.level = 0;
            state.foodsInPlateDictionary =  reference.resources.Heroes.ToDictionary(r => r, r => 0);
            state.enemyCountDictionary = reference.resources.Enemies.ToDictionary(r => r, r => 0);
            CreateDefaultPlate();
        }

        // Sets Level and coreesponding level details
        public void SetLevel(int a_newLevel)
        {
            state.level = a_newLevel;
            state.levelData = reference.resources.LevelDictionary[state.level];
            CountEnemies(state.levelData);
            ResetPlate();
        }

        private void CountEnemies(ScriptableLevel levelData)
        {
            state.enemyCountinLevel = 0;
            foreach(ScriptableEnemy enemy in reference.resources.Enemies){
                state.enemyCountDictionary[enemy] = 0;
            }
            foreach (Wave wave in levelData.Waves)
            {
                foreach (EnemyData enemy in wave.WaveData)
                {
                    state.enemyCountDictionary[enemy.Enemy] += enemy.Count;
                    state.enemyCountinLevel += enemy.Count;
                }
            }

            return;
        }

        private void CreateDefaultPlate()
        {
            state.foodsInPlateDictionary[reference.resources.Heroes[0]] += 3;
            state.foodsInPlateDictionary[reference.resources.Heroes[1]] += 2;
            state.foodsInPlateDictionary[reference.resources.Heroes[2]] += 5;
            state.foodsInPlateDictionary[reference.resources.Heroes[8]] += 4;
            state.foodsInPlateDictionary[reference.resources.Heroes[9]] += 3;
        }
        
        private void ResetPlate()
        {
            foreach(ScriptableHero hero in reference.resources.Heroes)
            {
                state.foodsInPlateDictionary[hero] = 0;
            }
        }

        private void ShowPlate()
        {
            foreach(ScriptableHero hero in reference.resources.Heroes)
            {
                Debug.Log(state.foodsInPlateDictionary[hero] + " ");
            }
        }

    }
}
