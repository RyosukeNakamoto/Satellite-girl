using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{

    float deleteTime = 0;
    Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
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

        if (Time.timeScale == 1)
        {
            //レーザーの移動
            this.transform.Translate(-0.5f, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collider.isTrigger = true;
        }
    }
}
