using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerBase : MonoBehaviour
{
    public Slider speed;
    public Slider gravity;
    public Slider HP;

    public float speedNum;
    public float powerNum;
    public float HPNum;
    private float baseGravity;

    public float groundDamageTime;
    public int controlCount;

    public bool hackFlag;
    public bool UIFlag;

    public LayerMask GroundLayer;

    public Camera cameraObj;
    // Start is called before the first frame update
    void Start()
    {
        hackFlag = false;
        UIFlag = false;
        HPNum = HP.value;
        groundDamageTime = 0;
        baseGravity = Physics2D.gravity.y;
        controlCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        speedNum = speed.value;
        HP.value = HPNum;
        groundDamageTime += Time.deltaTime;

        switch (gravity.value)
        {
            case -2:
                Physics2D.gravity = new Vector2(0, baseGravity * 0.01f);
                break;
            case -1:
                Physics2D.gravity = new Vector2(0, baseGravity * 0.5f);
                break;
            case 0:
                Physics2D.gravity = new Vector2(0, baseGravity);
                break;
            case 1:
                Physics2D.gravity = new Vector2(0, baseGravity * 1.5f);
                break;
            case 2:
                Physics2D.gravity = new Vector2(0, baseGravity * 2);
                break;
        }
    }
}
