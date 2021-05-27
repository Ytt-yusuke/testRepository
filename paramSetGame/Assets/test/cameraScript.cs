using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;

    private Vector3 basePos;

    // Start is called before the first frame update
    void Start()
    {
        basePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerObj.transform.position.x, Mathf.Lerp(playerObj.transform.position.y, basePos.y, 0.8f), basePos.z);
    }
}
