using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float score;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private GameObject destoryEffect;
    private Transform tr;
    Vector3 dir;
    Vector3 deltaMove;
    [SerializeField] private int AlPlayer;
    private void Awake()
    {
        tr = gameObject.GetComponent<Transform>();

    }
    private void Start()
    {
        SetTarget_RandomiyToPlayer(30);
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
         deltaMove = dir  * speed * Time.deltaTime;
        tr.Translate(deltaMove, Space.World);
    }
    private void SetTarget_RandomiyToPlayer(int percent)
    {
        int tmpRandomValue = Random.Range(0, 100);
        if(percent > tmpRandomValue)
        {
            GameObject target = GameObject.Find("Player");
            if(target == null)
            {
                dir = Vector3.back;
            }
            else
            {
                dir = (target.transform.position - tr.position).normalized;
            }
        }
        else
        {
            dir = Vector3.back;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.HP -= damage;
            
           

            GameObject effect = Instantiate(destoryEffect);
            effect.transform.position = tr.position;            
            Destroy(this.gameObject);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerWeapon")) 
        {
            DestoryByPlayerWeapon();
        }
        
    }
    public void DestoryByPlayerWeapon()
    {
        GameObject effect = Instantiate(destoryEffect);
        effect.transform.position = tr.position;
        GameObject playerGO = GameObject.Find("Player");
        playerGO.GetComponent<Player>().score += score;
        Destroy(effect, 3f);

        Destroy(this.gameObject);
    }

}
