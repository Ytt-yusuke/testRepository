using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerBase : MonoBehaviour
{
    public Slider gravity;
    public Slider HP;

    public GameObject cursor;
    public GameObject alliesTarget;
    public GameObject hackTarget;
    public GameObject instSpace;
    public GameObject enemyUI;

    public float speedNum;
    public float powerNum;
    public float HPNum;
    private float baseGravity;

    public float groundDamageTime;
    public float jumpLimited;
    public float jumpPower;
    public int controlCount;
    public int hitEnemyCount;

    public bool hackFlag;
    public bool UIFlag;
    public bool enemyAlert;
    public bool timeStopFlag;

    public LayerMask GroundLayer;

    public Camera cameraObj;

    public List<GameObject> selectObj = new List<GameObject>();
    public List<GameObject> selected = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        hackFlag = false;
        UIFlag = false;
        HPNum = HP.value;
        baseGravity = Physics2D.gravity.y;
        cursor.SetActive(false);
        timeStopFlag = false;
        enemyUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        speedNum = 10;
        HP.value = HPNum;
        groundDamageTime += Time.deltaTime;
        Debug.Log(selectObj.Count);

        if(selectObj.Count >= 5)
        {
            for(int i = 0; i < selectObj.Count - 4; i++)
            {
                Destroy(selectObj[0]);
                selectObj.RemoveAt(0);
            }
        }

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
