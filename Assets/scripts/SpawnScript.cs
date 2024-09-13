using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject cloud,Pipe;
    private float clSpawnTime = 2f, clSpawnRate = 2f;
    private float pSpawnTime = 6.5f, pSpawnRate = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clSpawnTime += Time.deltaTime;
        pSpawnTime += Time.deltaTime;

        if (clSpawnTime > clSpawnRate)
        {
            Instantiate(cloud,new Vector3(transform.position.x,Random.Range(-3.56f,3.76f),0),Quaternion.identity);
            clSpawnTime = 0;
        }

        if(pSpawnTime > pSpawnRate)
        {
            Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(-1.2f, 4f), 0), Quaternion.identity);
            pSpawnTime = 0;
        }
    }
}
