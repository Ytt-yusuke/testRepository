using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
using UnityEngine.UI;

public class playerBase : MonoBehaviour
{

    public float speedNum;
    public float powerNum;
    public float HPNum;

    public float groundDamageTime;
    public float jumpLimited;
    public float jumpPower;
    public float barrierLimited;
    public float chargeTime;
    public int hitEnemyCount;
    public float invincibleTime;
    public float coolTime;
    public float coolTimeLimited;

    public GameObject barrier;
    public GameObject dirObj;

    public LayerMask GroundLayer;

    public bool timeScaleFlag;
    public bool testFlag;
    public bool coolTimeFlag;

    public SpriteRenderer barrierSR;
    public SpriteRenderer playerSR;
    public GlobalClock GC;

    public Slider HPSlider;

    public float scaleChangeTime;
    public float scaleChangeLimited;

    public List<GameObject> hitAttack;

    // Start is called before the first frame update
    void Start()
    {
        barrier.SetActive(false);
        timeScaleFlag = false;
        scaleChangeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scaleChangeTime += Time.deltaTime;
        coolTime += Time.deltaTime;
        HPSlider.value = HPNum;

        if(coolTime >= coolTimeLimited)
        {
            coolTimeFlag = false;
        }

        if (testFlag == true && GC.localTimeScale != 0)
        {
            if (timeScaleFlag == true)
            {
                GC.localTimeScale = 0.3f;

                if (scaleChangeTime >= scaleChangeLimited)
                {
                    timeScaleFlag = false;
                }
            }
            else
            {
                GC.localTimeScale = 1.0f;
            }
        }
    }
}
