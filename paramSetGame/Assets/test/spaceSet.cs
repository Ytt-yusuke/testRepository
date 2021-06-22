using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceSet : MonoBehaviour
{
    private SpriteRenderer SR;
    private instSpace IS;

    private GameObject playerObj;
    private playerBase PB;

    public bool set;


    // Start is called before the first frame update
    void Start()
    {
        SR = gameObject.GetComponent<SpriteRenderer>();
        IS = GameObject.Find("instSpace").GetComponent<instSpace>();
        playerObj = GameObject.Find("Player");
        PB = playerObj.GetComponent<playerBase>();
        set = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            var spaceScale = playerObj.transform.position - transform.position;
            SR.size = new Vector2(spaceScale.x, -spaceScale.y);
        }

        if(Input.GetKeyUp(KeyCode.H))
        {
            set = true;
        }
    }

    private void LateUpdate()
    {
        if(set == true)
        {
            PB.hackFlag = true;
            Destroy(gameObject);
        }
    }
}
