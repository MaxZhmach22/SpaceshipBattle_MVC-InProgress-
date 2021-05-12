using System.Collections;
using System.Collections.Generic;
using HellicopterGame;
using UnityEngine;

public class PlaneShift : IExecute, IInitialization
{
    private GameObject _planeSprite;

    public void Execute(float deltaTime)
    {
        _planeSprite.transform.Translate(Vector3.down * deltaTime * 0.5f);
    }

    public void Initialization()
    {
        _planeSprite = GameObject.Find("Earth");
        Debug.Log("asdas");
    }
}
