using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSelecter : MonoBehaviour
{
    private bool canSelect;

    // Start is called before the first frame update
    void Start()
    {
        canSelect = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 15)
        {
            canSelect = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 15)
        {
            canSelect = false;
        }
    }
}
