using System;
using UnityEngine;
using GameDev.Architecture;

namespace GameDev.Core
{
    public class ProgressSaver
    {
        [Serializable]
        public struct Configuration : IConfiguration
        {
            
        }

        [Serializable]
        public struct Reference : IReference
        {

        }

        public class State : IState
        {

        }

        public class Components : IComponents
        {

        }

        public Configuration configuration;
        public Reference reference;
        public State state { get; private set; }
        public Components components { get; private set; }

        public ProgressSaver(Configuration a_configuration = default, Reference a_reference = default)
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
            
        }

        public void Disable()
        {
            
        }

        public void Update()
        {
            
        }

    }
}

