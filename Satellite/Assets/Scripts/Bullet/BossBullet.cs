using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : EnemyBullet
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos -= transform.right * speed * Time.deltaTime;
        transform.position = pos;

        switch (GameController.Instance.stage)
        {
            case 0:
                damage = 10;
                break;
            case 1:
                damage = 30;
                break;
            case 2:
                damage = 60;
                break;
        }
    }
}
