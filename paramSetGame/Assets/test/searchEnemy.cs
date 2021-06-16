using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class searchEnemy : MonoBehaviour
{
    public GameObject playerObj;
    private playerBase PB;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = transform.parent.gameObject;
        PB = playerObj.GetComponent<playerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerObj.transform.position;

        if (GameObject.FindGameObjectWithTag("Boss"))
        {
            PB.enemyAlert = true;
            PB.alliesTarget = GameObject.FindGameObjectWithTag("Boss");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PB.enemyAlert = true;
            PB.alliesTarget = collision.gameObject;
        }
        else
        {
            PB.enemyAlert = false;
        }
    }
}
