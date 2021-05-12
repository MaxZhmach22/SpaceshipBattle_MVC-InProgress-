using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Level01", menuName = "Data/Level/Level01")]
    public class Level : ScriptableObject
    {
        [SerializeField] private GameObject _gameObject;

        public void CreateObject()
        {
            
            Instantiate(_gameObject, Vector3.zero, Quaternion.identity);

        }

        public GameObject CreateGameObject()
        {
            var gameObject = Instantiate(_gameObject, Vector3.zero, Quaternion.identity);
            return gameObject;
        }
    }