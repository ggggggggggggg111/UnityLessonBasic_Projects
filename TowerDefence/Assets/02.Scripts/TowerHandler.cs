using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TowerHandler : MonoBehaviour, IPointerClickHandler 
{
    public GameObject TowerPreviewObject;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        
            TowerViewPresenter.instance.SetTowerHandler(this);
    }
}
