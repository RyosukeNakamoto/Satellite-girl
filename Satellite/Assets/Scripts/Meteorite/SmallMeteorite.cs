using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMeteorite : Meteorite
{
    // サウンドを指定
    public AudioClip[] sound;
    // サウンドの変数
    AudioSource audioSource;

    // デブリが消滅する
    public void Death()
    {
        // サウンドの再生
        audioSource.PlayOneShot(sound[0]);
        // 爆発エフェクトを出す
        Instantiate(effectObject, transform.position, effectObject.transform.rotation);
        // デブリをデストロイ
        Destroy(gameObject);
    }

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
        if (hp <= 0)
        {
            Death();
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

    // 当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= GameController.Instance.Attack;
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
