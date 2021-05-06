using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] ropeBase = new GameObject[2];

    [SerializeField]
    private GameObject playerBaseObj;

    [SerializeField]
    private SpriteRenderer rope;

    private playerBase PB;

    void Start()
    {
        PB = playerBaseObj.GetComponent<playerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        ropeBase[0].transform.position = PB.playerTank[0].transform.position;
        ropeBase[1].transform.position = PB.playerTank[1].transform.position;

        if(PB.ropeAttackFlag)
        {
            gameObject.SetLayerRecursively(14);
            rope.color = Color.red;
        }
        else
        {
            gameObject.SetLayerRecursively(10);
            rope.color = Color.white;
        }
    }
}
