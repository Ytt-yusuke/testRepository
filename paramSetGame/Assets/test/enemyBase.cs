using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemyBase : MonoBehaviour
{
    public Slider size;
    public Toggle allies;
    public Toggle obj;
    public Button destroyButton;
    public TextMeshProUGUI sizeText;
    public Slider HP;

    public GameObject playerObj;

    public float damageTime;

    public float HPNum;

    public float speedNum;

    public float atackLimited;

    public float[] sizeNum;
    public float[] variableHP;
    public float[] speed;

    public int enemyNum;

    public bool renderDestroyFlag;


    // Start is called before the first frame update
    void Start()
    {
        damageTime = 0;
        destroyButton.gameObject.SetActive(false);
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        damageTime += Time.deltaTime;
    }

    public void EnemySet(int num)
    {
        if (enemyNum == 0)
        {
            gameObject.layer = 9;
        }
        else if(enemyNum == 1)
        {
            gameObject.layer = 11;
        }

        HPNum = variableHP[2];
        HP.maxValue = HPNum;
        HP.value = HPNum;

        speedNum = speed[2];
    }

    public void SetHP()
    {
        var HPratio = HP.value / HP.maxValue;
        HP.maxValue = variableHP[(int)size.value];
        HPNum = HP.maxValue * HPratio;
        HP.value = HPNum;

        transform.localScale = Vector3.one * sizeNum[(int)size.value];

        if (gameObject.layer != 11 && gameObject.layer != 9)
        {
            speedNum = speed[(int)size.value];
        }

        if (allies.isOn == true)
        {
            gameObject.layer = 8;
            gameObject.tag = "Allies";
            destroyButton.gameObject.SetActive(false);
        }
        else if (obj.isOn == true)
        {
            gameObject.layer = 10;
            gameObject.tag = "Object";
            destroyButton.gameObject.SetActive(true);
        }
    }
}
