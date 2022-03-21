using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerViewPresenter : MonoBehaviour
{
    public static TowerViewPresenter instance;
    public  TowerHandler selectedTowerHandler;
    private void Awake()
    {
        instance = this;
    }

    public bool isSelected
    {
        get
        {
            return selectedTowerHandler != null;
        }
    }

    public LayerMask nodeLayer;
    private void Update()
    {
        if(selectedTowerHandler != null)
        {
            /*Vector3 pos = Input.mousePosition;
            
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x,
                                                                Input.mousePosition.y , 1.01f));
            RaycastHit[] hits = Physics.RaycastAll(ray,float. PositiveInfinity.nodeLayer).
                    OrderBy(h=>h.transform.position.y).ToArray();
            foreach (hits.Length > 0 &&
                hits[0].transform.gameObject.layer == LayerMask.NameToLayer("Node"))
            {

            }
         */ 
        }
    }
    public void SetTowerHandler(TowerHandler towerHandler)
    {
        selectedTowerHandler = towerHandler;
    }
    public Transform GetTowerPreviewTransform()
    {
        return selectedTowerHandler.TowerPreviewObject.transform;
    }
}
