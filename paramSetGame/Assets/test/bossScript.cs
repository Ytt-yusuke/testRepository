using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    private bossBase BB;
    // Start is called before the first frame update
    void Start()
    {
        BB = GetComponent<bossBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BB.HPNum <= 0)
        {
            Destroy(gameObject);
        }
    }
}
