using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Vector2 moveDist;
    private Vector3 barrierDir;
    private Quaternion barrierRota;
    private playerBase PB;
    private Rigidbody2D RB2;
    private RaycastHit hit;

    private bool onGround;
    private bool jumpFlag;
    private bool hitFlag;

    private float damageTimer = 0;
    private float jumptime;
    private float barrieTime;
    private float hitTime;

    // Start is called before the first frame update
    void Start()
    {
        moveDist = Vector2.zero;
        PB = GetComponent<playerBase>();
        RB2 = GetComponent<Rigidbody2D>();
        hitFlag = false;
        barrierDir = Vector3.right * 2;
        barrierRota = Quaternion.AngleAxis(0f, Vector3.forward);
    }

    void Update()
    {
        moveDist = Vector2.zero;
        onGround = IsCollision();
        barrieTime -= Time.deltaTime;
        hitTime += Time.deltaTime;
        Debug.Log(transform.forward);

        if (hitTime >= PB.invincibleTime)
        {
            PB.playerSR.color = Color.white;
            hitFlag = false;
        }

        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
        else
        {
            damageTimer = 0;
            Physics2D.IgnoreLayerCollision(8, 11, false);
            Physics2D.IgnoreLayerCollision(8, 16, false);
        }

        if (Time.timeScale != 0)
        {
            if (PB.coolTimeFlag == false)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(Vector2.right * PB.speedNum * Time.deltaTime);
                    barrierDir = Vector3.right * 2;
                    barrierRota = Quaternion.AngleAxis(0, Vector3.forward);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(Vector2.left * PB.speedNum * Time.deltaTime);
                    barrierDir = Vector3.left * 2;
                    barrierRota = Quaternion.AngleAxis(0, Vector3.forward);
                }

                if (Input.GetKey(KeyCode.W))
                {
                    barrierDir = Vector3.right * 2;
                    barrierRota = Quaternion.AngleAxis(90, Vector3.forward);
                }

                if (Input.GetKeyDown(KeyCode.Space) && PB.barrier.activeSelf == false)
                {
                    PB.barrier.SetActive(true);
                    PB.barrierSR.color = new Color(79f / 255f, 120f / 255f, 250f / 255f);
                    barrieTime = PB.barrierLimited;
                    var barrierScale = PB.barrier.transform.localScale;
                    PB.coolTime = 0;
                    PB.coolTimeFlag = true;

                    if (barrierDir.x != 0)
                    {
                        barrierScale.x = barrierDir.x;
                    }

                    PB.barrier.transform.localScale = barrierScale;
                    PB.barrier.transform.rotation = barrierRota;
                }
                if (Input.GetKeyDown(KeyCode.LeftShift) && onGround == true)
                {
                    RB2.velocity = new Vector3(0, PB.jumpPower, 0);
                    jumptime = 0;
                    jumpFlag = true;
                }

                if (Input.GetKey(KeyCode.LeftShift) && onGround == false && jumptime < PB.jumpLimited && jumpFlag == true)
                {
                    RB2.velocity = new Vector3(0, PB.jumpPower, 0);
                    jumptime += Time.deltaTime;
                }

                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    jumptime = PB.jumpLimited;
                    jumpFlag = false;
                }
            }
        }

        if (barrieTime <= 0)
        {
            PB.barrier.SetActive(false);
        }



        if (onGround == false)
        {
            PB.groundDamageTime = 0;
        }

        {
            var dirObjDir = PB.dirObj.transform.localScale;
            dirObjDir.x = barrierDir.normalized.x;
            PB.dirObj.transform.localScale = dirObjDir;
            PB.dirObj.transform.rotation = barrierRota;
            PB.dirObj.transform.position = transform.position + new Vector3(0, 0.74f, 0);
        }

    }


    bool IsCollision()
    {
        Vector3 left_SP = transform.position - Vector3.right * 0.2f;
        Vector3 right_SP = transform.position + Vector3.right * 0.2f;
        Vector3 EP = transform.position - Vector3.up * 0.1f;
        Debug.DrawLine(left_SP, EP);
        Debug.DrawLine(right_SP, EP);
        return Physics2D.Linecast(left_SP, EP, PB.GroundLayer)
               || Physics2D.Linecast(right_SP, EP, PB.GroundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var PS = collision.gameObject.transform.root.gameObject.GetComponent<ProximityScript>();
        if (collision.gameObject.CompareTag("Sword") && PS.attackNow == true)
        {
            if (hitFlag == false)
            {
                PB.playerSR.color = Color.red;
                hitTime = 0;
                hitFlag = true;
                PS.attackNow = false;
                PB.HPNum--;
            }
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            if (hitFlag == false)
            {
                PB.playerSR.color = Color.red;
                hitTime = 0;
                hitFlag = true;
                PB.HPNum--;
            }
        }
    }
}
