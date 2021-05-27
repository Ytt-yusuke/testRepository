using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Vector2 moveDist;
    private playerBase PB;
    private Rigidbody2D RB2;

    private bool jumpFlag;

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

            if(Input.GetKeyDown(KeyCode.Space) && jumpFlag == true)
            {
                RB2.AddForce(Vector2.up * PB.powerNum);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) //マウスがクリックされたら
            {
                var mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var hit = Physics2D.Raycast(mousePoint, Vector2.zero);

                if(hit && PB.UIFlag == false)
                {
                    var hitObj = hit.collider.gameObject;
                    Debug.Log(hitObj);

                    if (hitObj.CompareTag("select"))
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

        moveDist.Normalize();

        transform.Translate(moveDist * PB.speedNum * Time.deltaTime);
    }

    void Jump()
    {
        RB2.AddForce(Vector2.up * PB.powerNum);
        jumpFlag = false;
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
}
