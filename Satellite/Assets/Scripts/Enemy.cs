using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int Hp=0;

    // メインカメラを指定
    private const string cameraTagName = "MainCamera";
    // 表示確認(最初はfalse)
    private bool isRendered = false;
    // 攻撃開始までの時間
    public float enemytime = 1.0f;
    // 時間処理計算
    public float timer;
    // 一回だけ弾を撃つための変数
    bool Attack = false;
    // 弾を指定
    public GameObject enemyBullet;
    // アイテムオブジェクトを指定
    public GameObject itemObj;
    // 爆発エフェクトオブジェクトを指定
    public GameObject effect;
    // カメラオブジェクト
    GameObject cameraObj;

    public void Death()
    {
        // エフェクトを表示(やめた)
        //Instantiate(effect, transform.position, effect.transform.rotation);
        // アイテムを表示
        Instantiate(itemObj, transform.position, itemObj.transform.rotation);        
        // デブリをデストロイ
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        // カメラの座標を取得
        cameraObj = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            Death();
        }
        // カメラの範囲に入ったら呼び出されます
        if (isRendered)
        {
            timer += Time.deltaTime;
            // Debug.Log("表示中");
            if (enemytime <= timer)
            {
                // 弾が打てる状態
                if (!Attack)
                {
                    bullet();
                    // 弾を打たなくする
                    Attack = true;
                }
            }
        }

        // カメラの範囲から再度外れたらfalse
        isRendered = false;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Hp -= GameController.Instance.Attack;
            //Debug.Log(Hp);
        }

        //if (collision.gameObject.tag == "explosion")
        //{
        //    Hp--;
        //}
    }

    // 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }    

    // カメラの表示範囲に入ったら動作します
    private void OnWillRenderObject()
    {
        // カメラに表示されたときtrue
        if (Camera.current.tag == cameraTagName)
        {
            isRendered = true;
        }
    }

    // 弾を表示する
    void bullet()
    {
        timer = 0.0f;
        Vector3 position = transform.position;
        position.x += -1;
        
        var bullet = Instantiate(enemyBullet, position,enemyBullet.transform.rotation);
        bullet.transform.Rotate(0,0,180);
    }
}
