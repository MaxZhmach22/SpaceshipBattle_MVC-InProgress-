using System;
using UnityEngine;

namespace HellicopterGame
{
    [CreateAssetMenu(fileName = "Example", menuName = "Data/Weapon/Example")]
    public class ExampleChangeWeaponData : ScriptableObject
    {
        public Action<int> OnWeaponBonusUp;
        [SerializeField] private int weapon = 2;

        public int Weapon => weapon;
    }
}