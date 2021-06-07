using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Vector2 moveDist;
    private playerBase PB;
    private Rigidbody2D RB2;

    private bool jumpFlag;

    private float jumpPower = 300;
    private float damageTimer = 0;

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
        jumpFlag = IsCollision();

        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
        else
        {
            damageTimer = 0;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Physics2D.IgnoreLayerCollision(8, 11, false);
        }

        if (PB.hackFlag == false)
        { 
            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDist += new Vector2(1, 0);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDist += new Vector2(-1, 0);
            }

            if(Input.GetKeyDown(KeyCode.LeftShift) && jumpFlag == true)
            {
                RB2.AddForce(Vector2.up * jumpPower);
                jumpFlag = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && PB.controlCount > 0) //マウスがクリックされたら
            {
                var mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var hit = Physics2D.Raycast(mousePoint, Vector2.zero);

                if(hit && PB.UIFlag == false)
                {
                    var hitObj = hit.collider.gameObject;
                    Debug.Log(hitObj);

                    if (hitObj.layer == 8 || hitObj.layer == 9 || hitObj.layer == 10)
                    {
                        var UI = hitObj.transform.Find("UI");
                        UI.gameObject.SetActive(true);
                        PB.UIFlag = true;
                    }
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            if (PB.hackFlag == false)
            {
                PB.hackFlag = true;
                Time.timeScale = 0;
            }
            else
            {
                if (PB.UIFlag == false)
                {
                    PB.hackFlag = false;
                    Time.timeScale = 1;
                }
            }

        }

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
            }
        }
    }
}
