using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sliderNum : MonoBehaviour
{
    [SerializeField]
    private Slider param;

    TextMeshProUGUI num;
    // Start is called before the first frame update
    void Start()
    {
        num = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        num.text =  param.value.ToString("F2");
    }
}
