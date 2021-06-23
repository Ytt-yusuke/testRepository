using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyUIPos : MonoBehaviour
{
    [SerializeField]
    GameObject playerObj;

    private playerBase PB;

    private RectTransform RT;

    private Camera maincamera;

    // Start is called before the first frame update
    void Start()
    {
        PB = playerObj.GetComponent<playerBase>();
        RT = GetComponent<RectTransform>();
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (PB.hackFlag == true)
        {
            if (PB.selected.Count == 1)
            {
                var pos = PB.selected[0].transform.position + new Vector3(0, 4, 0);
                var center = 0.5f * new Vector3(Screen.width, Screen.height, 0);

                if (maincamera.WorldToScreenPoint(PB.selected[0].transform.position).x - center.x <= -148)
                {
                    pos.x = maincamera.ScreenToWorldPoint(new Vector3(-148f + center.x, 0, 0)).x;
                }
                else if (maincamera.WorldToScreenPoint(PB.selected[0].transform.position).x - center.x >= 148f)
                {
                    pos.x = maincamera.ScreenToWorldPoint(new Vector3(148f + center.x, 0, 0)).x;
                }

                if (maincamera.WorldToScreenPoint(pos).y - center.y <= -86.5)
                {
                    pos.y = maincamera.ScreenToWorldPoint(new Vector3(0, -86.5f + center.y, 0)).y;
                }
                else if (maincamera.WorldToScreenPoint(pos).y - center.y >= 30)
                {
                    pos.y = maincamera.ScreenToWorldPoint(new Vector3(0, 30f + center.y, 0)).y;
                }

                transform.position = pos;
            }
            else if(PB.selected.Count > 1)
            {
                var pos = new Vector3(0, 0, 0);
                var center = 0.5f * new Vector3(Screen.width, Screen.height, 0);
                int count = 0;

                foreach(GameObject obj in PB.selected)
                {
                    pos.x += PB.selected[count].transform.position.x;
                    pos.y += PB.selected[count].transform.position.y;
                    count++;
                }

                pos.x /= PB.selected.Count;
                pos.y /= PB.selected.Count;
                pos.y += 4;

                if (maincamera.WorldToScreenPoint(pos).x - center.x <= -148)
                {
                    pos.x = maincamera.ScreenToWorldPoint(new Vector3(-148f + center.x, 0, 0)).x;
                }
                else if (maincamera.WorldToScreenPoint(pos).x - center.x >= 148f)
                {
                    pos.x = maincamera.ScreenToWorldPoint(new Vector3(148f + center.x, 0, 0)).x;
                }

                if (maincamera.WorldToScreenPoint(pos).y - center.y <= -86.5)
                {
                    pos.y = maincamera.ScreenToWorldPoint(new Vector3(0, -86.5f + center.y, 0)).y;
                }
                else if (maincamera.WorldToScreenPoint(pos).y - center.y >= 30)
                {
                    pos.y = maincamera.ScreenToWorldPoint(new Vector3(0, 30 + center.y, 0)).y;
                }

                transform.position = pos;
            }
        }
    }
}
