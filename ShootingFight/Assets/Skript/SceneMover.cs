using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    public int currentIndex = 0;
    #region
    static public SceneMover instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    #endregion   
    public void MoveSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    [SerializeField] private GameObject gameOverUi;
    public void MoveSceneByIndex(int index)
    {
        SceneManager.LoadScene(index); 
    }
    public void MoveNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex < SceneManager.sceneCountInBuildSettings-1) 
            SceneManager.LoadScene(currentIndex + 1);
        else
        {
            Instantiate(gameOverUi);
        }
    }
}


