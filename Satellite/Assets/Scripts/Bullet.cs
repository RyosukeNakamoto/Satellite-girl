using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //弾の移動スピード
    public int speed=30;

    Rigidbody2D rigidbody;

    //武器を数値で管理
    public static int bulletstatus=0;
    //武器のスプライト
    SpriteRenderer bulletsprite;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        bulletsprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //弾の移動
        rigidbody.velocity = transform.right.normalized * speed;

        switch (bulletstatus)
        {
            //ライフル
            case 0:
                speed = 40;
                bulletsprite.color = Color.white;
                break;
            //マシンガン
            case 1:
                speed = 20;
                bulletsprite.color = Color.yellow;
                break;
            //バズーカ
            case 2:
                speed = 60;
                bulletsprite.color = Color.green;
                break;
        }
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
