using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instSpace : MonoBehaviour
{
    [SerializeField]
    GameObject space;

    public int count;

    private GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Instantiate(space, playerObj.transform.position, Quaternion.identity);
                count++;
            }
        }
    }
}
