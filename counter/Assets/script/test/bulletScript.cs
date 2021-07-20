using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public GameObject shooter;

    public float bulletSpeed;

    public bool counterFlag;

    public Vector3 shooterPos;

    // Start is called before the first frame update
    void Start()
    {
        counterFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(shooter != null)
        {
            shooterPos = shooter.transform.position;
        }

        if(transform.position.y >= 100 || transform.position.y <= -100)
        {
            Destroy(gameObject);
        }
    }
}
