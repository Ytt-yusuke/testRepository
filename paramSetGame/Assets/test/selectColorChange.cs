using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class selectColorChange : MonoBehaviour
{
    [SerializeField]
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject == EventSystem.current.currentSelectedGameObject)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
