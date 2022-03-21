using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    Transform tr;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotateSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        tr = gameObject.GetComponent<Transform>();       
        tr = this.gameObject.GetComponent<Transform> ();    
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log("h =" + h);
        Debug.Log($"v =  {v}");
        
        Vector3 vector3 = new Vector3(h, v).normalized;
        Vector3 movePos = new Vector3(h, 0, v) * speed * Time.deltaTime;
        tr.Translate(movePos,Space.World);


        //tr.Translate(movevoc, Space.Self);
        // tr.Translate(movevoc, Space.World);

        //tr.Rotate(new Vector3(0f, 30f, 0f));
        float r = Input.GetAxis("Mouse X");
        Vector3 roatateVoc = Vector3.up * rotateSpeed *r * Time.deltaTime;
        tr.Rotate(roatateVoc);

    }
        
}
