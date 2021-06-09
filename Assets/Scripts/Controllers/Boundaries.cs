using UnityEngine;

namespace HellicopterGame
{
    public class Boundaries
    {
        private Vector2 screenBounds;
        private Camera _camera;

        public Vector2 ScreenBounds => screenBounds;

        public Boundaries(Camera camera)
        {
            _camera = camera;
            screenBounds =
                _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.transform.position.z));
        }
        
    }
}