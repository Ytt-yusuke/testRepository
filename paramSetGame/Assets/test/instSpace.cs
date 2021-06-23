using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instSpace : MonoBehaviour
{
    [SerializeField]
    GameObject space;

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
        if (!GameObject.Find("Space") && PB.hackFlag == false)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Instantiate(space, playerObj.transform.position, Quaternion.identity);
            }
        }
    }
}
