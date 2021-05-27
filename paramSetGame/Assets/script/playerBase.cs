using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerBase : MonoBehaviour
{
    public Slider speed;
    public Slider power;

    public float speedNum;
    public float powerNum;

    public bool hackFlag;
    public bool UIFlag;

    public LayerMask GroundLayer;

    public Camera cameraObj;
    // Start is called before the first frame update
    void Start()
    {
        hackFlag = false;
        UIFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        speedNum = speed.value;
        powerNum = power.value;
    }
}
