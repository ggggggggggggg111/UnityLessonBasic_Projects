using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Rocket : Tower
{
    public GameObject RocketPrefab;
    public Transform[] firePoints;
    public int damage;
    public float reloadTime;
    public float reloadTimer;
    public override void Update()
    {
        base.Update();

        if (reloadTimer < 0)
        {
            if (target != null)
            {
                Attack();
                reloadTimer = reloadTime;
            }


        }
        else
            reloadTimer -= Time.deltaTime;


    }

    private void Attack()
    {
        foreach(var firePoints in firePoints)
        {
            GameObject missile = Instantiate(RocketPrefab, firePoints.position, Quaternion.identity);
            Vector3 dir = (target.transform.position - missile.transform.position).normalized;
            missile.GetComponent<Rocket>().SetUp(dir, target,damage);
            
        }
        
    }
}
