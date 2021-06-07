using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SET()
    {
        gameObject.SetActive(false);
        var playerObj = GameObject.Find("Player");
        var PB = playerObj.GetComponent<playerBase>();
        PB.UIFlag = false;
        PB.controlCount--;
    }
}
