using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class ProximityScript : MonoBehaviour
{ 
    [SerializeField]
    GameObject sword;

    [SerializeField]
    SpriteRenderer SR;

    [SerializeField]
    ProximitySearch PS;

    [SerializeField]
    float min;

    [SerializeField]
    float max;

    [SerializeField]
    float speed;

    private LocalClock LC;

    private float attackTime;
    private float time;
    private float swordRadius;
    private float swordAngle;
    private float gravityPos;

    private GameObject player;

    private Rigidbody2D RB2;

    private bool lockOn;
    private bool canAttack;
    private bool flipFlag;
    public bool attackNow;
    private bool setFlag;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        lockOn = false;
        LC = GetComponent<LocalClock>();
        attackTime = Random.Range(min, max);
        time = 0;
        swordRadius = 2;
        RB2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += LC.deltaTime;

        if(PS.inArea == true)
        {
            if (canAttack == false)
            { 
                time = 0;
                SR.color = Color.white;
                lockOn = false;
                swordAngle = 180;
                sword.transform.position = transform.position + AnglePosition(swordAngle);
                
                if(Vector2.Distance(transform.position, player.transform.position) >= 3)
                {
                    var toMove = Vector2.MoveTowards(transform.position, player.transform.position, speed * LC.deltaTime);
                    transform.position = new Vector3(toMove.x, transform.position.y, transform.position.z);
                }
                else 
                {
                    canAttack = true;
                }
            }
        }
        else
        {
            if(canAttack == true)
            {
                canAttack = false;
                time = 0;
                SR.color = Color.white;
                lockOn = false;
            }
        }

        if(player.transform.position .x >= transform.position.x)
        {
            if (lockOn == false)
            {
                flipFlag = true;
                swordAngle = 135;
                sword.transform.position = transform.position;
                sword.transform.rotation = Quaternion.AngleAxis(-swordAngle, Vector3.forward);
            }
        }
        else
        {
            if (lockOn == false)
            {
                flipFlag = false;
                swordAngle = 45;
                sword.transform.position = transform.position;
                sword.transform.rotation = Quaternion.AngleAxis(-swordAngle, Vector3.forward);
            }
        }

        if(canAttack == true)
        {

            if (time >= attackTime - 1f && lockOn == false)
            {
                SR.color = Color.red;
                swordAngle = 90;
                sword.transform.position = transform.position + AnglePosition(swordAngle);
                sword.transform.rotation = Quaternion.AngleAxis(swordAngle, Vector3.forward);
            }

            if (time >= attackTime - 0.5f && lockOn == false)
            {
                lockOn = true;
                setFlag = false;
            }

            if (time >= attackTime)
            {
                if(setFlag == false)
                {
                    attackNow = true;
                    setFlag = true;
                }

                if(lockOn == true)
                {
                    if(flipFlag == true)
                    {
                        swordAngle -= LC.deltaTime * 250;
                    }
                    else
                    {
                        swordAngle += LC.deltaTime * 250;
                    }
                    sword.transform.position = transform.position + AnglePosition(swordAngle);
                    sword.transform.rotation = Quaternion.AngleAxis(swordAngle, Vector3.forward);

                    if (swordAngle >= 180 || swordAngle <= 0)
                    {
                        SR.color = Color.white;
                        time = 0;
                        attackTime = Random.Range(min, max);
                        lockOn = false;
                        attackNow = false;
                        canAttack = false;
                    }
                }

            }
        }
    }

    private Vector3 AnglePosition(float angle)
    {
        return new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0f).normalized * swordRadius;
    }
}
