using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instSpace : MonoBehaviour
{
    [SerializeField]
    GameObject space;

    private GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Space"))
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Instantiate(space, playerObj.transform.position, Quaternion.identity);
            }
        }
    }
}
