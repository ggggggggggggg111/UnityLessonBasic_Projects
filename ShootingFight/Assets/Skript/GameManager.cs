using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region
    static public GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
           
        }
    }
    #endregion
    public float finshScore;
    public void CheckScoreAndMoveStage(float score)
    {
        if(score > finshScore)
        {
            SceneMover.instance.MoveNextScene();        
        }
    }


}
