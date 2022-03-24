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
    public Text sellPriceText;
    private void OnDisable()
    {
        node = null;
        upgradePriceText.text = "";
        sellPriceText.text = "";
    }
    public void OnUpgradeButton()
    {
        int nextLevel = node.tower.info.level + 1;
        if (TowerAssets.instance.TryGetTowerName(node.tower.info.type, nextLevel, out string towerName))
        {
            node.BuildTowerHere(towerName);
        }
    }

    public void OnSellButton()
    {
        node.DestoryTowerHere();
    }
}
