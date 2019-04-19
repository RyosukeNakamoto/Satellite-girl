using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int Hp = 0;

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
    // カメラオブジェクト
    GameObject cameraObj;
    // サウンドを指定
    public AudioClip[] sound;
    // サウンドの変数
    AudioSource audioSource;
    // カメラの変数
    public Camera camera;


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
        if (Hp <= 0)
        {
            Death();
        }
        // カメラの範囲に入ったら呼び出されます
        if (isRendered)
        {
            timer += Time.deltaTime;
            if (enemytime <= timer)
            {
                // 弾が打てる状態
                if (!Attack)
                {
                    bullet();
                    // サウンドの再生

                    // 弾を打たなくする
                    Attack = true;
                }
            }
        }

        // カメラの範囲から再度外れたらfalse
        isRendered = false;
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


}
