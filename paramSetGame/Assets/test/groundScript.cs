using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class groundScript : MonoBehaviour
{
    [SerializeField]
    private PhysicsMaterial2D bounce;

    [SerializeField]
    private PhysicsMaterial2D normal;

    public TMP_Dropdown chara;

    private Collider2D groundCollider;

    public float damageTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        chara.value = 0;
        groundCollider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (chara.value)
        {
            case 0:
                groundCollider.sharedMaterial = normal;
                break;

            case 1:
                groundCollider.sharedMaterial = normal;
                break;

            case 2:
                groundCollider.sharedMaterial = bounce;
                break;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (chara.value == 1)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                var PB = collision.gameObject.GetComponent<playerBase>();

                if (PB.groundDamageTime > damageTime && PB.HPNum > 0)
                {
                    PB.HPNum--;
                    PB.groundDamageTime = 0;
                }
            }
            else if (collision.gameObject.CompareTag("Enemy"))
            {
                var EB = collision.gameObject.GetComponent<enemyBase>();

                if (EB.damageTime > damageTime && EB.HPNum > 0)
                {
                    EB.HPNum--;
                    EB.damageTime = 0;
                }
            }
        }
    }
}
