using UnityEngine;

namespace HellicopterGame
{
    public interface IFactory
    {
        public string Name { get; }
        public GameObject Create(Unit unit);
    }
}