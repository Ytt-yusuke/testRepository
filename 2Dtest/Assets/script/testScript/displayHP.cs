using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayHP : MonoBehaviour
{
    // Start is called before the first frame update

    public bool display;

    [SerializeField]
    GameObject HPInstance;

    [SerializeField]
    Slider HPbar;

    [SerializeField]
    GameObject playerBaseObj;

    private playerBase PB;

    public float stopHP;

    void Start()
    {
        display = true;
        PB = playerBaseObj.GetComponent<playerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (display == true)
        {
            if (HPInstance.activeSelf == false)
            {
                HPInstance.SetActive(true);
            }
        }
        else
        {
            if (HPInstance.activeSelf == true)
            {
                stopHP = PB.HP;
                HPInstance.SetActive(false);
            }

            PB.HP = stopHP;
        }

        HPbar.value = PB.HP / PB.maxHP;
    }

    public void SetDisplay()
    {
        display = false;
    }
}
