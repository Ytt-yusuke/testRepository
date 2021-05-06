using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    [SerializeField]
    GameObject scoreText;

    [SerializeField]
    GameObject playerBaseObj;

    playerBase PB;

    // Start is called before the first frame update
    void Start()
    {
        PB = playerBaseObj.GetComponent<playerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        TextMesh score = scoreText.GetComponent<TextMesh>();

        score.text = "Defeats:" + PB.defeats;
    }
}
