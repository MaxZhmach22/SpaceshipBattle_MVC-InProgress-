using System.Collections.Generic;
using UnityEngine;

namespace HellicopterGame
{
    [CreateAssetMenu(fileName = "LevelsDataTemporary", menuName = "Temporary")]
    public class LDExampleTemporary : ScriptableObject
    {
        public Dictionary<string, int> dictionary = new Dictionary<string, int>();
    }
}