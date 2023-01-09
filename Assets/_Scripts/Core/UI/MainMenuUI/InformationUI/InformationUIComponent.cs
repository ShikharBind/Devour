using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using GameDev.Architecture;

namespace GameDev.Core
{
    public class InformationUIComponent : MonoBehaviour
    {
        [Serializable]
        public struct Configuration : IConfiguration
        {
            public InformationUIConfiguration informationUIConfiguration;
            // [ValueReference]
            // public PlayerConfiguration playerConfigurationn;
        }

        [Serializable]
        public struct Reference : IReference
        {
            public InformationUI.Reference informationReference;
        }

        public class State : IState
        {

        }

        public class Components : IComponents
        {
            public InformationUI informationUI;
        }

        public Configuration configuration;
        public Reference reference;
        public State state { get; private set; }
        public Components components { get; private set; }

        public void SetConfiguration(Configuration a_configuration)
        {
            this.configuration = a_configuration;
            // components.player.SetConfiguration(configuration.playerConfigurationn.configuration);
        }

        private void Awake()
        {
            this.state = new State();
            this.components = new Components();
            components.informationUI = new InformationUI(configuration.informationUIConfiguration.configuration, reference.informationReference);
        }

        private void Start()
        {
            components.informationUI.Enable();
        }

        private void Update()
        {
            // UpdateConfiguration();
            components.informationUI.Update();
        }

        private void UpdateConfiguration()
        {
            SetConfiguration(configuration);
        }
    }
}
