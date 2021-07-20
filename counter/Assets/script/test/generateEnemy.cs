using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject shotBase;

    private float timeNum;
    private float moveTime;

    private float randomTime;

    [SerializeField]
    float min;

    [SerializeField]
    float max;

    // Start is called before the first frame update
    void Start()
    {
        randomTime = Random.Range(min, max);
    }

    // Update is called once per frame
    void Update()
    {
        timeNum += Time.deltaTime;
        moveTime += Time.deltaTime;

        if(timeNum >= randomTime)
        {
            Instantiate(shotBase, transform.position, Quaternion.identity);
            randomTime = Random.Range(min, max);
            timeNum = 0;
        }

        transform.position = new Vector3(Mathf.Sin(moveTime) * 20, 1.5f, 0);
    }
}
