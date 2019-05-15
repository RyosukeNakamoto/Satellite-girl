using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : Enemy
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

        enemyAnimator = GetComponent<Animator>();
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
                    StartCoroutine("AimShotThreeConsecutive");
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
        Instantiate(itemObj, position, itemObj.transform.rotation);
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

    //プレイヤーに向かって弾3発発射
    IEnumerator AimShotThreeConsecutive()
    {
        for (int i = 0; i < 2; i++)
        {
            //座標を変数posに保存
            var position = this.gameObject.transform.position;
            //弾のプレハブを作成
            var bullet = Instantiate(enemyBullet) as GameObject;
            //弾のプレハブの位置を自分の位置にする
            bullet.transform.position = position;

            //プレイヤーの位置から自分の位置を引く
            Vector2 vec = playerSc.transform.position - position;
            //弾のRigidBody2Dコンポネントのvelocityに、求めたベクトルを入れて力を加える
            bullet.GetComponent<Rigidbody2D>().velocity = vec;
            //音の再生
            audioSource.PlayOneShot(sound[0]);
            //0.5秒弾の間隔を空ける
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Hp -= GameController.Instance.Attack;
            StartCoroutine(DamageIEnumeretor());
            Debug.Log(Hp);
        }
    }

    IEnumerator DamageIEnumeretor()
    {
        enemyAnimator.SetBool("Damage", true);
        yield return new WaitForSeconds(1.0f);
        enemyAnimator.SetBool("Damage", false);
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
