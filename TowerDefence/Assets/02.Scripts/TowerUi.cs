using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TowerUi : MonoBehaviour
{
    
    public static TowerUi instance;


    private void Awake()
    {
        instance = this;
    }

    public Node node;

    public Text upgradePriceText;
    public Text sellPreiceText;
    public void OnUpgradeButton()
    {
        int nextLevel = node.towerInfo.level + 1;
        TowerAssets.Instance.TryGetTowerName(node.towerInfo.type,nextLevel,out string)
        {

        }
    }

    public void OnSellButton()
    {

    }
}
