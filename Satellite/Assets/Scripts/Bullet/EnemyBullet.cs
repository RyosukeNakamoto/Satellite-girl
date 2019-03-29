using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // オブジェクトに当たったら呼び出されます
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーか判別します
        if (collision.gameObject.tag == "Player")
        {
            // 弾を消します
            Destroy(gameObject);
        }
    }   
}
