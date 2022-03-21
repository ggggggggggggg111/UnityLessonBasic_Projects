using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform firePoint;
    private void Update()
    {
        if(Input.GetKeyDown("space"))
        {

            Instantiate(bullet,firePoint);
            firePoint.DetachChildren();         

            /*GameObject tmpBullet = Instantiate(bullet );

            tmpBullet.transform.position = firePoint.position;
            tmpBullet.transform.rotation = firePoint.rotation;
*/
            

            
        }
        if (Input.GetKeyDown("t"))
        {
            Instantiate(bomb,firePoint);
            firePoint.DetachChildren();
        }
    }
}