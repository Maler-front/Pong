using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankAI : MonoBehaviour
{
    [SerializeField] private float _speed = 6f;
    [SerializeField] private Transform _ball;
    [SerializeField] private Ball _ballComponent;

    void Update()
    {
        if(_ball.position.x > -3 && _ballComponent.currentDirection.x > 0)
        {
            if(_ball.position.y < (transform.position.y))
            {
                transform.Translate(new Vector3(0, -_speed * Time.deltaTime, 0));
            }        

            if(_ball.position.y > (transform.position.y))
            {
                transform.Translate(new Vector3(0, _speed * Time.deltaTime, 0));
            }
        }
        
    }
}
