﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : EnemyBullet
{

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {        
        Vector3 pos = transform.position;
        pos += transform.right * speed * Time.deltaTime;
        transform.position = pos;
    }
}
