using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class testShot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    SpriteRenderer SR;

    [SerializeField]
    float min;

    [SerializeField]
    float max;

    private Rigidbody2D bulletRB2;

    private float shotTime;
    private float time;

    private bool lockOn;
    private bool canShot;

    private Vector3 targetPos;
    private Vector3 targetDir;

    private GameObject player;
    private LocalClock LC;
    public LineRenderer LR;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        bulletRB2 = bullet.GetComponent<Rigidbody2D>();
        shotTime = Random.Range(min, max);
        player = GameObject.FindWithTag("Player");
        LC = GetComponent<LocalClock>();
        LR.positionCount = 2;
        lockOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += LC.deltaTime;
        LR.SetPosition(0, transform.position);
        targetDir = transform.position - (player.transform.position + new Vector3(0, 0.74f, 0));

        if (lockOn == false)
        {
            LR.SetPosition(1, transform.position);
        }

        if (canShot == true)
        {

            if (time >= shotTime - 1f && lockOn == false)
            {
                SR.color = Color.red;
                LR.SetPosition(1, transform.position - targetDir * 10);
            }

            if (time >= shotTime - 0.5f && lockOn == false)
            {
                targetPos = transform.position - targetDir;
                LR.SetPosition(1, transform.position - targetDir * 10);
                lockOn = true;
            }

            if (time >= shotTime)
            {
                SR.color = Color.white;
                var instBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                var BS = instBullet.GetComponent<bulletScript>();
                var CT = instBullet.GetComponent<Timeline>();
                BS.shooter = gameObject;
                var shotDir = (targetPos - transform.position).normalized;
                var bulletSpeed = BS.bulletSpeed;
                CT.rigidbody2D.velocity = shotDir * bulletSpeed;
                time = 0;
                shotTime = Random.Range(min, max);
                lockOn = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canShot = true;
            time = 0;
            SR.color = Color.white;
            lockOn = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canShot = false;
            time = 0;
            SR.color = Color.white;
            lockOn = false;
        }
    }
}
