using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool gameStarted{get; set;}
    [SerializeField] private IGameListener[] _objects;

    void Start()
    {
        gameStarted = false;
    }

    void Update()
    {
        if (gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameStatusChange();
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                GameStatusChange();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void GameStatusChange()
    {
        Debug.Log("Game started: " + gameStarted);
        gameStarted = !gameStarted;

        if (gameStarted)
        {
            foreach(IGameListener item in _objects)
            {
                item.GameStarted();
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
