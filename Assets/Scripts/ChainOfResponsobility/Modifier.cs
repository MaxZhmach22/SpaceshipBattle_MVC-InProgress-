using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier
{
    private Transform _player;
    private Modifier Next;

    public Modifier(Transform player)
    {
        _player = player;
    }

    public void Add(Modifier modifier)
    {
        if(Next!= null)
        {
            Next.Add(modifier);
        }
        else
        {
            Next = modifier;
        }
    }

    public virtual void Handler() => Next?.Handler();
}
