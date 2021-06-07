using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemyBase : MonoBehaviour
{
    public Slider speed;

    public float speedNum;
    public float tribeNum;
    public float damageTime;

    public float HPNum;

    public int enemyNum;


    // Start is called before the first frame update
    void Start()
    {
        damageTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speedNum = speed.value;
        tribeNum = 0;
        damageTime += Time.deltaTime;
    }

    public void EnemySet(int num)
    {
        gameObject.layer = 11;

        if(num == 1)
        {
            HPNum = 2;
        }
    }
}
