using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLerp : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    Vector3 tapPos;
    public float speed;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            startPos = transform.position;
            tapPos = Input.mousePosition;
            tapPos.z = 10.0f;

            // スクリーン座標からワールド座標に変換
            endPos = Camera.main.ScreenToWorldPoint(tapPos);

            // 線形補完的に移動させる
            transform.position = Vector3.Lerp(startPos, endPos, speed * Time.deltaTime);
        }
    }
}