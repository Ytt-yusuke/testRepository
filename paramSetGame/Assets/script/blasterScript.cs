using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class blasterScript : MonoBehaviour
{
    public Slider bulletSize;

    public Slider shotRange;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject playerObj;

    [SerializeField]
    private TextMeshProUGUI sizeText;

    [SerializeField]
    private TextMeshProUGUI rangeText;

    public float[] bulletRange;
    public float[] bulletScale;
    public float[] bulletDamage;
    public float[] chargeTime;

    private bool canShot;

    private float reloadTime;
    private float setTime;
    private float blasterDist;

    private Vector3 bulletDist;

    bulletScript BS;

    // Start is called before the first frame update
    void Start()
    {
        canShot = true;
        transform.position = playerObj.transform.position + new Vector3(1, 0.7f, 0);
        bulletDist = new Vector3(1,0,0);
        blasterDist = 1;
        BS = bullet.GetComponent<bulletScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = playerObj.transform.position + new Vector3(1, 0.7f, 0);
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            bulletDist = new Vector3(1,0,0);
            blasterDist = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = playerObj.transform.position + new Vector3(-1, 0.7f, 0);
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            bulletDist = new Vector3(-1,0,0);
            blasterDist = -1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = playerObj.transform.position + new Vector3(0, 1.7f, 0);
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            bulletDist = new Vector3(0,1,0);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (canShot)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                BS.bulletSpeed = bulletDist * 10;
                canShot = false;
                reloadTime = 0;
            }

        }

        transform.localScale = new Vector3(transform.localScale.x * blasterDist, transform.localScale.y, transform.localScale.z);
        reloadTime += Time.deltaTime;
        SettingBullet((int)bulletSize.value, (int)shotRange.value, BS, bullet);
        rangeText.text = BS.dist.ToString();
        sizeText.text = bullet.transform.localScale.x.ToString();



        if (reloadTime >= setTime)
        {
            canShot = true;
        }
    }

    void SettingBullet(int bulletSize, int shotRange, bulletScript BS, GameObject bullet)
    {
        setTime = chargeTime[bulletSize];
        bullet.transform.localScale = Vector3.one * bulletScale[bulletSize];
        BS.dist = bulletRange[shotRange];
        BS.damage = bulletDamage[shotRange];
    }
}
