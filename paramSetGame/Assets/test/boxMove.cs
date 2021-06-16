using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMove : MonoBehaviour
{
    private Rigidbody2D RB2;
    // Start is called before the first frame update
    void Start()
    {
        RB2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RB2.AddForce(new Vector2(-1, 1));

        if (transform.position.y <= -20)
        {
            Destroy(gameObject);
        }
    }
}
