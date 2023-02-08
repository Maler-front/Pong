using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void SingleButton()
    {
        SceneManager.LoadScene("SingleChoose");
    }

    public void MultiplayerButton()
    {
        SceneManager.LoadScene("Multiplayer");
    }

    public void SettingsButton()
    {
        Debug.Log("You pressed Settings button");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
