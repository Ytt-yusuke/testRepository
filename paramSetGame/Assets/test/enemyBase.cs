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
    public Toggle enemy;
    public Button destroyButton;
    public TextMeshProUGUI sizeText;
    public Slider HP;

    public GameObject playerObj;
    public GameObject frameObj;

    public float damageTime;

    public float HPNum;

    public float speedNum;

    public float atackLimited;

    public float[] sizeNum;
    public float[] variableHP;
    public float[] speed;

    public int enemyNum;

    public bool renderDestroyFlag;

    private playerBase PB;
    private bool setflag;

    // Start is called before the first frame update
    void Start()
    {
        damageTime = 0;
        destroyButton.gameObject.SetActive(false);
        playerObj = GameObject.Find("Player");
        frameObj = gameObject.transform.Find("Frame").gameObject;
        frameObj.SetActive(false);
        PB = playerObj.GetComponent<playerBase>();
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
    }

    public void SetHP()
    {
        var HPratio = HP.value / HP.maxValue;
        HP.maxValue = variableHP[(int)size.value];
        HPNum = HP.maxValue * HPratio;
        HP.value = HPNum;
        setflag = false;

        transform.localScale = Vector3.one * sizeNum[(int)size.value];

        if (gameObject.layer != 11 && gameObject.layer != 9)
        {
            speedNum = speed[(int)size.value];
        }

        if (allies.isOn == true)
        {
            gameObject.layer = 8;
            gameObject.tag = "Allies";

            for(int i = 0; i < PB.selectObj.Count; i++)
            {
                var alliesObj = PB.selectObj[i].gameObject;

                if(alliesObj == gameObject)
                {
                    setflag = true;
                }
            }

            if(setflag == false)
            {
                PB.selectObj.Add(gameObject);
            }

            var parentObj = GameObject.Find("Allies");
            gameObject.transform.SetParent(parentObj.transform);

            destroyButton.gameObject.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (obj.isOn == true)
        {
            gameObject.layer = 10;
            gameObject.tag = "Object";
            PB.selectObj.Remove(gameObject);

            var parentObj = GameObject.Find("Object");
            gameObject.transform.SetParent(parentObj.transform);

            destroyButton.gameObject.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(164, 123, 92, 1);
        }

        if(enemy.isOn == false)
        {
            enemy.gameObject.SetActive(false);
            var objToggle = obj.navigation;
            objToggle.selectOnRight = null;
        }
    }
}
