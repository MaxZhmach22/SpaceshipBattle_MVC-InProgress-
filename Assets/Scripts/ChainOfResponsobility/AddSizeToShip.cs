using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSizeToShip : Modifier
{
    private Vector2 _sizeToAdd;
    private SpriteRenderer _spriteRenderer;
    private Transform _player;

    public AddSizeToShip(Vector2 sizeToAdd, Transform player) : base(player)
    {
        _sizeToAdd = sizeToAdd;
        _player = player;
        _spriteRenderer = _player.GetComponent<SpriteRenderer>();

    }

    public override void Handler()
    {
        _spriteRenderer.size = _sizeToAdd;
        Debug.Log(_sizeToAdd);
        base.Handler();
    }
}
