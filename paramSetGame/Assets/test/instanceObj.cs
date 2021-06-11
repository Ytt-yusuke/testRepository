using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanceObj : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    public float instanceTime;
    public float time;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= instanceTime)
        {
            Instantiate(obj, transform);
            time = 0;
        }
    }
}
