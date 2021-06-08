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
        gameObject.layer = 11;

        HPNum = variableHP[2];
        HP.maxValue = HPNum;
        HP.value = HPNum;

        speedNum = speed[2];

        if(num == 1)
        {
            allies.gameObject.SetActive(false);
            obj.gameObject.SetActive(false);
        }
    }

    public void SetHP()
    {
        HPNum = variableHP[(int)size.value];
        HP.maxValue = HPNum;
        transform.localScale = Vector3.one * sizeNum[(int)size.value];

        if (gameObject.layer != 11 && gameObject.layer != 9)
        {
            speedNum = speed[(int)size.value];
        }
    }
}
