using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testenemy : MonoBehaviour
{
    private enemyBase EB;
    private int cameraNum;

    private bool renderObj;
    private bool firstRenderObj;

    // Start is called before the first frame update
    void Start()
    {
        EB = GetComponent<enemyBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(renderObj == false && firstRenderObj == true)
        {
            Destroy(gameObject);
        }
        else if(transform.position.y < -20)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * EB.speedNum * Time.deltaTime);
        cameraNum = 0;
        renderObj = false;
    }

    private void OnWillRenderObject()
    {
        if (Camera.current.name != "Scene Camera" && Camera.current.name == "Main Camera")
        {
            renderObj = true;
            firstRenderObj = true;
        }
            
    }
}
