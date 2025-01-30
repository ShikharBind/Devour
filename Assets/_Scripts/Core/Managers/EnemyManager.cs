using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using GameDev.Common;
using GameDev.Architecture;

namespace GameDev.Core
{
    public class EnemyManager
    {
        [Serializable]
        public struct Configuration : IConfiguration
        {
            public float timeBeforeWave;// = 2f;
            public float minTimeGapbwSpawn;// = 1f;
            public float maxTimeGapbwSpawn;// = 5f;
            public int timeGapBetweenWaves;// = 10;
        }

        [Serializable]
        public struct Reference : IReference
        {
            [HideInInspector]
            public UnitManager unitManager;
            [HideInInspector]
            public LevelSystem levelSystem;
        }

        public class State : IState
        {
            public int waveNumber = 0;
        }

        public class Components : IComponents
        {

        }

        public Configuration configuration { get; private set; }
        public Reference reference { get; private set; }
        public State state { get; private set; }
        public Components components { get; private set; }

        public EnemyManager(Configuration a_configuration = default, Reference a_reference = default)
        {
            this.configuration = a_configuration;
            this.reference = a_reference;
            this.state = new State();
            this.components = new Components();
        }

        public void SetConfiguration(Configuration a_configuration)
        {
            this.configuration = a_configuration;
        }

        public void Enable()
        {
            _levelData = reference.levelSystem.state.levelData;
            StartGame();
        }

        public void Disable()
        {

        }

        public void Update()
        {

        }

        private List<Transform> spawnSpots;
        private ScriptableLevel _levelData;
        private List<EnemyData> waveData;
        private List<ScriptableEnemy> currentEnemyList;
        private Dictionary<ScriptableEnemy, int> WaveDataDictionary;
        public Dictionary<ScriptableEnemy, int> livingSpawnedEnemyDictionary;
        

        private async void StartGame()
        {
            await Task.Delay(5000);
            livingSpawnedEnemyDictionary = LevelSystem.Instance.state.enemyCountDictionary;
            int dictionarySize = livingSpawnedEnemyDictionary.Count;
            foreach (ScriptableEnemy enemy in ResourceSystem.Instance.Enemies)
            {
                if (livingSpawnedEnemyDictionary[enemy] <= 0)
                {
                    livingSpawnedEnemyDictionary.Remove(enemy);
                }
            }

            Debug.Log("Game Started");
            for (int i = 0; i < LevelSystem.Instance.state.levelData.Waves.Count; i++)
            {
                await StartWave(_levelData.Waves[i]);
                if (i < (_levelData.Waves.Count - 1))
                {
                    await Task.Delay(configuration.timeGapBetweenWaves*1000);
                    Debug.Log("NextWave");
                }
                else
                {
                    while (livingSpawnedEnemyDictionary.Count > 0)
                    {
                        Debug.Log("living type of enemy: " + livingSpawnedEnemyDictionary.Count);
                        await Task.Delay(1000);
                        Debug.Log("Waiting for end");
                    }
                }
            }

            GameManagerComponent.Instance.ChangeState(GameState.Win);
        }

        private async Task StartWave(Wave wave)
        {
            Debug.Log("Wave Started");
            //Wave Start logic
            state.waveNumber++;
            waveData = wave.WaveData;
            currentEnemyList = new List<ScriptableEnemy>();
            foreach (EnemyData enemyData in waveData)
            {
                currentEnemyList.Add(enemyData.Enemy);
            }

            WaveDataDictionary = waveData.ToDictionary(r => r.Enemy, r => r.Count);
            // Debug.Log(WaveDataDictionary.Count);
            int enemyInThisWaveData = currentEnemyList.Count;
            List<ScriptableEnemy> EnemyToDelete = new List<ScriptableEnemy>();
            for (int i = 0; i < currentEnemyList.Count; i++)
            {
                ScriptableEnemy enemy = currentEnemyList[i];
                if (WaveDataDictionary[enemy] <= 0)
                {
                    WaveDataDictionary.Remove(enemy);
                    EnemyToDelete.Add(enemy);
                }
            }

            foreach (ScriptableEnemy enemy in EnemyToDelete)
            {
                currentEnemyList.Remove(enemy);
            }

            await Task.Delay((int)configuration.timeBeforeWave*1000);


            //In wave logic
            while (WaveDataDictionary.Count > 0)
            {
                // await SpawnEnemy();
            }


            //before Wave End Logic
            //checking if wave finished

            Debug.Log("Wave Ended");
        }

        private async Task SpawnEnemy()
        {
            ScriptableEnemy enemyToSpawn = ChooseEnemy();
            reference.unitManager.SpawnEnemy(enemyToSpawn, ChooseLocation());
            // Debug.Log("EnemySpawned: " + enemyToSpawn.name);
            WaveDataDictionary[enemyToSpawn]--;

            //removing enemy from waveData if its count is zero
            if (WaveDataDictionary[enemyToSpawn] <= 0)
            {
                WaveDataDictionary.Remove(enemyToSpawn);
                currentEnemyList.Remove(enemyToSpawn);
            }

            await Task.Delay((int)ChooseTimeGap()*1000);
        }

        private Vector3 ChooseLocation()
        {
            int random = UnityEngine.Random.Range(0, 100);
            int selected = random % 5;
            Vector3 location = spawnSpots[selected].position;
            return location;
        }

        private float ChooseTimeGap()
        {
            float random = UnityEngine.Random.Range(configuration.minTimeGapbwSpawn, configuration.maxTimeGapbwSpawn);
            return random;
        }

        private ScriptableEnemy ChooseEnemy()
        {
            int random = UnityEngine.Random.Range(0, 100) % currentEnemyList.Count;
            ScriptableEnemy randomEnemy = currentEnemyList[random];
            Debug.Log(randomEnemy);


            return randomEnemy;
        }
    }
}
