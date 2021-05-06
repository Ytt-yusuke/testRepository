using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    // Start is called before the first frame update

    public int playerNum;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 11 || collision.gameObject.layer == 13)
        {
            Destroy(this.gameObject);
        }
    }
}
