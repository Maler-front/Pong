using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Field : IGameListener
{
    [SerializeField] private float _secondsForRow = 30f;
    [SerializeField] private CrusherLogic _crusherLogic;
    [SerializeField] private GameObject _square;
    [SerializeField] private GameObject _row;
    [SerializeField] private GameController _gameController;

    private Coroutine _coroutine;

    void Start()
    {
        GameStopped();
    }

    private IEnumerator Game()
    {
        while (true)
        {
            CreateRow();

            if (IsPlayerFailed())
            {
                _gameController.GameStatusChange();
            }

            yield return new WaitForSeconds(_secondsForRow);
        }
    }

    private void CreateRow()
    {
        GameObject row = Instantiate(_row, new Vector3(0, 4.5f), Quaternion.Euler(0, 0, 0), transform);
        row.transform.name = "Row";

        int[] rowData = _crusherLogic.CreateRow();

        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            child.transform.Translate(0, -1, 0);
            Debug.Log(child.transform.name);
        }

        for (int i = 0; i < rowData.Length; i++)
        {
            if(rowData[i] == 1)
            {
                GameObject square = Instantiate(_square, new Vector3(i - rowData.Length / 2, 4.5f), Quaternion.Euler(0, 0, 0), row.transform);
                square.transform.name = "Square";
            }
        }
    }

    private bool IsPlayerFailed() {
        if(transform.childCount != 0)
        {
            var lastRow = transform.GetChild(0);
            if (lastRow.childCount == 0)
            {
                Destroy(lastRow.gameObject);
            }
            else
            {
                if (lastRow.position.y <= -1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override void GameStopped()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public override void GameStarted()
    {
        _coroutine = StartCoroutine(Game());
    }
}
