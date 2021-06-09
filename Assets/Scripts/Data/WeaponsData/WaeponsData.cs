using System;
using System.Collections;
using System.Collections.Generic;
using HellicopterGame;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class WeaponsData : ScriptableObject, IWeapon
{
    public event Action<float> OnDamageTaken;
    public event Action<string> OnBonusTaken;
    [SerializeField] private GameObject _prefab; 
    [SerializeField] private float _damage;
    [SerializeField] private string _name;
    [Range(10, 100)] [SerializeField] private float _fireSpeed;

    public GameObject Prefab => _prefab;

    public float Damage
    {
        get { return _damage;}
        set { _damage = value;}
    }

    public string Name
    {
        get { return _name;}
        set { _name = value; }
    }

    public float FireSpeed
    {
        get { return _fireSpeed;}  set{ _fireSpeed = value;} }
    
    public virtual void TakeDamage()
    {
        OnDamageTaken?.Invoke(Damage);
    }

    public void BonusTaken(string nameOfBonus)
    {
        OnBonusTaken?.Invoke(nameOfBonus);
    }
    
}
