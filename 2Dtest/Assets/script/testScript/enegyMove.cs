using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enegyMove : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject playerBaseObj;

    private playerBase PB;

    private float speed = 10;

    public int targetNum;
    void Start()
    {
        playerBaseObj = GameObject.Find("playerBaseObj");
        PB = playerBaseObj.GetComponent<playerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,PB.playerTank[targetNum].transform.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, PB.playerTank[targetNum].transform.position) < 0.1)
        {
            Destroy(gameObject);

            if (PB.energy[targetNum] <= PB.maxEnergy[targetNum])
            {
                PB.energy[targetNum]++;
            }
        }
    }
}
