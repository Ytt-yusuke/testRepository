using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragScript : MonoBehaviour
{
    [SerializeField]
    GameObject space;

    private Vector3 position;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 2)
        {
            var spaceObj = GameObject.FindWithTag("Space");

            if (Input.GetMouseButtonDown(0))
            {
                if (spaceObj != null)
                {
                    Destroy(spaceObj);
                    count = 0;
                }
            }
        }

        if (count == 0)
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(space, position, Quaternion.identity);
                count++;
            }
        }
    }
}

