using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Square : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private CrusherLogic _crusherLogic;
    private TextMesh _text;

    private void Start()
    {
        _crusherLogic = FindObjectOfType<CrusherLogic>();
        _health = Convert.ToInt32(UnityEngine.Random.Range(1, 20) * _crusherLogic.k);
        _text = GetComponentInChildren<TextMesh>();
        _text.text = _health.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("CrusherBall"))
        {
            _health -= 1;
            if(_health <= 0)
            {
                Destroy(gameObject);
            }
            _text.text = _health.ToString();
        }
    }
}
