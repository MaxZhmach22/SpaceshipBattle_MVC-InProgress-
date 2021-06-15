using UnityEngine;

namespace HellicopterGame
{
    class ConverterFromJSON : MonoBehaviour
    {
        public UnitList unitList = new UnitList();
        
        private void Start()
        {
            unitList = JsonUtility.FromJson<UnitList>(Resources.Load("JSONtext").ToString());
            IFactory factoryMag = new UnitFactoryMag();
            IFactory factoryInfantry = new UnitFactoryInfantry();
            FactoryMerger factoryMerger = new FactoryMerger();
            factoryMerger.AddFactory(factoryMag);
            factoryMerger.AddFactory(factoryInfantry);
            factoryMerger.CreateObj(unitList);

        }

    }
}
