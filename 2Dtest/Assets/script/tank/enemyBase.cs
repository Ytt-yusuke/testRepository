using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBase : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP;

    public int enemyNum;

    public float enemySpeed;

    public float shotPower;

    private playerBase PB;
    private bossScript BS;

    private GameObject playerBaseObj;

    private float[] distance = new float[2];

    private Vector3 playerCenterPos;
    private Vector3 enemyDirect;
    private Vector3 baseScale;

    private float calcTime;

    void Start()
    {
        playerBaseObj = GameObject.Find("playerBaseObj");
        PB = playerBaseObj.GetComponent<playerBase>();
        calcTime = 0;
        baseScale = transform.localScale;
        enemyDirect = baseScale;

        if(enemyNum == 101)
        {
            BS = gameObject.GetComponent<bossScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyNum == 1)
        {
            distance[0] = Vector3.Distance(PB.playerTank[0].transform.position, gameObject.transform.position);
            distance[1] = Vector3.Distance(PB.playerTank[1].transform.position, gameObject.transform.position);

            if (distance[0] < distance[1])
            {
                transform.position = Vector3.MoveTowards(transform.position, PB.playerTank[0].transform.position, Time.deltaTime);
            }
            else if (distance[0] > distance[1])
            {
                transform.position = Vector3.MoveTowards(transform.position, PB.playerTank[1].transform.position, Time.deltaTime);
            }
            else
            {
                int targetNum = Random.Range(0, 1);

                transform.position = Vector3.MoveTowards(transform.position, PB.playerTank[targetNum].transform.position, Time.deltaTime);
            }
        }
        else if(enemyNum == 101)
        {
            playerCenterPos = Vector3.Lerp(PB.playerTank[0].transform.position, PB.playerTank[1].transform.position, 0.5f);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerCenterPos.x, transform.position.y, playerCenterPos.z), Time.deltaTime);

            if(transform.position.x < playerCenterPos.x)
            {
                setDirect(0);
            }
            else
            {
                setDirect(1);
            }
            
            calcTime += Time.deltaTime;

            if(calcTime >= 1)
            {
                BS.Shoot();
                calcTime = 0;
            }
        }

        if(HP <= 0)
        {
            Destroy(gameObject);
        }

        transform.localScale = enemyDirect;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            if (gameObject.layer == 11)
            {
                HP = 0;
            }
        }
        else if(collision.gameObject.layer == 12)
        {
            HP--;
        }
        else if(collision.gameObject.layer == 8)
        {
            if (gameObject.layer == 11)
            {
                HP = 0;
            }
        }
    }

    void setDirect(int num)
    {
        Vector3 directVector;
        if (num == 0)
        {
            directVector = new Vector3(1, 1, 1);
            enemyDirect = new Vector3(baseScale.x * directVector.x, baseScale.y * directVector.y, baseScale.z * directVector.z);
        }

        if (num == 1)
        {
            directVector = new Vector3(-1, 1, 1);
            enemyDirect = new Vector3(baseScale.x * directVector.x, baseScale.y * directVector.y, baseScale.z * directVector.z);
        }
    }
}
