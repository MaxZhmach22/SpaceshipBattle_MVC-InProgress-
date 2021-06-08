using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace HellicopterGame
{
    [CreateAssetMenu(fileName = "LevelBackground", menuName = "Data/Level/BackGround")]
    public class LevelBackground : ScriptableObject
    {
        [SerializeField] private Sprite _background;
        [SerializeField] private List<Sprite> _movingStars;
        [SerializeField] private Sprite _staticStars;

        [Range(1, 10)] [SerializeField] private float _speedBackground;
        [Range(1, 10)] [SerializeField] private float _speedSmallStars;

        [SerializeField] private Vector3 _offsetBackgound;
        [SerializeField] private Vector3 _offsetSmallStars;
        [FormerlySerializedAs("_offsetBigStars")] [SerializeField] private Vector3 offsetStaticStars;

        [SerializeField] private float _scaleBackround;
        [SerializeField] private float _scaleSmallstars;
        [SerializeField] private float _scaleBigStars;

        public Sprite Background => _background;

        public List<Sprite> MovingStars => _movingStars;

        public Sprite StaticStars => _staticStars;

        public float SpeedBackground => _speedBackground;

        public float SpeedSmallStars => _speedSmallStars;
        

        public Vector3 OffsetBackgound => _offsetBackgound;

        public Vector3 OffsetSmallStars => _offsetSmallStars;

        public Vector3 OffsetStaticStars => offsetStaticStars;

        public float ScaleBackround => _scaleBackround;

        public float ScaleSmallstars => _scaleSmallstars;

        public float ScaleBigStars => _scaleBigStars;
    }
}
    
