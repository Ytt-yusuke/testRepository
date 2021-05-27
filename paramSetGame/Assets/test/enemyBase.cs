using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyBase : MonoBehaviour
{
    public Slider speed;
    public Slider power;

    public float speedNum;
    public float powerNum;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedNum = speed.value;
        powerNum = power.value;
    }
}
