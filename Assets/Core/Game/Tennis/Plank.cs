using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : IGameListener
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private KeyCode _upKey;
    [SerializeField] private KeyCode _downKey;
    [SerializeField] private Vector3 _startPosition;

    private float _minimumY, _maximumY, _currentSpeed;

    private void Start()
    {
        _minimumY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
        _maximumY = Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight)).y;

        GameStopped();
    }

    void Update()
    {
        if(Input.GetKey(_upKey) && transform.position.y < _maximumY)
        {
            transform.Translate(new Vector2(0, _currentSpeed * Time.deltaTime));
        }
        else {
            if (Input.GetKey(_downKey) && transform.position.y > _minimumY)
            {
                transform.Translate(new Vector2(0, -_currentSpeed * Time.deltaTime));
            }
        }
    }

    public override void GameStarted()
    {
        _currentSpeed = _speed;
    }

    public override void GameStopped()
    {
        transform.position = _startPosition;
        _currentSpeed = 0;
    }
}
