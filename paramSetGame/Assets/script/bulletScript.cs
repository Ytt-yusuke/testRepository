using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public Vector3 bulletSpeed;

    private bool visual;

    public float dist;
    public float damage;

    private Vector3 instpos;
    private Vector3 movingDist;

    // Start is called before the first frame update
    void Start()
    {
        instpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movingDist = transform.position - instpos;

        if(Mathf.Abs(movingDist.x) >= dist || Mathf.Abs(movingDist.y) >= dist)
        {
            Destroy(gameObject);
        }

        if(visual == false)
        {
            Destroy(gameObject);
        }

        BulletMove();
        visual = false;
    }

    void BulletMove()
    {
        Vector3 bulletPos = transform.position;
        bulletPos += bulletSpeed * Time.deltaTime;
        transform.position = bulletPos;
    }

    private void OnWillRenderObject()
    {
        if (Camera.current.name != "Scene Camera" && Camera.current.name == "Main Camera")
        {
            visual = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 11)
        {
            collision.gameObject.GetComponent<enemyBase>().HPNum -= damage;
            Destroy(gameObject);
        }
        if(collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<enemyBase>().HPNum -= damage;
            Destroy(gameObject);
        }
    }
}
