using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameDev.Architecture;

namespace GameDev.Core
{
    
    public class MainMenuEnemiesInfo
    {
        [Serializable]
        public struct Configuration : IConfiguration
        {
            // [ValueReference]
            // public PlayerCCConfiguration ccConfiguration;
        }

        [Serializable]
        public struct Reference : IReference
        {
            public Transform container, template, statsPanel;
        }

        public class State : IState
        {

        }

        public class Components : IComponents
        {
            
        }

        public Configuration configuration { get; private set; }
        public Reference reference { get; private set; }
        public State state { get; private set; }
        public Components components { get; private set; }

        public MainMenuEnemiesInfo(Configuration a_configuration = default, Reference a_reference = default)
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
            CreateEnemies();
        }

        private void CreateEnemies()
        {
            reference.template.gameObject.SetActive(false);
            List<ScriptableEnemy> Enemies = ResourceSystem.Instance.Enemies;
            List<Transform> EnemyTransformList = new List<Transform>();

            foreach (ScriptableEnemy enemy in Enemies)
            {
                Transform enemyTransform = CreateTransform(reference.template, reference.container, EnemyTransformList);
                CreateData(enemy, enemyTransform);
            }

            ShowStats(ResourceSystem.Instance.Enemies[0]);
        }

        private Transform CreateTransform(Transform template, Transform container, List<Transform> transformList)
        {
            float templateWidth = 250f;
            Transform entryTransform = UnityEngine.Object.Instantiate(template, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            int numberToStartNewLine = 3;
            if (transformList.Count < numberToStartNewLine)
            {
                entryRectTransform.anchoredPosition =
                    new Vector2(templateWidth * transformList.Count, 0);
            }
            else
            {
                entryRectTransform.anchoredPosition =
                    new Vector2(templateWidth * (transformList.Count - numberToStartNewLine), -250);
            }
            entryTransform.gameObject.SetActive(true);

            transformList.Add(entryTransform);
            return entryTransform;
        }

        private void CreateData(ScriptableEnemy enemy, Transform foodTransform)
        {
            foodTransform.GetComponent<Animator>().runtimeAnimatorController = enemy.animator;
            foodTransform.GetComponent<Button>().onClick.AddListener(() => { ShowStats(enemy); });
        }

        private void ShowStats(ScriptableEnemy enemy)
        {
            reference.statsPanel.Find("Name").GetComponent<Text>().text = enemy.name.ToUpper();
            reference.statsPanel.Find("Damage").GetComponent<Text>().text = enemy.BaseStats.AttackPower.ToString();
            reference.statsPanel.Find("Speed").GetComponent<Text>().text = enemy.BaseStats.Speed.ToString();
            reference.statsPanel.Find("Health").GetComponent<Text>().text = enemy.BaseStats.Health.ToString();
            reference.statsPanel.gameObject.SetActive(true);
        }
    }
}
