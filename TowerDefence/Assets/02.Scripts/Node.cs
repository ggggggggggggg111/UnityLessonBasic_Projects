using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Color originColor;
    public Color buildAvailableColor;
    public Color buildNotAvailableColor;

    Renderer rend;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originColor = rend.material.color;
    }
    private void OnMouseEnter()
    {
        rend.material.color = buildAvailableColor;
        if (TowerViewPresenter.instance.isSelected)
        {
            TowerViewPresenter.instance .GetTowerPreviewTransform().position = transform.position;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = originColor;

    }
    private void OnMouseDown()
    {
        //bulld
    }
}
