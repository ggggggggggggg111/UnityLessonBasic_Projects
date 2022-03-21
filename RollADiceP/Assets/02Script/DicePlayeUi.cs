using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePlayeUi : MonoBehaviour
{
    static public DicePlayeUi instance;

    private void Awake()
    {
        instance = this;
    }
    public GameObject normalDicePanel;
    public GameObject inverseDicePanel;

    public void SwichDicePanel()
    {
        if (normalDicePanel.activeSelf)
        {
            normalDicePanel.SetActive(false);
            inverseDicePanel.SetActive(true);
        }
        else
        {
            normalDicePanel.SetActive(true);
            inverseDicePanel.SetActive(false);
        }
    }
    public void RollBackDicePanal()
    {
        if (inverseDicePanel.activeSelf)
        {
            normalDicePanel.SetActive(true);
            inverseDicePanel.SetActive(false);
        }
    }
}
