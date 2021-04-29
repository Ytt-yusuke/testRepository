using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator[] playerAnimator = new Animator[2];

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnimShoot(int num)
    {
        playerAnimator[num].SetBool("ShootMode", true);
        playerAnimator[num].Play("ShootState");
    }

    public void SetAnimNomal(int num)
    {
        playerAnimator[num].SetBool("ShootMode", false);
        playerAnimator[num].Play("NormalState");
    }
}
