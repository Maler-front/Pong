using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankCrusher : IGameListener
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Vector2 _startPosition;

    private float _currentSpeed;
    private float _minimumX, _maximumX;

    private void Start()
    {
        var leftBottom = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        var rightTop = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));

        _minimumX = leftBottom.x;
        _maximumX = rightTop.x;

        GameStopped();
    }

    void Update()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * _currentSpeed * Time.deltaTime, 0));

        if(transform.position.x <= _minimumX)
        {
            transform.position = new Vector3(_minimumX, _startPosition.y, 0);
        }
        else
        {
            if (transform.position.x >= _maximumX)
            {
                transform.position = new Vector3(_maximumX, _startPosition.y, 0);
            }
        }
    }

    public override void GameStopped()
    {
        transform.position = _startPosition;
        _currentSpeed = 0f;
    }

    public override void GameStarted()
    {
        _currentSpeed = _speed;
    }
}
