using System.Collections.Generic;
using UnityEngine;

namespace HellicopterGame
{
    public class BackgroundDynamicStars : IInitialization
    {
        private Sprite _spriteStars;
        private List<Sprite> _sprites;
        private List<Vector3> _spritePosition;
        private Vector3 _startPosition;
        private float _scale;
        private List<GameObject> _spriteGameObject;

        public BackgroundDynamicStars(LevelBackground data)
        {
            _sprites = data.MovingStars;
            _spriteGameObject = new List<GameObject>();
            _startPosition = data.OffsetSmallStars;
            _scale = data.ScaleSmallstars;
            InitImage();
        }

        private void InitImage()
        {
            for (int i = 0; i < _sprites.Count; i++)
            {
                _spriteGameObject.Add(new GameObject("Stars" + i));
                SpriteRenderer renderer = _spriteGameObject[i].AddComponent<SpriteRenderer>();
                renderer.sprite = _sprites[i];
                if(i%2 ==0) renderer.flipX = true;
                Color rendererColor = renderer.color;
                rendererColor.a = 0.56f;
                renderer.color = rendererColor;
                var offset = new Vector3(0,i * 100,0); // 100 - ширина спрайта
                _spriteGameObject[i].transform.position = _startPosition + offset;
                _spriteGameObject[i].transform.localScale = new Vector3(_scale, _scale, 1);
            }
        }

        public void Initialization()
        {
        }
        
        public List<Transform> GetBackgroundStars()
        {
            var spritesTransform = new List<Transform>();
            foreach (var sprites in _spriteGameObject)
            {
                spritesTransform.Add(sprites.transform);
            }

            return spritesTransform;
        }
        
    }
}