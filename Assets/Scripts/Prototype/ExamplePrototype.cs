using System;
using UnityEngine;

namespace HellicopterGame.Prototype
{
    public class ExamplePrototype : MonoBehaviour
    {
        private void Start()
        {
            SomeBonus bonus = new SomeBonus(new Fuel(100));
            var bonusCope = bonus.DeepCopy();
            bonusCope._fuel.Fuel1 = 120;
            
            Debug.Log(bonus._fuel.Fuel1.ToString());
            Debug.Log(bonusCope._fuel.Fuel1.ToString());
            

        }
    }
}