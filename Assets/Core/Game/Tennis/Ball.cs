using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : IGameListener
{
    [SerializeField] private float _startSpeed = 5f;
    [SerializeField] private float _maximumSpeed = 15f;
    [SerializeField] private Points _leftPoints, _rightPoints;

    private float _currentSpeed;
    private Vector2 _currentDirection;
    private Vector2 _cameraBottomLeft;
    private Vector2 _cameraTopRight;

    public Vector2 currentDirection{get{return _currentDirection;}}

    void Start()
    {
        GameStopped();

        _cameraBottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        _cameraTopRight = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
    }


    void Update()
    {
        if (transform.position.y >= _cameraTopRight.y && _currentDirection.y > 0 || transform.position.y <= _cameraBottomLeft.y && _currentDirection.y < 0)
        {
            _currentDirection.y *= -1;
        }
        else
        {
            if(transform.position.x >= _cameraTopRight.x)
            {
                _leftPoints.AddPoint();
                Reload();
            }
            else
            {
                if(transform.position.x <= _cameraBottomLeft.x)
                {
                    _rightPoints.AddPoint();
                    Reload();
                }
            }
        }

        var direction = Vector2.ClampMagnitude(_currentDirection, _currentSpeed * Time.deltaTime);
        transform.Translate(direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _currentDirection.x *= -1;
        if(_currentSpeed < _maximumSpeed)
        {
            _currentSpeed += 0.5f;
        }
        Debug.Log("Ball speed: " + _currentSpeed);
    }

    private void Reload()
    {
        _currentSpeed = _startSpeed;
        transform.position = new Vector3(0, 0, 0);

        int xDirection, yDirection;
        do
        {
            xDirection = Random.Range(-1000, 1000);
            yDirection = Random.Range(-250, 250);
        } while (Mathf.Abs(xDirection) < 100 || Mathf.Abs(yDirection) < 100);

        _currentDirection = new Vector2(xDirection, yDirection);
        Debug.Log("Ball vector: " + _currentDirection);
    }

    public override void GameStarted()
    {
        Debug.Log("game started");
        Reload();
    }

    public override void GameStopped()
    {
        _currentSpeed = 0;
        _currentDirection = Vector2.ClampMagnitude(_currentDirection, _currentSpeed * Time.deltaTime);
        transform.position = new Vector3(0, 0, 0);
    }
}
