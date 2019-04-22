using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
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
        // デブリをデストロイ
        Destroy(gameObject);
        // アイテムを表示
        Instantiate(itemObj, transform.position, itemObj.transform.rotation);
    }

    // 弾を表示する
    void bullet()
    {
        timer = 0.0f;
        Vector3 position = transform.position;
        position.x += -1;

        var bullet = Instantiate(enemyBullet, position, enemyBullet.transform.rotation);
        bullet.transform.Rotate(0, 0, 180);

        audioSource.PlayOneShot(sound[0]);
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
