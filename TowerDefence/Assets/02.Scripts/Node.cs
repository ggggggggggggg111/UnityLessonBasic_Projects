using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    bool isTowerHere
    {
        get 
        { 
            return tower != null;
        }
    }
    public Tower tower;

    private Color originColor;
    public Color buildAvailableColor;
    public Color buildNotAvailableColor;

    Renderer rend;
    BoxCollider col;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<BoxCollider>();
        originColor = rend.material.color;
    }
    private void OnMouseEnter()
    {
        
        if (TowerViewPresenter.instance.isSelected)
        {
            Transform previewTransform = TowerViewPresenter.instance.GetTowerPreviewTransform();
            previewTransform.gameObject.SetActive(true);
            previewTransform.position = transform.position + new Vector3(0, col.size.y / 2, 0);
            if (isTowerHere)
                rend.material.color = buildNotAvailableColor;
            else
                rend.material.color =buildAvailableColor;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = originColor;
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))

        {
            if (isTowerHere && TowerViewPresenter.instance.isSelected==false) 

            {
                
                TowerUi.instance.upgradePriceText.text =tower.info.price.ToString();
                TowerUi.instance.sellPriceText.text = (tower.info.price*0.8).ToString();
                TowerUi.instance.transform.position = transform.position + Vector3.up * 2;
                TowerUi.instance.node = this;
                TowerUi.instance.gameObject.SetActive(true);
            }
            else if (isTowerHere == false && TowerViewPresenter.instance.isSelected)
            {

                Transform previewTransform = TowerViewPresenter.instance.GetTowerPreviewTransform();

                string towerName = previewTransform.GetComponent<TowerPraview>().towerName;

                BuildTowerHere(towerName);
                previewTransform.gameObject.SetActive(false);
                TowerViewPresenter.instance.SetTowerHandler(null);
            }




        }
        else
        {
            TowerViewPresenter.instance.SetTowerHandler(null);
        }
    }
     
    public void BuildTowerHere(string towerName)
    {
        //when tower already exist
        if(tower != null)
        {
            tower.gameObject.SetActive(false);
        }
        GameObject towerGameObject = ObjectPool.SpawnFromPool(towerName,transform.position + new Vector3(0, col.size.y / 2, 0));

      
        tower = towerGameObject.GetComponent<Tower>();


    }

    public void DestoryTowerHere()
    {
        tower.gameObject.SetActive(false);
        tower = null;
    }
}
