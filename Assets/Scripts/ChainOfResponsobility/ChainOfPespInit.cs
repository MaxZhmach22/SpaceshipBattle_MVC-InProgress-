using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainOfPespInit
{
    private Transform _player;

    public ChainOfPespInit(Transform player)
    {
        _player = player;
        var root = new Modifier(_player);
        root.Add(new AddMass(20, _player));
        root.Add(new AddSizeToShip(new Vector2(10, 10), _player));
        root.Handler();
    }
}
