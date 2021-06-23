using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMass : Modifier
{
    private int _massToAdd;
    private Rigidbody2D _rigidbody2D;
    private Transform _player;

    public AddMass(int massToAdd, Transform player) : base(player)
    {
        _massToAdd = massToAdd;
        _player = player;
        _rigidbody2D = _player.GetComponent<Rigidbody2D>();
       
    }

    public override void Handler()
    {
        _rigidbody2D.mass = _massToAdd;
        Debug.Log(_rigidbody2D.mass);
        base.Handler();
    }
}
