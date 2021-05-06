using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class institateTest : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject pbobj;

    private playerBase pb;

    float count;
    void Start()
    {
        pb = pbobj.GetComponent<playerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if (count >= 1)
        {
            GameObject newenergy = Instantiate(pb.energyObj, transform.position, Quaternion.identity);
            count = 0;
        }
    }
}
