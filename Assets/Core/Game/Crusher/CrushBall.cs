using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrushBall : IGameListener
{
    //todo
    //Need to use rigitbody because current collision not realy cool

    [SerializeField] private float _speed = 10f;
    [SerializeField] private GameController _gameController;

    private float _currentSpeed;
    private Vector2 _cameraBottomLeft;
    private Vector2 _cameraTopRight;
    private Vector2 _currentDirection;

    void Start()
    {
        GameStopped();

        _cameraBottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        _cameraTopRight = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
    }

    void Update()
    {
        if (transform.position.x >= _cameraTopRight.x && _currentDirection.x > 0 || transform.position.x <= _cameraBottomLeft.x && _currentDirection.x < 0)
        {
            _currentDirection.x *= -1;
        }
        else
        {
            if (transform.position.y >= _cameraTopRight.y && _currentDirection.y > 0)
            {
                _currentDirection.y *= -1;
            }
            else
            {
                if (transform.position.y <= _cameraBottomLeft.y)
                {
                    _gameController.GameStatusChange();
                }
            }
        }

        var direction = Vector2.ClampMagnitude(_currentDirection, _currentSpeed * Time.deltaTime);
        transform.Translate(direction);
    }

    public override void GameStarted()
    {
        _currentSpeed = _speed;

        int xDirection, yDirection;
        do
        {
            xDirection = Random.Range(-250, 250);
            yDirection = Random.Range(100, 1000);
        } while (Mathf.Abs(xDirection) < 100);

        _currentDirection = new Vector2(xDirection, yDirection);
        Debug.Log("Ball vector: " + _currentDirection);
    }

    public override void GameStopped()
    {
        _currentSpeed = 0;
        _currentDirection = Vector2.ClampMagnitude(_currentDirection, _currentSpeed * Time.deltaTime);
        transform.position = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 ballCenter = transform.position;
        Vector3 otherCenter = collision.transform.position;
        Vector3 otherScale = collision.transform.localScale;

        if (ballCenter.x <= (otherCenter.x - otherScale.x / 2) || ballCenter.x >= (otherCenter.x + otherScale.x / 2))
        {
            _currentDirection.x *= -1;
        }

        if(ballCenter.y <= (otherCenter.y - otherScale.y / 2) || ballCenter.y >= (otherCenter.y + otherScale.y / 2))
        {
            _currentDirection.y *= -1;
        }


        /*if (collision.transform.CompareTag("Plank"))
        {
            
        }*/
    }
}
