using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testenemy : MonoBehaviour
{
    private enemyBase EB; 
    private playerBase PB;

    private bool renderObj;
    private bool firstRenderObj;

    private spaceSet SS;

    public float atackTime;

    // Start is called before the first frame update
    void Start()
    {
        EB = GetComponent<enemyBase>();
        PB = EB.playerObj.GetComponent<playerBase>();
        EB.EnemySet(EB.enemyNum);
    }

    // Update is called once per frame
    void Update()
    {
        atackTime += Time.deltaTime;

        if (EB.HPNum <= 0)
        {
            PB.selectObj.Remove(gameObject);
            PB.selected.Remove(gameObject);
            Destroy(gameObject);
        }

        if (transform.position.y < -20)
        {
            if(PB.alliesTarget == gameObject)
            {
                PB.enemyAlert = false;
            }

            PB.selectObj.Remove(gameObject);
            Destroy(gameObject);
        }

        if(PB.hackFlag == false)
        {
            EB.frameObj.SetActive(false);
        }

        if (gameObject.layer == 11)
        {
            if (renderObj == false && firstRenderObj == true && EB.renderDestroyFlag == true)
            {
                if (PB.alliesTarget == gameObject)
                {
                    PB.enemyAlert = false;
                }

                Destroy(gameObject);
            }

            if (EB.canSelected == false)
            {
                if (EB.enemyNum == 0)
                {
                    transform.Translate(Vector2.left * EB.speedNum * Time.deltaTime);
                }
                else if (EB.enemyNum == 1)
                {
                    transform.Translate(Vector2.left * EB.speedNum * Time.deltaTime);
                }
            }

            if(SS != null)
            {
                if (SS.set == true && EB.insideSpace == true)
                {
                    EB.canSelected = true;
                    EB.frameObj.SetActive(true);
                    PB.selected.Add(gameObject);
                    gameObject.layer = 17;
                }
            }
        }
        else
        {
            if (gameObject.layer == 8 && EB.canSelected == false)
            {
                if (PB.enemyAlert == true && PB.alliesTarget != null)
                {
                    transform.position = Vector2.MoveTowards(transform.position, PB.alliesTarget.transform.position, EB.speedNum * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, EB.playerObj.transform.position, EB.speedNum * Time.deltaTime);
                }
            }

            if(gameObject.layer == 10)
            {
                if(EB.objMove== true)
                {
                    transform.Translate(Vector2.right * EB.objSpeed * Time.deltaTime);
                }
            }

            if (SS != null)
            {
                if (SS.set == true && EB.insideSpace == true)
                {
                    EB.canSelected = true;
                    EB.frameObj.SetActive(true);
                    PB.selected.Add(gameObject);
                    gameObject.layer = 17;
                }
            }
        }

        renderObj = false;
        EB.HP.value = EB.HPNum;
    }

    private void OnWillRenderObject()
    {
        if (Camera.current.name != "Scene Camera" && Camera.current.name == "Main Camera")
        {
            renderObj = true;
            firstRenderObj = true;
        }
            
    }

    public void DestroyObj()
    {
        PB.UIFlag = false;
        PB.cursor.SetActive(false);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 16 && gameObject.layer == 8)
        {
            EB.HPNum--;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject == EB.playerObj && gameObject.layer == 10)
        {
            EB.objSpeed *= -1;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (atackTime >= EB.atackLimited)
        {
            if (collision.gameObject.layer == 11 && gameObject.layer == 8)
            {
                collision.gameObject.GetComponent<enemyBase>().HPNum--;
                EB.HPNum--;
                atackTime = 0;
            }
            
            if (collision.gameObject.layer == 9 && gameObject.layer == 8)
            {
                collision.gameObject.GetComponent<enemyBase>().HPNum--;
                EB.HPNum--;
                atackTime = 0;
            }
        }

        //Debug.Log(collision.gameObject.name + "STAY");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 15)
        {
            SS = collision.gameObject.GetComponent<spaceSet>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (atackTime >= EB.atackLimited)
        {
            if (collision.gameObject.CompareTag("Boss") && gameObject.layer == 8)
            {
                EB.HPNum--;
                var BB = collision.gameObject.GetComponent<bossBase>();
                BB.HPNum--;
                atackTime = 0;
            }
        }
    }
}
