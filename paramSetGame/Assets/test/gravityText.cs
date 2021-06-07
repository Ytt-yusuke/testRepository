using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gravityText : MonoBehaviour
{
    TextMeshProUGUI grav;

    // Start is called before the first frame update
    void Start()
    {
        grav = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        grav.text = Physics2D.gravity.y.ToString("F2");
    }
}
