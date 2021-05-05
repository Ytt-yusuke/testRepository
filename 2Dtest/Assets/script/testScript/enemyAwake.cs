using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAwake : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] bossObj;

    [SerializeField]
    private GameObject[] enemySpawnPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1) && Input.GetKey(KeyCode.Alpha0) && Input.GetKey(KeyCode.Return))
        {
            bossObj[0].SetActive(true);
        }
        else if(Input.GetKey(KeyCode.Alpha1) && Input.GetKey(KeyCode.Return))
        {
            for(int i = 0; i < enemySpawnPoint.Length; i++)
            enemySpawnPoint[i].SetActive(true);
        }
    }
}
