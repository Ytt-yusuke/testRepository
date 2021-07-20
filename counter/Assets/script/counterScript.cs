using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class counterScript : MonoBehaviour
{
    private float counterTime;
    public float counterLimited;

    private GameObject player;
    private playerBase PB;
    // Start is called before the first frame update
    void Start()
    {
        counterTime = 0;
        PB = player.GetComponent<playerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        counterTime += Time.deltaTime;
        transform.position = player.transform.position + new Vector3(0, 0.74f, 0);
    }

    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player");
        counterTime = 0;
        transform.position = player.transform.position + new Vector3(0, 0.74f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var dir = collision.gameObject.transform.position - transform.position;
        float angle;

        if (transform.localScale.x >= 0)
        {
            angle = Vector3.Angle(Vector3.right, dir);
        }
        else
        {
            angle = Vector3.Angle(Vector3.left, dir);
        }

        if(transform.rotation.z != 0)
        {
            angle = Vector3.Angle(Vector3.up, dir);
        }

        

        if (collision.gameObject.CompareTag("Bullet") && counterTime <= counterLimited)
        {
            if (transform.rotation.z == 0)
            {
                if (angle >= -90 && angle <= 90)
                {
                    var BS = collision.gameObject.GetComponent<bulletScript>();
                    var CT = collision.gameObject.GetComponent<Timeline>();
                    var counterDir = (BS.shooterPos - collision.gameObject.transform.position).normalized;
                    CT.rigidbody2D.velocity = counterDir * BS.bulletSpeed;
                    PB.timeScaleFlag = true;
                    PB.scaleChangeTime = 0;
                    BS.counterFlag = true;
                    PB.coolTimeFlag = false;
                }
            }
            else
            {
                if (angle >= 0 && angle <= 180)
                {
                    var BS = collision.gameObject.GetComponent<bulletScript>();
                    var CT = collision.gameObject.GetComponent<Timeline>();
                    var counterDir = (BS.shooterPos - collision.gameObject.transform.position).normalized;
                    CT.rigidbody2D.velocity = counterDir * BS.bulletSpeed;
                    PB.timeScaleFlag = true;
                    PB.scaleChangeTime = 0;
                    BS.counterFlag = true;
                    PB.coolTimeFlag = false;
                }
            }
        }

        if (collision.gameObject.CompareTag("Sword") && counterTime <= counterLimited)
        {
            var PS = collision.gameObject.transform.root.gameObject.GetComponent<ProximityScript>();

            if (transform.rotation.z == 0)
            {
                if (PS.attackNow == true && angle >= -90 && angle <= 90)
                {
                    PB.timeScaleFlag = true;
                    PB.scaleChangeTime = 0;
                    Destroy(collision.gameObject.transform.root.gameObject);
                    PB.coolTimeFlag = false;
                }
            }
            else
            {
                if (PS.attackNow == true && angle >= 0 && angle <= 180)
                {
                    PB.timeScaleFlag = true;
                    PB.scaleChangeTime = 0;
                    Destroy(collision.gameObject.transform.root.gameObject);
                    PB.coolTimeFlag = false;
                }
            }
        }
    }

}
