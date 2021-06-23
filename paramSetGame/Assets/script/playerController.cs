﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Vector2 moveDist;
    private playerBase PB;
    private Rigidbody2D RB2;
    private RaycastHit hit;

    private bool onGround;
    private bool onObj;
    private bool jumpFlag;

    private float damageTimer = 0;
    private float jumptime;

    // Start is called before the first frame update
    void Start()
    {
        moveDist = Vector2.zero;
        PB = GetComponent<playerBase>();
        RB2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDist = Vector2.zero;
        onGround = IsCollision();
        onObj = OnMoveObj();

        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
        else
        {
            damageTimer = 0;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Physics2D.IgnoreLayerCollision(8, 11, false);
            Physics2D.IgnoreLayerCollision(8, 16, false);
        }

        if(PB.hackFlag == false)
        { 
            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDist += new Vector2(1, 0);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDist += new Vector2(-1, 0);
            }

            if(Input.GetKeyDown(KeyCode.LeftShift) && onGround == true)
            {
                RB2.velocity = new Vector3(0, PB.jumpPower, 0);
                jumptime = 0;
                jumpFlag = true;
            }

            if(Input.GetKey(KeyCode.LeftShift) && onGround == false && jumptime < PB.jumpLimited && jumpFlag == true)
            {
                RB2.velocity = new Vector3(0, PB.jumpPower, 0);
                jumptime += Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                jumptime = PB.jumpLimited;
                jumpFlag = false;
            }

            if(onGround == false)
            {
                PB.groundDamageTime = 0;
            }
        }
        
        if(PB.hackFlag == true)
        {
            //if (Input.GetKeyDown(KeyCode.Space) && PB.controlCount > 0 && PB.selected.Count > 0)
            //{
            //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //    int layerMask = 1 << 8 | 1 << 9 | 1 << 10;
            //    RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, Mathf.Infinity, layerMask);

            //    if (hit.collider && PB.UIFlag == false)
            //    {
            //        var hitObj = hit.collider.gameObject;

            //        if (hitObj.layer == 8 || hitObj.layer == 9 || hitObj.layer == 10)
            //        {
            //            var UI = hitObj.transform.Find("UI");
            //            UI.gameObject.SetActive(true);
            //            PB.cursor.SetActive(true);
            //            PB.UIFlag = true;
            //        }

            //    }
            //}

            PB.enemyUI.SetActive(true);

            if (PB.selected.Count == 0)
            {
                PB.hackFlag = false;
                PB.enemyUI.SetActive(false);
            }
        }

        //if(Input.GetKeyDown(KeyCode.B))
        //{
        //    if (PB.hackFlag == false)
        //    {
        //        PB.hackFlag = true;
        //        Time.timeScale = 0;
        //        PB.timeStopFlag = true;
        //    }
        //    else
        //    {
        //        if(PB.UIFlag == false)
        //        {
        //            PB.hackFlag = false;
        //            PB.timeStopFlag = false;
        //            Time.timeScale = 1;
        //        }
        //    }
        //}

        if(Input.GetKeyDown(KeyCode.I))
        {
            transform.position = new Vector3(0, 0, 0);
        }

        moveDist.Normalize();

        transform.Translate(moveDist * PB.speedNum * Time.deltaTime);
    }

    bool IsCollision()
    {
        Vector3 left_SP = transform.position - Vector3.right * 0.2f;
        Vector3 right_SP = transform.position + Vector3.right * 0.2f;
        Vector3 EP = transform.position - Vector3.up * 0.1f;
        //Debug.DrawLine(left_SP, EP);
        //Debug.DrawLine(right_SP, EP);
        return Physics2D.Linecast(left_SP, EP, PB.GroundLayer)
               || Physics2D.Linecast(right_SP, EP, PB.GroundLayer);
    }

    bool OnMoveObj()
    {
        Vector3 left_SP = transform.position - Vector3.right * 0.2f;
        Vector3 right_SP = transform.position + Vector3.right * 0.2f;
        Vector3 EP = transform.position - Vector3.up * 0.1f;
        //Debug.DrawLine(left_SP, EP);
        //Debug.DrawLine(right_SP, EP);
        return Physics2D.Linecast(left_SP, EP, PB.MoveObjLayer)
               || Physics2D.Linecast(right_SP, EP, PB.MoveObjLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && collision.gameObject.GetComponent<enemyBase>().HPNum > 0)
        {
            if(damageTimer == 0)
            {
                PB.HPNum--;
                damageTimer = 2;
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                Physics2D.IgnoreLayerCollision(8, 11);
                Physics2D.IgnoreLayerCollision(8, 16);
            }
        }
        else if(collision.gameObject.CompareTag("BossAtack"))
        {
            if (damageTimer == 0)
            {
                PB.HPNum--;
                damageTimer = 2;
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                Physics2D.IgnoreLayerCollision(8, 16);
                Physics2D.IgnoreLayerCollision(8, 11);
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(onObj == true && collision.gameObject.layer == 10)
        {
            var EB = collision.gameObject.GetComponent<enemyBase>();
            transform.Translate(EB.objSpeed * Vector2.right * Time.deltaTime);
        }
    }
}
