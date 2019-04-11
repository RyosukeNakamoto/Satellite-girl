﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;

    // 速度
    public float speed = 100.0f;
    //プレイヤーの位置
    private Vector2 player_pos;
    //プレイヤーのHP
    public float hp = 100f;
    // 
    public Slider hpslider;
    // 
    float maxhp = 100f;

    //ダメージフラグ
    public bool ondamage = false;
    public static SpriteRenderer renderer;
    private float Damage = 25f;
    //ゲームオーバー表示
    public GameObject gameOver;
    // ゲームクリア表示
    public GameObject gameClear;

    //武器を数値で管理
    public static int bulletstatus = 1;
    // 
    public GameObject camera;
    //発射する弾
    public GameObject rifleBullet;      // ライフル
    public GameObject machinegunBullet; // マシンガン
    public GameObject bazookaBullet;    // バズーカ
    //発射間隔の時間
    public float bulletderay;
    private float timer;

    //--------------------------
    //(仮)
    // スコアの値
    public static int score;
    // スコアテキストコンポーネント
    Text scoretext;
    // スコアテキストオブジェクトの参照
    public GameObject scoreObj;
    //　アイテムの点数
    int itemScore = 5;
    //--------------------------

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        Time.timeScale = 1.0f;
        hpslider.maxValue = maxhp;
        hpslider.value = hp;        

        //--------------------------
        //(仮)
        // スコアテキストのコンポーネント
        scoretext = scoreObj.GetComponent<Text>();
        // スコアを0で初期化
        score = 0;
        scoretext.text = "Score: " + score;

        //--------------------------
    }

    // Update is called once per frame
    void Update()
    {
        //HPが0以下になったときの処理
        if (hp <= 0)
        {
            Destroy(gameObject);
            gameOver.SetActive(true);
        }

        //ダメージを受けた時点滅
        if (ondamage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            //renderer.color = new Color(1f, 1f, 1f, level);
        }
        

        // 移動処理
        Move();
        //移動制限
        Clamp();
        //弾を発射する処理
        Shot();
        //発射間隔の時間計測
        timer += Time.deltaTime;
    }

    // 移動関数
    void Move()
    {
        //矢印キーの入力情報を取得
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //移動する向きを作成
        Vector2 direction = new Vector2(x, y).normalized;

        //移動する向きとスピードを代入
        rigidbody.velocity = direction * speed;
    }

    //プレイヤーの移動制限関数
    void Clamp()
    {
        //現在位置を代入
        player_pos = transform.position;
        //横の移動の制限
        player_pos.x = Mathf.Clamp(player_pos.x, camera.transform.position.x - 11.0f, camera.transform.position.x + 11.0f);
        //縦の移動制限
        player_pos.y = Mathf.Clamp(player_pos.y, -4.9f, 4.9f);
        transform.position = new Vector2(player_pos.x, player_pos.y);
    }

    //弾の発射関数
    void Shot()
    {       
        //弾の発射間隔を弾の状態で変更

        //ライフルを装備中の発射間隔
        if (bulletstatus == 0)
        {
            bulletderay = 0.5f;

            //Spaceキーを押したとき弾を発射
            if (Input.GetKey(KeyCode.Space) && timer > bulletderay || Input.GetKey("joystick button 1") && timer > bulletderay)
            {
                //弾を発射する間隔の時間計測の初期化
                timer = 0.0f;

                //弾の実体化
                Instantiate(rifleBullet, new Vector2(transform.position.x + 1.5f, transform.position.y), transform.rotation);
            }
        }

        //マシンガンを装備中の発射間隔
        if (bulletstatus == 1)
        {
            bulletderay = 0.1f;

            //Spaceキーを押したとき弾を発射
            if (Input.GetKey(KeyCode.Space) && timer > bulletderay || Input.GetKey("joystick button 1") && timer > bulletderay)
            {
                //弾を発射する間隔の時間計測の初期化
                timer = 0.0f;

                //弾の実体化
                Instantiate(machinegunBullet, new Vector2(transform.position.x + 1.5f, transform.position.y), transform.rotation);
            }
        }

        //バズーカを装備中の発射間隔
        if (bulletstatus == 2)
        {
            bulletderay = 0.8f;

            //Spaceキーを押したとき弾を発射
            if (Input.GetKey(KeyCode.Space) && timer > bulletderay || Input.GetKey("joystick button 1") && timer > bulletderay)
            {
                //弾を発射する間隔の時間計測の初期化
                timer = 0.0f;

                //弾の実体化
                Instantiate(bazookaBullet, new Vector2(transform.position.x + 1.5f, transform.position.y), transform.rotation);
            }
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ダメージ処理
        if (!ondamage && collision.gameObject.tag == "Enemy")
        {
            //HPバーを減らす（プロト版）
            hpslider.value -= Damage;
            //敵からのダメージ(プロト版)
            hp -= Damage;
            OndamageEffect();
        }

        // スコアの加算
        if (collision.gameObject.tag == "Item")
        {
            score += itemScore;
            // スコア内容の変更
            scoretext.text = "Score: " + score;
            
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ////ダメージ処理
        //if (!ondamage && collision.gameObject.tag == "Enemy")
        //{
        //    //HPバーを減らす（プロト版）
        //    hpslider.value -= Damage;
        //    //敵からのダメージ(プロト版)
        //    hp -= Damage;
        //    OndamageEffect();
        //}

        ////--------------------------
        ////(仮)
        //if (collision.gameObject.tag == "Item")
        //{
        //    score += itemScore;

        //    // スコア内容の変更
        //    scoretext.text = "Score: " + score;
        //}
        ////--------------------------
    }

    //ダメージ処理
    void OndamageEffect()
    {
        //ダメージフラグをtrueに
        ondamage = true;

        StartCoroutine("WaitForIt");

    }

    //ダメージを受けた時の無敵時間
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1);


        ondamage = false;
        //       renderer.color = new Color(1f, 1f, 1f, 1f);
    }
}
