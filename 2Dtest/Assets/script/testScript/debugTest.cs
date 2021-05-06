using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugTest : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject debugUIObj;

    void Start()
    {
        debugUIObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(debugUIObj.activeSelf == false)
            {
                debugUIObj.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                debugUIObj.SetActive(false);
                Time.timeScale = 0;
            }
        }
    }
}
