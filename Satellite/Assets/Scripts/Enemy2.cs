﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
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
    //// 左直線
    public GameObject enemyBullet1;
    //// 左斜め上
    public GameObject enemyBullet2;
    //// 左斜め下 
    public GameObject enemyBullet3;
    // 消滅したデブリのカウント
    public int debriCount;
    // アイテムオブジェクトを指定
    public GameObject itemObj;

    public void Death()
    {      
        // アイテムを表示
        Instantiate(itemObj, transform.position, itemObj.transform.rotation);
        // デブリをデストロイ
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Hp == 0)
        {
            //Destroy(gameObject);
            //debriCount++;
            Death();
        }

        // カメラの範囲にいるか確認
        if (isRendered)
        {
            // 時間のカウント
            timer += Time.deltaTime;
            // Debug.Log("表示中");
            // enemytimeのタイムを経過したか
            if (enemytime <= timer)
            {
                // 弾が打てる状態
                if (!Attack)
                {
                    bullet();
                }
                // 弾を打たなくする
                Attack = true;
            }            
        }
        // カメラ範囲から再度外れたらfalse
        isRendered = false;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Hp--;
        }
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

    // 弾を3方向に打つ
    void bullet()
    {
        timer = 0.0f;
        Instantiate(enemyBullet1, new Vector2(transform.position.x - 1, transform.position.y), transform.rotation);
        Instantiate(enemyBullet2, new Vector2(transform.position.x - 1, transform.position.y), transform.rotation);
        Instantiate(enemyBullet3, new Vector2(transform.position.x - 1, transform.position.y), transform.rotation);
    }      
}