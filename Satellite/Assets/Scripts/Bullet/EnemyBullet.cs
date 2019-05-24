using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    // 着弾エフェクト
    [SerializeField]
    private GameObject landing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // オブジェクトに当たったら呼び出されます
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーか判別します
        if (collision.gameObject.tag == "Player")
        {
            // 着弾エフェクトを出す
            Instantiate(landing, transform.position, landing.transform.rotation);
            // 弾を消します
            Destroy(gameObject);
        }
    }
}
