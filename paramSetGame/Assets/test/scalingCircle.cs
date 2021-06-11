using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalingCircle : MonoBehaviour
{
    public Vector3 baseScale;
    private GameObject playerObj;
    private playerBase PB;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        PB = playerObj.GetComponent<playerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PB.timeStopFlag == false)
        {
            if (Input.GetKey(KeyCode.M))
            {
                transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, 0);
            }

            if (Input.GetKey(KeyCode.N))
            {
                transform.localScale += new Vector3(-Time.deltaTime, -Time.deltaTime, 0);
            }
        }
    }

    private void OnEnable()
    {
        transform.localScale = baseScale;
        Debug.Log(transform.localScale);
    }
}
