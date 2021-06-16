using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossBase : MonoBehaviour
{
    public float HPNum;
    public int bossNum;
    public Slider HP;

    // Start is called before the first frame update
    void Start()
    {
        BossSet(bossNum);
        HP.maxValue = HPNum;
        HP.value = HP.maxValue;
        HP.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HP.value = HPNum;
    }

    private void BossSet(int num)
    {
        switch(num)
        {
            case 0:
                HPNum = 200;
                break;
        }
    }
}
