using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower : MonoBehaviour
{
    Transform tr;
    public TowerInfo info;
    public LayerMask enemyLayer;
    public float detectRange;

    public Transform turretRotatePosition;
    private void Awake()
    {
        tr = GetComponent<Transform>();
    }
    private void OnDisable()
    {
        ObjectPool.ReturnToPool(gameObject);
    }

    private void Update()
    {
        Collider[] cols = Physics.OverlapSphere(tr.position, detectRange, enemyLayer);
        
        
        if(cols.Length > 0)
        {
            cols.OrderBy(x => x.transform.position - WayPoints.points.Last().transform.position);
            turretRotatePosition.LookAt(cols[0].transform);
        }
        
    }
}