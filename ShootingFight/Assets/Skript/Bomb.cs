using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Bullet
{
    public float explosionRange;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == null) return;

       Collider[] coliders = Physics.OverlapSphere(transform.position, explosionRange);
        int lengh = coliders.Length;
        for (int i = 0;i < lengh; i++)
        {
            if(coliders[i].gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                coliders[i].gameObject.GetComponent<Enemy>().DestoryByPlayerWeapon();
            }
        }
        Destroy(this.gameObject);
    }
}
