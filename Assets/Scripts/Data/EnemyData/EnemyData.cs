using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{

    [SerializeField] private GameObject _enemyProjectile;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _timerForShoot;
    [SerializeField] private float _amplitude;
    [SerializeField] private float _offset;
    [SerializeField] private float _distanceOpenFire;


    public float Speed => _enemySpeed;
    public float TimerForShoot => _timerForShoot;

    public float Amplitude => _amplitude;

    
    public float Offset => _offset;

    public GameObject EnemyProjectile => _enemyProjectile;

    public float DistanceOpenFire => _distanceOpenFire;
}
