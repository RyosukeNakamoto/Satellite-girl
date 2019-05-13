using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    // サウンドを指定
    public AudioClip[] sound;
    // サウンドの変数
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // メインカメラを取得
        camera = Camera.main;
        // オーディオのコンポーネント
        audioSource = GetComponent<AudioSource>();
        // 
        var player = GameObject.FindGameObjectWithTag("Player");
        playerSc = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // HPが0になったら死ぬ
        if (Hp <= 0)
        {
            Death();
        }

        // カメラの範囲に入ったら呼び出されます
        if (isRendered)
        {
            // 時間のカウント
            timer += Time.deltaTime;
            // enemytimeのタイムを経過したか
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
        // カメラより左なら消滅
        if (!isRendered)
        {
            if (camera.transform.position.x - 14 >= gameObject.transform.position.x)
            {
                Destroy(gameObject);
            }
        }
    }

    // デブリが消滅する
    public void Death()
    {
        // サウンドの再生
        audioSource.PlayOneShot(sound[1]);        
        // 爆発エフェクトを出す
        Instantiate(effectObject, transform.position, effectObject.transform.rotation);
        // デブリをデストロイ
        Destroy(gameObject);
        // アイテムを表示
        Vector3 position = transform.position;
        position.x += 1;
        //Instantiate(itemObj, position, itemObj.transform.rotation);
        if (!playerSc.buffUse)
        {
            // プレイヤーのゲージを加算
            playerSc.buffValue += 5;
        }
        else
        {
            Debug.Log("上がらないよ");
            return;
        }
    }

    // 弾を3方向に打つ
    void bullet()
    {
        timer = 0.0f;
        Vector3 position = transform.position;
        position.x += -1;
        var bullet1 = Instantiate(enemyBullet, position, enemyBullet.transform.rotation);
        bullet1.transform.Rotate(0, 0, 135);
        var bullet2 = Instantiate(enemyBullet, position, enemyBullet.transform.rotation);
        bullet2.transform.Rotate(0, 0, 180);
        var bullet3 = Instantiate(enemyBullet, position, enemyBullet.transform.rotation);
        bullet3.transform.Rotate(0, 0, 225);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Hp -= GameController.Instance.Attack;
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
}
