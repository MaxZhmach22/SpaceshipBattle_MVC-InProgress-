using System.Collections;
using System.Collections.Generic;
using HellicopterGame;
using UnityEngine;

public class BackgroundStaticStars : IInitialization
{
    private Sprite _spriteStars;
    private Vector3 _spritePosition;
    private GameObject _spriteGameObject;
    private float _scale;

    public BackgroundStaticStars(LevelBackground data)
    {
        _spriteStars = data.StaticStars;
        _spritePosition = data.OffsetStaticStars;
        _scale = data.ScaleBigStars;
        InitImage();
    }

    private void InitImage()
    {
        _spriteGameObject = new GameObject("Static Stars");
        SpriteRenderer renderer = _spriteGameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = _spriteStars;
        Color rendererColor = renderer.color;
        rendererColor.a = 0.4f;
        renderer.color = rendererColor;
        renderer.sortingOrder = 2;
        _spriteGameObject.transform.position = _spritePosition;
        _spriteGameObject.transform.localScale = new Vector3(_scale, _scale, 1);

    }

    public void Initialization()
    {
    }
    
}
