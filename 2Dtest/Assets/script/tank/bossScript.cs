using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject boss1BulletPos;
    [SerializeField]
    private GameObject boss1Bullet;
    [SerializeField]
    private GameObject playerBaseObj;

    enemyBase EB;
    playerBase PB;

    void Start()
    {
        EB = gameObject.GetComponent<enemyBase>();
        PB = playerBaseObj.GetComponent<playerBase>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        int playerNum = Random.Range(0, 2);
        GameObject newBullet = Instantiate(boss1Bullet, boss1BulletPos.transform.position, Quaternion.identity) as GameObject;
        newBullet.GetComponent<Rigidbody2D>().AddForce((PB.playerTank[playerNum].transform.position - boss1BulletPos.transform.position).normalized * EB.shotPower);
    }
}
