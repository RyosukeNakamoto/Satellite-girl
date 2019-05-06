using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{

    float deleteTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deleteTime += Time.deltaTime;

        //3秒を越えると消去
        if (deleteTime > 3)
        {
            Destroy(gameObject);
        }
    }
}
