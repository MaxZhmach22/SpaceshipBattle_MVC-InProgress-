using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HellicopterGame
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private Data _data;
        private Controllers _controllers;

        void Start()
        {
            _controllers = new Controllers();
            new GameInitialization(_controllers, _data);
            _controllers.Initialization();
        }
        
        private void Update()
        {
            var deltaTime = Time.deltaTime; //Переменная deltatime высчитывается один раз что бы передать во все контроллеры одно и тоже значение.
            _controllers.Execute(deltaTime);
        }
    }

}


