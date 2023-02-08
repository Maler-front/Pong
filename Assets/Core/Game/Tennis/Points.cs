using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : IGameListener
{
    private Text _text;
    private int _points = 0;

    private void Awake()
    {
        _text = GetComponent<Text>();
        _text.text = _points.ToString();
        Debug.Log(_text.text);
    }

    public void AddPoint()
    {
        _points++;
        _text.text = _points.ToString();
    }

    public override void GameStarted()
    {
        _points = 0;
    }

    public override void GameStopped()
    {
        _points = 0;
        _text.text = _points.ToString();
    }
}
