﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanceEnemy : MonoBehaviour
{
    public GameObject enemy;
    private enemyBase EB;
    private float time;
    public float[] instanceTime;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        EB = enemy.GetComponent<enemyBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= instanceTime[EB.enemyNum])
        {
            Instantiate(enemy, transform);
            time = 0;
        }
        time += Time.deltaTime;
    }
}
