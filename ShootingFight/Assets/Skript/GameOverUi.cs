using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUi : MonoBehaviour
{
    public void RetryGame()
    {
        SceneMover.instance.MoveSceneByIndex(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
