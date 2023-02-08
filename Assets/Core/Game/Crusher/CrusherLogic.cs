using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherLogic : MonoBehaviour
{
    public float k = 1;
    [SerializeField] private int _length = 16;

    public int[] CreateRow()
    {
        k += 0.1f;

        int[] row = new int[_length];
        for(int i = 0; i < _length; i++)
        {
            row[i] = (Random.Range(0, 2));
            Debug.Log(row[i]);
        }

        return row;
    }
}
