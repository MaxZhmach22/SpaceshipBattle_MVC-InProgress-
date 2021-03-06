using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HellicopterGame
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private MainData _data;
        private Controllers _controllers;
        
        void Start()
        {
            _controllers = new Controllers();
            new GameInitialization(_controllers, _data);
            _controllers.Initialization();
        }
        
        private void Update()
        {
            var deltaTime = Time.deltaTime; 
            _controllers.Execute(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }
    }

}


