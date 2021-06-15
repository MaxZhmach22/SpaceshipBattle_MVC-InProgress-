using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HellicopterGame
{
  [Serializable]
      public class Unit
      {
        public string type;
        public int health;
      }

    [Serializable]
    public class UnitList
    {
        public Unit[] unit;
    }
        
}
