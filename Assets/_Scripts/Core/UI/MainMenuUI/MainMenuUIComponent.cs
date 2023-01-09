using UnityEngine;
using System;
using GameDev.Architecture;

namespace GameDev.Core
{
    public class MainMenuUIComponent : MonoBehaviour
    {
        [Serializable]
        public struct Configuration : IConfiguration
        {
            public MainMenuUIConfiguration mainMenuUIConfiguration;
            // [ValueReference]
            // public PlayerConfiguration playerConfigurationn;
        }

        [Serializable]
        public struct Reference : IReference
        {
            public MainMenuUI.Reference mainMenuReference;
        }

        public class State : IState
        {

        }

        public class Components : IComponents
        {
            public MainMenuUI mainMenuUI;
        }

        public Configuration configuration;
        public Reference reference;
        public State state { get; private set; }
        public Components components { get; private set; }

        public void SetConfiguration(Configuration a_configuration)
        {
            this.configuration = a_configuration;
        }

        private void Awake()
        {
            this.state = new State();
            this.components = new Components();
            components.mainMenuUI = new MainMenuUI(configuration.mainMenuUIConfiguration.configuration, reference.mainMenuReference);
        }

        private void Start()
        {
            components.mainMenuUI.Enable();
        }

        private void Update()
        {
            // UpdateConfiguration();
            components.mainMenuUI.Update();
        }

        private void UpdateConfiguration()
        {
            SetConfiguration(configuration);
        }

        
        public void Quit()
        {
            Application.Quit();
        }        
    }
}
