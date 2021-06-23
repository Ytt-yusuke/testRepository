using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemyUISet : MonoBehaviour
{
    [SerializeField]
    GameObject playerObj;

    private playerBase PB;

    public Toggle allies;
    public Toggle obj;
    public Toggle canMove;
    public Slider size;
    public Button destroyButton;
    public Button setButton;
    public TextMeshProUGUI sizeText;

    // Start is called before the first frame update

    private void Awake()
    {
        PB = playerObj.GetComponent<playerBase>();
    }
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        sizeText.text = size.value.ToString();

        if(obj.isOn == true)
        {
            canMove.gameObject.SetActive(true);
            destroyButton.gameObject.SetActive(true);
            var moveNav = obj.navigation;
            moveNav.selectOnRight = canMove;
            var destroyNav = destroyButton.navigation;
            destroyNav.selectOnRight = setButton;
            var setNav = setButton.navigation;
            setNav.selectOnLeft = destroyButton;
        }
        else
        {
            canMove.gameObject.SetActive(false);
            destroyButton.gameObject.SetActive(false);
            var moveNav = obj.navigation;
            moveNav.selectOnRight = null;
            var destroyNav = destroyButton.navigation;
            destroyNav.selectOnRight = null;
            var setNav = setButton.navigation;
            setNav.selectOnLeft = null;
        }
    }

    public void SetEnemy()
    {
        for(int i = 0; i < PB.selected.Count; i++)
        {
            var EB = PB.selected[i].GetComponent<enemyBase>();
            EB.sizeValue = (int)size.value;
            EB.alliesIsON = allies.isOn;
            EB.objectIsON = obj.isOn;
            EB.objMove = canMove.isOn;
            EB.SetHP();
        }
    }

    public void DestroyObj()
    {
        while(PB.selected[0] != null)
        {
            Destroy(PB.selected[0]);
        }
    }

    private void OnEnable()
    {
        if (PB.hackFlag == true)
        {
            if (PB.selected.Count == 1)
            {
                var EB = PB.selected[0].GetComponent<enemyBase>();
                size.value = EB.sizeValue;
                allies.isOn = EB.alliesIsON;
                obj.isOn = EB.objectIsON;

                if(allies.isOn == false && obj.isOn == false)
                {
                    allies.isOn = true;
                }

                canMove.isOn = EB.objMove;
            }
            else if (PB.selected.Count >= 2)
            {
                size.value = 2;
                allies.isOn = true;
                obj.isOn = false;
                canMove.isOn = false;
            }
        }
    }
}
