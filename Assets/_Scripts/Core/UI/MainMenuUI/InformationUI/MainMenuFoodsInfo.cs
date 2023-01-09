using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameDev.Architecture;

namespace GameDev.Core
{
    
    public class MainMenuFoodsInfo
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

        public MainMenuFoodsInfo(Configuration a_configuration = default, Reference a_reference = default)
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
            CreateFoods();
        }
        
        
        private void CreateFoods()
        {
            reference.template.gameObject.SetActive(false);
            List<ScriptableHero> Heroes = ResourceSystem.Instance.Heroes;
            List<Transform> FoodTransformList = new List<Transform>();

            foreach (ScriptableHero Hero in Heroes)
            {
                Transform foodTransform = CreateTransform(reference.template, reference.container, FoodTransformList);
                CreateData(Hero, foodTransform);
            }

            ShowStats(ResourceSystem.Instance.Heroes[0]);
        }

        private Transform CreateTransform(Transform template, Transform container, List<Transform> transformList)
        {
            float templateWidth = 150f;
            Transform entryTransform = UnityEngine.Object.Instantiate(template, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            int numberToStartNewLine = 5;
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

        private void CreateData(ScriptableHero Hero, Transform foodTransform)
        {
            foodTransform.GetComponent<Image>().sprite = Hero.MenuSprite;
            foodTransform.GetComponent<Button>().onClick.AddListener(() => { ShowStats(Hero); });
        }

        private void ShowStats(ScriptableHero hero)
        {
            reference.statsPanel.Find("Name").GetComponent<Text>().text = hero.name.ToUpper();
            reference.statsPanel.Find("Calorie").GetComponent<Text>().text = hero.calorieValue.ToString();
            reference.statsPanel.Find("Damage").GetComponent<Text>().text = hero.BaseStats.AttackPower.ToString();
            reference.statsPanel.Find("Shots").GetComponent<Text>().text = hero.maxShots.ToString();
            reference.statsPanel.Find("Health").GetComponent<Text>().text = hero.BaseStats.Health.ToString();
            reference.statsPanel.Find("Type").GetComponent<Text>().text = hero.Type.ToUpper();
            reference.statsPanel.gameObject.SetActive(true);
        }
    }
}
