using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroler : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerNum;

    private float speed;
    private float power;
    private float[] stickR;
    private float[] stickL;
    private float scale;

    [SerializeField]
    Transform cannonPoint;

    [SerializeField]
    GameObject playerBaseObj;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject shotPoint;

    [SerializeField]
    private GameObject energyInstance;

    [SerializeField]
    private Slider energySlider;

    [SerializeField]
    private SpriteRenderer player;

    public bool shootMode;
    public bool shootFlag;

    private Vector3[] playerDist = new Vector3[2];
    private Vector3[] controlVector = new Vector3[2];
    private Vector3 directVector;
    private Vector3 baseScale;
    private Vector3 playerDirect;
    private Vector3[] keyShootPos = new Vector3[2];

    private playerBase PB;
    private playerAnimScript PA;

    void Start()
    {
        shootMode = false;
        shootFlag = false;
        directVector = Vector3.one;
        scale = 1;
        baseScale = transform.localScale;
        playerDirect = baseScale;

        energySlider.value = 0;

        PB = playerBaseObj.GetComponent<playerBase>();
        PA = playerBaseObj.GetComponent<playerAnimScript>();

        speed = PB.speed;

        PA.playerAnimator[0].SetBool("ShootMode", false);
        PA.playerAnimator[1].SetBool("ShootMode", false);

        if (this.gameObject == PB.playerTank[0])
        {
            power =  PB.power[0];
        }
        else if(this.gameObject == PB.playerTank[1])
        {
            power = PB.power[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        controlVector[0] = Vector3.zero;
        controlVector[1] = Vector3.zero;
        keyShootPos[0] = Vector3.zero;
        keyShootPos[1] = Vector3.zero;
        playerDist[0] = PB.playerTank[0].transform.position - PB.playerTank[1].transform.position;
        playerDist[1] = PB.playerTank[1].transform.position - PB.playerTank[0].transform.position;

        if (PB.keyMode == false)
        {
            stickR = PB.joyconR.GetStick();
            stickL = PB.joyconL.GetStick();
        }

        if(PB.ropeAttackFlag == true)
        {
            player.color = Color.red;
            gameObject.layer = 14;
        }
        else
        {
            player.color = Color.white;
            gameObject.layer = 8;
        }

        if (this.gameObject == PB.playerTank[0])
        {
            power = PB.power[0];
        }
        else if (this.gameObject == PB.playerTank[1])
        {
            power = PB.power[1];
        }

        if (PB.keyMode == true)
        {

            if (Input.GetKey(KeyCode.P) && this.gameObject == PB.playerTank[0] || Input.GetKey(KeyCode.Q) && this.gameObject == PB.playerTank[1])
            {

                if (this.gameObject == PB.playerTank[0])
                {
                    PB.playerTank[1].transform.position = Vector3.Lerp(PB.playerTank[1].transform.position, PB.playerTank[0].transform.position, PB.attractSpeed * Time.deltaTime);
                }
                else if (this.gameObject == PB.playerTank[1])
                {
                    PB.playerTank[0].transform.position = Vector3.Lerp(PB.playerTank[0].transform.position, PB.playerTank[1].transform.position, PB.attractSpeed * Time.deltaTime);
                }
            }

            if (Input.GetKey(KeyCode.M) && this.gameObject == PB.playerTank[0] || Input.GetKey(KeyCode.X) && this.gameObject == PB.playerTank[1])
            {
                if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject == PB.playerTank[0] || Input.GetKey(KeyCode.A) && this.gameObject == PB.playerTank[1])
                {
                    if (this.gameObject == PB.playerTank[0])
                    {
                        keyShootPos[0] += new Vector3(-1, 0, 0);
                    }
                    else if (this.gameObject == PB.playerTank[1])
                    {
                        keyShootPos[1] += new Vector3(-1, 0, 0);
                    }

                    setDirect(1);
                }

                if (Input.GetKey(KeyCode.RightArrow) && this.gameObject == PB.playerTank[0] || Input.GetKey(KeyCode.D) && this.gameObject == PB.playerTank[1])
                {
                    if (this.gameObject == PB.playerTank[0])
                    {
                        keyShootPos[0] += new Vector3(1, 0, 0);
                    }
                    else if (this.gameObject == PB.playerTank[1])
                    {
                        keyShootPos[1] += new Vector3(1, 0, 0);
                    }

                    setDirect(0);
                }
                
                if (Input.GetKey(KeyCode.UpArrow) && this.gameObject == PB.playerTank[0] || Input.GetKey(KeyCode.W) && this.gameObject == PB.playerTank[1])
                {
                    if (this.gameObject == PB.playerTank[0])
                    {
                        keyShootPos[0] += new Vector3(0, 1, 0);
                    }
                    else if (this.gameObject == PB.playerTank[1])
                    {
                        keyShootPos[1] += new Vector3(0, 1, 0);
                    }
                }
                
                if (Input.GetKey(KeyCode.DownArrow) && this.gameObject == PB.playerTank[0] || Input.GetKey(KeyCode.S) && this.gameObject == PB.playerTank[1])
                {
                    if (this.gameObject == PB.playerTank[0])
                    {
                        keyShootPos[0] += new Vector3(0, -1, 0);
                    }
                    else if (this.gameObject == PB.playerTank[1])
                    {
                        keyShootPos[1] += new Vector3(0, -1, 0);
                    }
                }

                if (this.gameObject == PB.playerTank[0])
                {
                    shotPoint.transform.position = keyShootPos[0] + PB.playerTank[0].transform.position;
                    if (shootMode == false)
                    {
                        PA.SetAnimShoot(0);
                    }
                }
                else if (this.gameObject == PB.playerTank[1])
                {
                    shotPoint.transform.position = keyShootPos[1] + PB.playerTank[1].transform.position;
                    if (shootMode == false)
                    {
                        PA.SetAnimShoot(1);
                    }
                }

                if (Input.GetKeyDown(KeyCode.L) && this.gameObject == PB.playerTank[0] || Input.GetKeyDown(KeyCode.Space) && this.gameObject == PB.playerTank[1])
                {
                    if (this.gameObject == PB.playerTank[0] && keyShootPos[0] != new Vector3(0,0,0))
                    {
                        Shoot(0);
                    }
                    else if (this.gameObject == PB.playerTank[1] && keyShootPos[1] != new Vector3(0,0,0))
                    {
                        Shoot(1);
                    }
                }

                shootMode = true;
            }
            else
            {
                if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.T))
                {
                    if(PB.energy[0] >= 10 && PB.energy[1] >= 10 && PB.ropeAttackFlag == false)
                    {
                        PB.ropeAttackFlag = true;
                        PB.energy[0] -= 10;
                        PB.energy[1] -= 10;
                    }
                }

                if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject == PB.playerTank[0] || Input.GetKey(KeyCode.A) && this.gameObject == PB.playerTank[1])
                {
                    if (this.gameObject == PB.playerTank[0])
                    {
                        controlVector[0] += new Vector3(-1, 0, 0);
                    }
                    else if (this.gameObject == PB.playerTank[1])
                    {
                        controlVector[1] += new Vector3(-1, 0, 0);
                    }

                    setDirect(1);
                }

                if (Input.GetKey(KeyCode.RightArrow) && this.gameObject == PB.playerTank[0] || Input.GetKey(KeyCode.D) && this.gameObject == PB.playerTank[1])
                {
                    if (this.gameObject == PB.playerTank[0])
                    {
                        controlVector[0] += new Vector3(1, 0, 0);
                    }
                    else if (this.gameObject == PB.playerTank[1])
                    {
                        controlVector[1] += new Vector3(1, 0, 0);
                    }

                    setDirect(0);
                }

                if (Input.GetKey(KeyCode.UpArrow) && this.gameObject == PB.playerTank[0] || Input.GetKey(KeyCode.W) && this.gameObject == PB.playerTank[1])
                {
                    if (this.gameObject == PB.playerTank[0])
                    {
                        controlVector[0] += new Vector3(0, 1, 0);
                    }
                    else if (this.gameObject == PB.playerTank[1])
                    {
                        controlVector[1] += new Vector3(0, 1, 0);
                    }
                }

                if (Input.GetKey(KeyCode.DownArrow) && this.gameObject == PB.playerTank[0] || Input.GetKey(KeyCode.S) && this.gameObject == PB.playerTank[1])
                {
                    if (this.gameObject == PB.playerTank[0])
                    {
                        controlVector[0] += new Vector3(0, -1, 0);
                    }
                    else if (this.gameObject == PB.playerTank[1])
                    {
                        controlVector[1] += new Vector3(0, -1, 0);
                    }
                }
                if (shootMode == true)
                {
                    if (this.gameObject == PB.playerTank[0])
                    {
                        PA.SetAnimNomal(0);
                    }
                    else if (this.gameObject == PB.playerTank[1])
                    {
                        PA.SetAnimNomal(1);
                    }
                }

                shootMode = false;
            }
        }
        else
        {
            if (PB.joyconR.GetButton(Joycon.Button.SR) && this.gameObject == PB.playerTank[0] || PB.joyconL.GetButton(Joycon.Button.SR) && this.gameObject == PB.playerTank[1])
            {
                if (this.gameObject == PB.playerTank[0])
                {
                    shotPoint.transform.position = new Vector3(stickR[1], -stickR[0], 0) + PB.playerTank[0].transform.position;

                    if (stickR[1] < 0)
                    {
                        setDirect(1);
                    }
                    else if (stickR[1] > 0)
                    {
                        setDirect(0);
                    }

                    if (stickR[0] != 0 || stickR[1] != 0)
                    {
                        if (PB.joyconR.GetButtonDown(Joycon.Button.DPAD_RIGHT) && shootFlag == false)
                        {
                            Shoot(0);
                            shootFlag = true;
                        }
                    }

                    if (PB.joyconR.GetButtonUp(Joycon.Button.DPAD_RIGHT))
                    {
                        shootFlag = false;
                    }
                }
                else if (this.gameObject == PB.playerTank[1])
                {
                    shotPoint.transform.position = new Vector3(-stickL[1], stickL[0], 0) + PB.playerTank[1].transform.position;

                    if (-stickL[1] < 0)
                    {
                        setDirect(1);
                    }
                    else if (-stickL[1] > 0)
                    {
                        setDirect(0);
                    }

                    if (stickL[0] != 0 || stickL[1] != 0)
                    {
                        if (PB.joyconL.GetButtonDown(Joycon.Button.DPAD_LEFT) && shootFlag == false)
                        {
                            Shoot(1);
                            Debug.Log("SHOOT!!");
                            shootFlag = true;
                        }
                    }

                    if (PB.joyconL.GetButtonUp(Joycon.Button.DPAD_LEFT))
                    {
                        shootFlag = false;
                    }
                }

                if (shootMode == false)
                {
                    if (this.gameObject == PB.playerTank[0])
                    {
                        PA.SetAnimShoot(0);
                    }
                    else if (this.gameObject == PB.playerTank[1])
                    {
                        PA.SetAnimShoot(1);
                    }
                }

                shootMode = true;
            }
            else
            {
                if (this.gameObject == PB.playerTank[0])
                {
                    controlVector[0] += new Vector3(stickR[1], -stickR[0], 0);

                    if (stickR[1] < 0)
                    {
                        setDirect(1);
                    }
                    else if (stickR[1] > 0)
                    {
                        setDirect(0);
                    }
                }
                else if (this.gameObject == PB.playerTank[1])
                {
                    controlVector[1] += new Vector3(-stickL[1], stickL[0], 0);

                    if (-stickL[1] < 0)
                    {
                        setDirect(1);
                    }
                    else if (-stickL[1] > 0)
                    {
                        setDirect(0);
                    }
                }

                if (shootMode == true)
                {
                    if (this.gameObject == PB.playerTank[0])
                    {
                        PA.SetAnimNomal(0);
                    }
                    else if (this.gameObject == PB.playerTank[1])
                    {
                        PA.SetAnimNomal(1);
                    }
                }

                shootMode = false;
                shootFlag = false;
            }
        }

        PB.playerTank[0].transform.Translate(controlVector[0] * speed * Time.deltaTime);
        PB.playerTank[1].transform.Translate(controlVector[1] * speed * Time.deltaTime);

        transform.localScale = playerDirect * scale;

        energySlider.value = PB.energy[playerNum] / PB.maxEnergy[playerNum];
    }

    void Shoot(int num)
    {
        GameObject newBullet = Instantiate(bullet, cannonPoint.position, Quaternion.identity) as GameObject;
        newBullet.GetComponent<Rigidbody2D>().AddForce((shotPoint.transform.position - PB.playerTank[num].transform.position).normalized * power);

        if (this.gameObject == PB.playerTank[0])
        {
            newBullet.GetComponent<playerBullet>().playerNum = 0;
        }
        else if (this.gameObject == PB.playerTank[1])
        {
            newBullet.GetComponent<playerBullet>().playerNum = 1;
        }
    }

    void setDirect(int num)
    {
        if(num == 0)
        {
            directVector = new Vector3(1, 1, 1);
            playerDirect = new Vector3(baseScale.x * directVector.x, baseScale.y * directVector.y, baseScale.z * directVector.z);
        }

        if(num == 1)
        {
            directVector = new Vector3(-1, 1, 1);
            playerDirect = new Vector3(baseScale.x * directVector.x, baseScale.y * directVector.y, baseScale.z * directVector.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 15)
        {
            PB.HP--;
        }
    }
}
