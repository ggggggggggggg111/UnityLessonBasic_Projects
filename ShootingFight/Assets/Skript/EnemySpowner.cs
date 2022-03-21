using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpowner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spownerDeley;
    float elapsedTime;

    Transform tr;
    private void Awake()
    {
        tr = gameObject.transform;
    }
    void Update()
    {
        if(elapsedTime > spownerDeley)
        {
            Instantiate(enemyPrefab, transform);
            elapsedTime = 0;
        }
        elapsedTime += Time.deltaTime;

    }
}
