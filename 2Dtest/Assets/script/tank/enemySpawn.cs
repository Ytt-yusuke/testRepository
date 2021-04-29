using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject enemyObj;

    private float spawnTime;

    void Start()
    {
        spawnTime = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;

        if(spawnTime >= 5)
        {
            Instantiate(enemyObj, transform);
            spawnTime = 0;
        }
    }
}
