using UnityEngine;

namespace GameDev.Core
{
    [UnityEngine.CreateAssetMenuAttribute(fileName = InformationUIInfo.Configuration.FileName.INFORMATIONUI, menuName = InformationUIInfo.Configuration.MenuName.INFORMATIONUI)]
    public class InformationUIConfiguration : ScriptableObject
    {
        public InformationUI.Configuration configuration;
    }
}