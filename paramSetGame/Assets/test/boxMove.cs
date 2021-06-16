using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMove : MonoBehaviour
{
    private Rigidbody2D RB2;
    private bool isFirst;

    // Start is called before the first frame update
    void Start()
    {
        RB2 = GetComponent<Rigidbody2D>();
        isFirst = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirst == false)
        {
            RB2.AddForce(new Vector2(-5, 1), ForceMode2D.Impulse);
            isFirst = true;
        }

        if (transform.position.y <= -20)
        {
            Destroy(gameObject);
        }
    }
}
