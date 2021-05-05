using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    private playerBase PB;

    [SerializeField]
    

    void Start()
    {
        PB = gameObject.GetComponent<playerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PB.defeats >= PB.defeatsLimit || PB.bossDefeatFlag == true)
        {
            SceneManager.LoadSceneAsync("endscene");
        }
    }
}
