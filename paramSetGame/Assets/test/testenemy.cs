using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testenemy : MonoBehaviour
{
    private enemyBase EB;

    private bool renderObj;
    private bool firstRenderObj;

    // Start is called before the first frame update
    void Start()
    {
        EB = GetComponent<enemyBase>();
        EB.enemyNum = 1;
        EB.EnemySet(EB.enemyNum);
    }

    // Update is called once per frame
    void Update()
    {
        if (EB.HPNum <= 0)
        {
            if(EB.tribeNum == 0)
            {
                gameObject.layer = 9;
            }
            else if(EB.tribeNum == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 122, 0, 255);
            }
        }
        else
        {
         
            if (renderObj == false && firstRenderObj == true)
            {           
                Destroy(gameObject);       
            }    
            else if(transform.position.y < -20)      
            {     
                Destroy(gameObject);
            }
            if (EB.tribeNum == 0)
            {
                transform.Translate(Vector2.left * EB.speedNum * Time.deltaTime);
            }
            else if (EB.tribeNum == 1)
            {
                transform.Translate(Vector2.right * EB.speedNum * Time.deltaTime);
            }
        }

        renderObj = false;
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
        Destroy(gameObject);
    }
}
