using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TowerHandler : MonoBehaviour, IPointerClickHandler 
{
    public GameObject TowerPreviewObject;

    public void SetTowerPreviewObjectPosition(Vector3 position)
    {
        TowerPreviewObject.transform.position = position;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (TowerViewPresenter.instance.isSelected == false)
        {
            TowerViewPresenter.instance.SetTowerHandler(this);
        }
        else
        {
            TowerViewPresenter.instance.SetTowerHandler(this);
        }
    }
}
