using System.Collections;
using System.Collections.Generic;
using HellicopterGame;
using UnityEngine;

public class BackgroundMainImage : IInitialization
{
    private Sprite _dataSpriteBackgound;
    private GameObject _planeSprite;
    private Vector3 _offset;
    private GameObject _spriteGameObject;
    private float _scale;

    public BackgroundMainImage(MainData data)
    {
        _dataSpriteBackgound = data.LevelBackground.Background;
        _offset = data.LevelBackground.OffsetBackgound;
        _scale = data.LevelBackground.ScaleBackround;
        InitImage();
    }
    
    public void Initialization()
    {
    }

    public void InitImage()
    {
        _spriteGameObject = new GameObject("Backgorund Image");
        SpriteRenderer renderer = _spriteGameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = _dataSpriteBackgound;
        renderer.flipX = true;
        _spriteGameObject.transform.position = _offset;
        _spriteGameObject.transform.localScale = new Vector3(_scale, _scale, 1);
    }

    public Transform GetBackgroundImage()
    {
        return _spriteGameObject.transform;
    }
}
