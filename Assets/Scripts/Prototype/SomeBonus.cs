using System;
using UnityEngine;

namespace HellicopterGame.Prototype
{
    [Serializable]
    public class SomeBonus
    {
        public Fuel _fuel;
        public int position = 5;

        public SomeBonus(Fuel fuel)
        {
            _fuel = fuel;
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name += _fuel.ToString();
            go.transform.position = new Vector3(0,position,0);
        }


        public void SetPosition()
        {
           
        }
        
    }
}