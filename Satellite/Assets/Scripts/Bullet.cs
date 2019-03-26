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

    //private bool isRendered = false;

    //private const string cameraTagName = "MainCamera";

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        bulletsprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (isRendered == true)
        //{
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
                // Debug.Log("画面外");
                Destroy(gameObject);
            }

            //OnBecameInvisible();
            //if (!GetComponent<SpriteRenderer>().isVisible)
            //{
            //    Debug.Log("消えた");
            //    Destroy(gameObject);
            //}
       // }
                  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {            
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {            
            Destroy(gameObject);
        }
    }

    //// カメラの範囲外に出た際に呼び出されます。
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}
    // カメラの表示範囲に入ったら動作します
    //private void OnWillRenderObject()
    //{
    //    // カメラに表示されたときtrue
    //    if (Camera.current.tag == cameraTagName)
    //    {
    //        isRendered = true;
    //    }        
    //}
}
