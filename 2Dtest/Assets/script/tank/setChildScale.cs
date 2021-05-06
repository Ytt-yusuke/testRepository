using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setChildScale : MonoBehaviour
{
    private Vector3 defaultScale = Vector3.zero;
    private Vector3 lossScale;
    private Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.lossyScale;
    }

    // Update is called once per frame
    void Update()
    {
        lossScale = transform.lossyScale;
        localScale = transform.localScale;

        transform.localScale = new Vector3(
                localScale.x / lossScale.x * defaultScale.x,
                localScale.y / lossScale.y * defaultScale.y,
                localScale.z / lossScale.z * defaultScale.z
        );
    }
}
