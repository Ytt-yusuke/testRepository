using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject[] playerTank = new GameObject[2];

    private Vector3 camerapos;

    private Vector3 baseCamrapos;

    private float playerHeight;

    [SerializeField]
    private int cameraNum;
    void Start()
    {
        baseCamrapos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        camerapos = this.transform.position;

        camerapos.x = Vector3.Lerp(playerTank[0].transform.position, playerTank[1].transform.position, 0.5f).x;

        playerHeight = Vector3.Lerp(playerTank[0].transform.position, playerTank[1].transform.position, 0.5f).y;

        if (cameraNum == 1)
        {
            camerapos.y = playerHeight;
        }

        if(cameraNum == 2)
        {
            camerapos.y = baseCamrapos.y + playerHeight;
            camerapos.z = Vector3.Lerp(playerTank[0].transform.position, playerTank[1].transform.position, 0.5f).z;
        }

        this.transform.position = camerapos;
    }
}
