using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Inimigos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5);

        for (int i = 0; i < 1500; i++)
        {
            Instantiate(Inimigos, transform.position, Quaternion.identity);
        }
        
        yield return new WaitForSeconds(5);
        StartCoroutine(Spawn());
    }
}
