using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISizeSet : MonoBehaviour
{
    public bool ImageObj;
    public bool HPObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ImageObj == true)
        {
            ImageSizeSet();
        }

        if (HPObj == true)
        {
            HPPosSet();
        }
    }

    private void ImageSizeSet()
    {
        var rootRT = transform.root.gameObject.GetComponent<RectTransform>();
        var myRT = GetComponent<RectTransform>();

        myRT.sizeDelta = rootRT.sizeDelta * 1.5f;
        myRT.localPosition = Vector3.zero;
    }

    private void HPPosSet()
    {
        var rootRT = transform.root.gameObject.GetComponent<RectTransform>();
        var myRT = GetComponent<RectTransform>();

        myRT.localPosition = new Vector3(-rootRT.sizeDelta.x / 4, rootRT.sizeDelta.y / 10 * 4, 0);
    }
}
