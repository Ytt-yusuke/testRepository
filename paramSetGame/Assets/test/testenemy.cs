using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testenemy : MonoBehaviour
{
    private enemyBase EB;

    private bool renderObj;
    private bool firstRenderObj;

    private playerBase PB;

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
        if (gameObject.layer == 11 || gameObject.layer == 9)
        {
            if (EB.HPNum > 0)
            {
                if (renderObj == false && firstRenderObj == true && EB.renderDestroyFlag == true)
                {
                    Destroy(gameObject);
                }
                else if (transform.position.y < -20)
                {
                    Destroy(gameObject);
                }

                if (EB.enemyNum == 0)
                {
                    transform.Translate(Vector2.left * EB.speedNum * Time.deltaTime);
                }
                else if (EB.enemyNum == 1)
                {
                    transform.Translate(Vector2.left * EB.speedNum * Time.deltaTime);

                    if (EB.HPNum <= EB.HP.maxValue * 0.8f)
                    {
                        gameObject.layer = 9;
                    }
                }
            }
            else
            {
                gameObject.layer = 8;
                gameObject.tag = "Allies";
                EB.SetHP();
                //PB.enemyAlert = false;

                if (EB.enemyNum == 1)
                {
                    EB.allies.gameObject.SetActive(true);
                    EB.obj.gameObject.SetActive(true);
                }
            }

        }
        else
        {
            if (EB.allies.isOn == true)
            {
                gameObject.layer = 8;
                gameObject.tag = "Allies";
                EB.destroyButton.gameObject.SetActive(false);
            }
            else if (EB.obj.isOn == true)
            {
                gameObject.layer = 10;
                gameObject.tag = "Object";
                EB.destroyButton.gameObject.SetActive(true);
            }

            if(EB.HPNum <= 0)
            {
                Destroy(gameObject);
            }

            if(PB.enemyAlert == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, PB.alliesTarget.transform.position, EB.speedNum * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, EB.playerObj.transform.position, EB.speedNum * Time.deltaTime);
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
        var playerObj = GameObject.Find("Player");
        var PB = playerObj.GetComponent<playerBase>();
        PB.UIFlag = false;
        PB.cursor.SetActive(false);
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
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
    }
}
