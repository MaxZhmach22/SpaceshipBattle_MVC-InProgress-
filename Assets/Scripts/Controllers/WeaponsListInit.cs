using System;
using System.Collections.Generic;

namespace HellicopterGame
{
    public class WeaponsListInit
    {
        private List<IWeapon> _weaponsList;
        public WeaponsListInit(MainData data)
        {
            _weaponsList = new List<IWeapon>();
            foreach (var weapon in data.WeaponsList)
            {
                _weaponsList.Add(weapon);
            }
        }

        public List<IWeapon> GetWeaponsList()
        {
            return _weaponsList;
        }
    }
}