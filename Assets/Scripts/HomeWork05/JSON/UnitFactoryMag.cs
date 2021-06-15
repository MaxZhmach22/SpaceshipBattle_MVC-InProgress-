using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HellicopterGame
{
    public class UnitFactoryMag : IFactory
    {
        private string _name = "mag";

        public string Name => _name;

        public GameObject Create(Unit unit)
        {
            var go = new GameObject(Name);
            go.AddComponent<UnitStats>();
            var unitStatFromJSON = go.GetComponent<UnitStats>();
            unitStatFromJSON.health = unit.health;
            unitStatFromJSON.type = unit.type;
            return go;
        }

    }
}
