using UnityEngine;

namespace GameDev.Core
{
    [UnityEngine.CreateAssetMenuAttribute(fileName = InformationUIInfo.Configuration.FileName.INFORMATIONFOODS, menuName = InformationUIInfo.Configuration.MenuName.INFORMATIONFOODS)]
    public class MainMenuFoodsInfoConfiguration : ScriptableObject
    {
        public MainMenuFoodsInfo.Configuration configuration;
    }
}