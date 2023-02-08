using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleChooseButtons : MonoBehaviour
{
    public void Tennis()
    {
        SceneManager.LoadScene("SingleTennis");
    }

    public void Crusher()
    {
        SceneManager.LoadScene("Crusher");
    }
}
