using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGameListener : MonoBehaviour
{
    abstract public void GameStopped();
    abstract public void GameStarted();
}
