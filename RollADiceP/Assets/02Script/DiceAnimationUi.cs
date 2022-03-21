using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DiceAnimationUi : MonoBehaviour
{
    public static DiceAnimationUi instance;
    private void Awake()
    {
        instance = this;
    }
    public bool isAvalable
    {
        get
        {
            bool isOK = false;
            if(coroutine == null)
                isOK = true;
            return isOK;    
        }
    }
    public Image diceAnimationImage;
    public float diceAnimationTime;

    public GameObject diceAnimationFinshEffect;
    private List<Sprite> list_DiceImage = new List<Sprite>();
    Coroutine coroutine = null;
    private void Start()
    {
        LoadDiceImages();
    }
    
    private void LoadDiceImages()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("DIceImages");
        list_DiceImage = sprites.ToList();

        foreach (var item in list_DiceImage)
        {
            Debug.Log(item.name);
        }
    }

    public void PlayeDiceAnimation(int diceValue)
    {
        coroutine = StartCoroutine(DiceAnimationCorountine(diceValue));
    }
    IEnumerator DiceAnimationCorountine(int diceValue)
    {
        float elapsedTime = 0;
        while(elapsedTime < diceAnimationTime)
        {
            elapsedTime += diceAnimationTime/10;  
            int tmpldx = Random.Range(0,list_DiceImage.Count);
            diceAnimationImage.sprite = list_DiceImage[tmpldx];
            yield return new WaitForSeconds(diceAnimationTime/10);
        }
        diceAnimationFinshEffect.SetActive(true);
        diceAnimationImage.sprite = list_DiceImage[diceValue -1];
        coroutine = null;
    }
    public bool IsAvailble()
    {
        bool isOK = false;
        if (coroutine == null) 
            isOK = true;
        return isOK;
    }
}
