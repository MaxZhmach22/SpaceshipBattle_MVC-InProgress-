using System;

namespace HellicopterGame.Prototype
{
    [Serializable]
    public class Fuel
    {
        private int _fuel;

        public Fuel(int fuel)
        {
            _fuel = fuel;
        }


        public int Fuel1
        {
            get => _fuel;
            set => _fuel = value;
        }
    }
}