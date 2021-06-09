using System.Collections.Generic;
using UnityEngine;

namespace HellicopterGame
{
    public interface IService
    {
        Dictionary<string, Queue<Enemy>> GetPoolDictionary();
    }

}

