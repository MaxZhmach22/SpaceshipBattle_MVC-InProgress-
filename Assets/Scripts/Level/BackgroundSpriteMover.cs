using System.Collections.Generic;
using UnityEngine;

namespace HellicopterGame
{
    public class BackgroundSpriteMover: IExecute
    {
        private Transform _backroundImage;
        private List<Transform> _starsSprite;
        private float _speedBackground;
        private Vector3 _startStarsPosition;
        private float _speedStars;

        public BackgroundSpriteMover(Transform backgroundImage, List<Transform> starsSprites, float speedBackground, float speedStars)
        {
            _speedBackground = speedBackground;
            _backroundImage = backgroundImage;
            _starsSprite = starsSprites;
            _speedStars = speedStars;
            _startStarsPosition = starsSprites[1].position;
        }
        public void Execute(float deltaTime)
        {
            _backroundImage.RotateAround(_backroundImage.position, Vector3.forward, 0.5f * deltaTime * _speedBackground);
            foreach (var sprite in _starsSprite)
            {
                sprite.transform.Translate(0,-1 * Time.deltaTime * _speedStars,0);
                if (sprite.transform.position.y <= -75)
                {
                    var offset =  new Vector3(0, 25,0);
                    sprite.transform.position = _startStarsPosition + offset;
                }
            }
        }
    }
}