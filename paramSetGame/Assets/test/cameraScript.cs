using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;

    private Vector3 basePos;

    private float cameraYpos;

    // Start is called before the first frame update
    void Start()
    {
        basePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerObj.transform.position.y > basePos.y)
        {
            cameraYpos = playerObj.transform.position.y;
        }
        else
        {
            cameraYpos = basePos.y;
        }

        transform.position = new Vector3(playerObj.transform.position.x, cameraYpos, basePos.z);
    }
}
