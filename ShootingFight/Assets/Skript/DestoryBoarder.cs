using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBoarder : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == null) return;
       
        
            Destroy(collision.gameObject);
      
     
    }


}
