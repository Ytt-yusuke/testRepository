using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instBossBox : MonoBehaviour
{
    [SerializeField]
    private GameObject atackBox;

    public float instTime;
    private float timeCount;

    private float moveTime;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;
        moveTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        moveTime += Time.deltaTime;

        if(timeCount >= instTime)
        {
            Instantiate(atackBox, transform.position, Quaternion.identity);
            timeCount = 0;
        }

        if(moveTime <= 3)
        {
            transform.Translate(Vector2.down * Time.deltaTime);
        }
        else if(moveTime <= 6)
        {
            transform.Translate(Vector2.up * Time.deltaTime);
        }
        else if(moveTime > 6)
        {
            moveTime = 0;
        }
    }
}
