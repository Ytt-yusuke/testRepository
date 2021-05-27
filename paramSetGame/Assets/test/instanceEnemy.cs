using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanceEnemy : MonoBehaviour
{
    public GameObject enemy;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(time >= 5)
        {
            Instantiate(enemy, transform);
            time = 0;
        }

        time += Time.deltaTime;
    }
}
