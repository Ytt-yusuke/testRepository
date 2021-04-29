using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBase : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;
    public float attractSpeed = 1f;
    public float limitSet = 5f;
    public float[] power = new float[2];
    public bool keyMode;

    public GameObject[] playerTank = new GameObject[2];

    private playercontroler[] PC = new playercontroler[2];

    private List<Joycon> joycons;
    public Joycon joyconL;
    public Joycon joyconR;

    void Start()
    {
        PC[0] = playerTank[0].GetComponent<playercontroler>();
        PC[1] = playerTank[1].GetComponent<playercontroler>();
        joycons = JoyconManager.Instance.j;
        joyconL = joycons.Find(c => c.isLeft); // Joy-Con (L)
        joyconR = joycons.Find(c => !c.isLeft); // Joy-Con (R)
    }

    // Update is called once per frame
    void Update()
    {

    }
}
