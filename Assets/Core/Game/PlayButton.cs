using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : IGameListener
{
    [SerializeField] private Vector2 _stoppedPosition = new Vector2(0, 0);
    [SerializeField] private Vector2 _startedPosition = new Vector2(8, 4);
    [SerializeField] private Sprite _stoppedSprite;
    [SerializeField] private Sprite _startedSprite;


    public override void GameStarted()
    {
        transform.position = _startedPosition;

        var image = GetComponent<Image>();
        image.sprite = _startedSprite;
    }

    public override void GameStopped()
    {
        transform.position = _stoppedPosition;

        var image = GetComponent<Image>();
        image.sprite = _stoppedSprite;
    }
}
