using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testenemy : MonoBehaviour
{
    private enemyBase EB; 
    private playerBase PB;

    private bool renderObj;
    private bool firstRenderObj;
    private bool insideSpace;

    private spaceSet SS;

    private float atackTime;

    // Start is called before the first frame update
    void Start()
    {
        EB = GetComponent<enemyBase>();
        PB = EB.playerObj.GetComponent<playerBase>();
        EB.EnemySet(EB.enemyNum);
        insideSpace = false;
    }

    // Update is called once per frame
    void Update()
    {
        atackTime += Time.deltaTime;

        if (EB.HPNum <= 0)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -20)
        {
            if(PB.alliesTarget == gameObject)
            {
                PB.enemyAlert = false;
            }
            
            Destroy(gameObject);
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

            if (EB.enemyNum == 0)
            {
                transform.Translate(Vector2.left * EB.speedNum * Time.deltaTime);
            }
            else if (EB.enemyNum == 1)
            {
                transform.Translate(Vector2.left * EB.speedNum * Time.deltaTime);
            }

            if(SS != null)
            {
                if (SS.set == true && insideSpace == true)
                {
                    gameObject.layer = 8;
                    gameObject.tag = "Allies";
                    EB.destroyButton.gameObject.SetActive(false);
                    gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                }
            }
        }
        else
        {
            if (Time.timeScale == 0)
            {
                EB.frameObj.SetActive(true);
                PB.selectObj.Add(gameObject);
            }
            else
            {
                EB.frameObj.SetActive(false);
            }

            if (PB.enemyAlert == true && PB.alliesTarget != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, PB.alliesTarget.transform.position, EB.speedNum * Time.deltaTime);
                Debug.Log("gotoenemy");
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, EB.playerObj.transform.position, EB.speedNum * Time.deltaTime);
                Debug.Log("gotoplayer");
            }
        }

        renderObj = false;
        EB.HP.value = EB.HPNum;

        if (SS != null)
        {
            Debug.Log("ok");
        }
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
        var playerObj = GameObject.Find("Player");
        var PB = playerObj.GetComponent<playerBase>();
        PB.UIFlag = false;
        PB.cursor.SetActive(false);
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (atackTime >= EB.atackLimited)
        {
            if (collision.gameObject.layer == 11 && gameObject.layer == 8)
            {
                collision.gameObject.GetComponent<enemyBase>().HPNum--;
                EB.HPNum--;
            }
            else if (collision.gameObject.layer == 9 && gameObject.layer == 8)
            {
                collision.gameObject.GetComponent<enemyBase>().HPNum--;
                EB.HPNum--;
            }

            atackTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 15)
        {
            insideSpace = true;
            SS = collision.gameObject.GetComponent<spaceSet>();
            Debug.Log("in");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 15)
        {
            insideSpace = false;
            Debug.Log("out");
        }
    }
}
