using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedScript : MonoBehaviour
{
    private enemyBase EB;
    private Vector3 spacePos;

    public Vector3 posDifference;
    public Vector3 objSize;
    private Vector3 playerPos;

    private SpriteRenderer SR;

    private playerBase PB;

    private float xPercent;
    private float yPercent;

    private bool searchHit;
    // Start is called before the first frame update
    void Start()
    {
        EB = GetComponent<enemyBase>();
        spacePos = Vector3.zero;
        PB = EB.playerObj.GetComponent<playerBase>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        posDifference = transform.position - spacePos;
        objSize = SR.bounds.size;
        playerPos = EB.playerObj.transform.position;

        if (searchHit == true)
        {
            SelectCheck();
        }
        else
        {
            xPercent = 0;
            yPercent = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 15)
        {
            spacePos = collision.gameObject.transform.position;
            searchHit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 15)
        {
            searchHit = false;
        }
    }

    private void SelectCheck()
    {
        if(spacePos.x <= transform.position.x)
        {
            if(Mathf.Abs(posDifference.x) > objSize.x /2)
            {
                if(playerPos.x < transform.position.x + objSize.x/2)
                {
                    var minPos = transform.position.x - objSize.x / 2;
                    xPercent = playerPos.x - minPos;
                    xPercent /= objSize.x;
                }
                else
                {
                    xPercent = 1;
                }
            }
            else
            {
                if (playerPos.x <= transform.position.x + objSize.x / 2)
                {
                    xPercent = playerPos.x - spacePos.x;
                    xPercent /= objSize.x;
                }
                else
                {
                    var maxPos = transform.position.x + objSize.x / 2;
                    xPercent = maxPos - spacePos.x;
                    xPercent /= objSize.x;
                }
            }
        }
        else
        {
            if (Mathf.Abs(posDifference.x) > objSize.x / 2)
            {
                var maxPos = transform.position.x + objSize.x / 2;
                xPercent = maxPos - playerPos.x;
                xPercent /= objSize.x;
            }
            else
            {
                if (playerPos.x >= transform.position.x - objSize.x / 2)
                {
                    xPercent = spacePos.x - playerPos.x;
                    xPercent /= objSize.x;
                }
                else
                {
                    var minPos = transform.position.x - objSize.x / 2;
                    xPercent = spacePos.x - minPos;
                    xPercent /= objSize.x;
                }
            }
        }

        if (spacePos.y <= transform.position.y)
        {
            if (Mathf.Abs(posDifference.y) > objSize.y / 2)
            {
                if (playerPos.y < transform.position.y + objSize.y / 2)
                {
                    var minPos = transform.position.y - objSize.y / 2;
                    yPercent = playerPos.y - minPos;
                    yPercent /= objSize.y;
                }
                else
                {
                    yPercent = 1;
                }
            }
            else
            {
                if (playerPos.y <= transform.position.y + objSize.y / 2)
                {
                    yPercent = playerPos.y - spacePos.y;
                    yPercent /= objSize.y;
                }
                else
                {
                    var maxPos = transform.position.y + objSize.y / 2;
                    yPercent = maxPos - spacePos.y;
                    yPercent /= objSize.y;
                }
            }
        }
        else
        {
            if (Mathf.Abs(posDifference.y) > objSize.y / 2)
            {
                var maxPos = transform.position.y + objSize.y / 2;
                yPercent = maxPos - playerPos.y;
                yPercent /= objSize.y;
            }
            else
            {
                if (playerPos.y >= transform.position.y - objSize.y / 2)
                {
                    yPercent = spacePos.y - playerPos.y;
                    yPercent /= objSize.y;
                }
                else
                {
                    var minPos = transform.position.y - objSize.y / 2;
                    yPercent = spacePos.y - minPos;
                    yPercent /= objSize.y;
                }
            }
        }

        if(xPercent * yPercent  >= 0.8)
        {
            EB.insideSpace = true;
        }
        else
        {
            EB.insideSpace = false;
        }
    }
}
