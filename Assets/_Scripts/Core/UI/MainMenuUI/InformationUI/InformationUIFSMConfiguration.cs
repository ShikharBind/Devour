using UnityEngine;

namespace GameDev.Core
{
    [UnityEngine.CreateAssetMenuAttribute(fileName = InformationUIInfo.Configuration.FileName.INFORMATIONUIFSM, menuName = InformationUIInfo.Configuration.MenuName.INFORMATIONUIFSM)]
    public class InformationUIFSMConfiguration : ScriptableObject
    {
        public InformationUIFSM.Configuration configuration;
    }
}