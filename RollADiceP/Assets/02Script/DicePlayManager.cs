using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicePlayManager : MonoBehaviour
{
 

    static public DicePlayManager instance;
    private int currentTileIndex;
    private int _diceNum;
    public int diceNum
    {
        set
        {
            _diceNum = value;
            diceNumText.text = _diceNum.ToString();
        }
        get
        {
            return _diceNum;
        }
    }

    private int _goldenDiceNum;
    public int goldenDiceNum
    {
        set
        {
            _goldenDiceNum = value;
           goldenDiceNumText.text = _goldenDiceNum.ToString();
        }
        get
        {
            return (_goldenDiceNum);
        }
    }
    public int diceNumInit;
    public int goldenDiceNumIniit;
    public List<Transform> list_MapTile;

    public Text goldenDiceNumText;
    public Text diceValueText;
    public Text diceNumText;

    private int _starScore;
    public int starScore
    {
        set
        {
            _starScore = value;
            starScoreText.text = _starScore.ToString();
        }
        get
        {
            return _starScore;
        }
    }
    public Text starScoreText;

    public Transform playerStartPoint;
    public GameObject finshedPanal;
    private void Awake()
    {
        instance = this;
        diceNum = diceNumInit;
        goldenDiceNum = goldenDiceNumIniit;
    }

    public void  RollADice()
    {
        if (diceNum  < 1) return;
        if (DiceAnimationUi.instance.isAvalable == false) return;
        diceNum --;
        

        int diceVaule = Random.Range(1, 7);
        diceValueText.text = diceVaule.ToString();
        DiceAnimationUi.instance.PlayeDiceAnimation(diceVaule);
        MovePlayer(diceVaule);   
    }
    public void RollADiceInverse()
    {
        if (diceNum < 1) return;

        diceNum--;
        int diceVaule = Random.Range(1, 7);
        diceValueText.text = diceVaule.ToString();
        MovePlayer(diceVaule * -1);
    }
    public void RollAGoldenDice(int diceValue)
    {
        if(goldenDiceNum < 1) return;

        goldenDiceNum--;
        MovePlayer(diceValue);
    }
    public void RollAGoldenDiceInverse(int diceValue)
    {
        if (goldenDiceNum < 1) return;

        goldenDiceNum--;
        MovePlayer(diceValue * -1); 
    }

    
    private void MovePlayer(int diceValue)
    {
        int previousTileIndex = currentTileIndex;
        currentTileIndex += diceValue;
        CheckPlayerPassdStarTile(previousTileIndex, currentTileIndex);
        if (currentTileIndex >= list_MapTile.Count - 1)
            currentTileIndex -=(list_MapTile.Count);
        if (currentTileIndex < 0)
            currentTileIndex = list_MapTile.Count - currentTileIndex;     
        Vector3 target = CatTilePosition(currentTileIndex);
        Player.instance.Move(target);
        list_MapTile[currentTileIndex].GetComponent<TileInfo>().TileEvent();
        CheckGameFinshed();
    }
    private void CheckPlayerPassdStarTile(int previousIndex,int currentIndex)
    {
        TileInfo_Star tmpStarTile = null;
        for(int i = previousIndex +1; i <= currentIndex; i++)
        {
            int tmpIndex = i;
            if (tmpIndex >= list_MapTile.Count)
                tmpIndex -=(list_MapTile.Count);
          
            bool isOK = list_MapTile[tmpIndex].TryGetComponent(out tmpStarTile);
            if (isOK)
            {
                starScore += tmpStarTile.starValue;
                
            }
        }
    }
    private Vector3 CatTilePosition(int tileIdex)
    {
        Vector3 pos = list_MapTile[tileIdex].position;
        return pos;         
    }
    private void CheckGameFinshed()
    {
        int totalDiceNum = diceNum + goldenDiceNum;
        if(totalDiceNum < 1)
        {
            finshedPanal.SetActive(true);
        }
    }
    public void RePlayGame()
    {
        diceNum = diceNumInit;
        goldenDiceNum = goldenDiceNumIniit;
        
        foreach(Transform mapTile in list_MapTile)
        {
            TileInfo_Star tileInfo_Star = null;
            bool isExist = mapTile.TryGetComponent(out tileInfo_Star);

            if (isExist)
            {
                tileInfo_Star.starValue = 3;
            }
        }
        Player.instance.transform.position = playerStartPoint.position;
        currentTileIndex = 0;
        starScore = 0;
        DicePlayeUi.instance.RollBackDicePanal();
        
    }
    
}
