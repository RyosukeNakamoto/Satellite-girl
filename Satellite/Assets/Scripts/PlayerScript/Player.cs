﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;

    // 速度
    public float speed = 10f;
    private float speedBuff = 10;
    //プレイヤーの位置
    private Vector2 player_pos;

    //プレイヤーのHP
    //[SerializeField]
    //public static int hp = 0;
    [SerializeField]
    float activ = 0;

    // プレイヤーのHP
    public int hpValue;

    // プレイヤーのスタミナゲージ       
    public GameObject staminaObject;
    public Image staminaGauge = null;
    public float staminaValue = 1;
    bool stamina = false;

    // 活動時間ゲージのスイッチ
    bool activsSwitch = false;
    // プレイヤーのバフゲージ       
    public GameObject buffObject;
    public Image buffGauge = null;
    public float buffValue = 0;

    //ダメージフラグ
    public bool ondamage = false;
    public static SpriteRenderer renderer;
    public GameObject enemyBullet;
    public GameObject bossBullet;
    Bullet bulletSc;
    Bullet bossSc;

    //ゲームオーバー表示
    public GameObject gameOver;
    // HpBar.Scを参照(仮)
    HpBar hpBar;

    //武器を数値で管理
    public static int bulletstatus = 0;
    // 
    public GameObject camera;
    //発射する弾
    public GameObject rifleBullet;      // ライフル    
    public GameObject machinegunBullet; // マシンガン
    public GameObject bazookaBullet;    // バズーカ
    // サウンドを指定
    public AudioClip[] sound;
    // サウンドの変数
    AudioSource audioSource;

    // プレイヤーのボイス
    [SerializeField] public AudioClip[] playerVoice;
    AudioSource playerVoiceSource;

    // 
    //発射間隔の時間（オール）
    public float bulletDelay;
    // マシンガンの発射間隔の時間
    public float machineGunDelay;
    private float timer;

    // スコアの値
    public static int score;
    //// スコアテキストコンポーネント
    //Text scoreText;
    
    // ポイントのアニメーション
    [SerializeField] private Animator pointAnimator;
    //// スコアテキストオブジェクトの参照
    //public GameObject scoreObject;
    //// リザルト画面のスコア表示
    //public GameObject resultScoreObject;
    // アイテムの点数
    int itemScore = 5;
    int itemScore1 = 10;
    int itemScore2 = 15;

    // スタミナ制御
    bool staminaControl = true;
    // バフを使うフラグ
    public bool buffUse = false;
    // バフをかける
    public static bool buffSet = false;
    // スピードバフON
    private bool speedOnBuff = false;
    // スピードバフOFF
    private bool speedOffBuff = true;

    // アニメーション
    Animator PlayerAnimator;
    // 移動範囲制限の開始設定
    bool limitStart = false;

    // xboxコントローラ「A」ボタン
    string aButton = "joystick button 0";

    // プレイヤーの座標
    public float posX;    // X座標 
    public float posY;    // Y座標

    IEnumerator PointCount()
    {
        pointAnimator.SetBool("Count", true);
        yield return new WaitForSeconds(0.5f);
        pointAnimator.SetBool("Count", false);
        //scoreText.text = score.ToString();
    }

    //IEnumerator start()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    PlayerAnimator.SetInteger("Order",1);
    //    limitStart = true;
    //}

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        bulletSc = enemyBullet.GetComponent<StraightBullet>();
        bossSc = bossBullet.GetComponent<Bullet>();
        //PlayerAnimator = GetComponent<Animator>();

        Time.timeScale = 1.0f;

        // オーディオのコンポーネント
        playerVoiceSource = GetComponent<AudioSource>();
        // オーディオのコンポーネント
        audioSource = GetComponent<AudioSource>();

        //// スコアテキストのコンポーネント
        //scoreText = scoreObject.GetComponent<Text>();
        //// スコアを0で初期化
        score = GameController.Instance.scoreText;
        //// スコアを表示
        //scoreText.text = score.ToString();

        // バフゲージ
        buffGauge = buffObject.GetComponent<Image>();
        buffGauge.fillAmount = 0;

        // 一号機セレステルのHPを取得
        //hp = GameController.Instance.HitPoint;
        // 一号機セレステルの活動時間を取得
        activ = GameController.Instance.ActivityTime;
        // 一号機セレステルの攻撃力を取得

        // 一号機セレステルの連射間隔を取得

        //// スライダーの値をセット
        // HPのセット
        hpValue = GameController.Instance.HitPoint;
        // 活動時間のゲージ
        staminaGauge = staminaObject.GetComponent<Image>();
        staminaGauge.fillAmount = staminaValue;

        // Playerタグを取得します
        var HpGauge = GameObject.FindGameObjectWithTag("HpGauge");
        // Playerタグのスクリプトを取得します
        hpBar = HpGauge.GetComponent<HpBar>();
    }

    // Update is called once per frame
    void Update()
    {
        // ポジションを代入します
        posX = transform.position.x;    // X座標
        posY = transform.position.y;    // Y座標

        //scoreText.text = score.ToString();

        if (hpBar.image.fillAmount <= 0.01f)    // 無理やりゲームオーバーにプレイヤーがする(仮：音声が入ってるから)
        {
            playerVoiceSource.PlayOneShot(playerVoice[Random.Range(3, 3)]);
            gameOver.SetActive(true);
        }

        // ゲージがMAXになったらバフ発動フラグ
        if (buffGauge.fillAmount >= 1)
        {
            // ボイスの再生
            //playerVoiceSource.PlayOneShot(playerVoice[Random.Range(0, 3)]);
            buffUse = true; // バフを使うフラグON

            buffSet = true; // バフをかける
            PlayerBullet.buffTrigger = true;
            speedOnBuff = true;
            speedOffBuff = false;

        }
        // ゲージを使い切ったらバフ終了
        else if (buffGauge.fillAmount <= 0)
        {
            speedOnBuff = false;
            PlayerBullet.buffTrigger = false;
            buffUse = false;    // バフフラグOFF
            buffSet = false;    // 
            speedOffBuff = true;    // 通常モード           
        }
        // バフ発動
        if (buffSet)
        {
            // ゲージを消費
            buffGauge.fillAmount -= 0.0025f;
        }
        if (EnemyGenerator.notEenemy)
        {
            GameController.Instance.buffGaugeValue = buffGauge.fillAmount;
        }

        //ダメージを受けた時点滅
        if (ondamage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            renderer.color = new Color(1f, 1f, 1f, level);
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
        if (staminaControl)
        {
            //矢印キーの入力情報を取得
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            //移動する向きを作成
            Vector2 direction = new Vector2(x, y).normalized;

            if (speedOnBuff)
            {
                speed = speedBuff * 1.3f;
                speedOnBuff = false;
            }
            if (speedOffBuff)
            {
                speed = 10;
            }

            //移動する向きとスピードを代入
            rigidbody.velocity = direction * speed;
           
            // 移動時の活動時間の変化
            if (x != 0 || y != 0)
            {
                activsSwitch = true;
                if (activsSwitch)
                {
                    // 活動ゲージの減算
                    staminaGauge.fillAmount -= staminaValue / GameController.Instance.ActivityTime * 0.05f;
                }
                if (staminaGauge.fillAmount == 0)
                {
                    rigidbody.velocity = direction * 0;
                    staminaGauge.color =  new Color(0.8314662f, 0.1067996f, 0.9056604f,1f);
                    staminaControl = false;
                }
            }
            // 移動していないとき
            else
            {
                activsSwitch = false;
                if (!activsSwitch)
                {
                    // ゲージが減っているとき
                    // 活動ゲージの加算
                    staminaGauge.fillAmount += staminaValue / GameController.Instance.ActivityTime * 7.0f * Time.deltaTime;
                }
            }
        }
        if (!staminaControl)
        {
            // 活動ゲージの加算
            staminaGauge.fillAmount += staminaValue / GameController.Instance.ActivityTime * 0.07f;
            if (staminaGauge.fillAmount > 0.2)
            {
                staminaGauge.color = new Color(1f,1f,1f,1f);
                staminaControl = true;
            }
        }
    }

    //プレイヤーの移動制限関数
    void Clamp()
    {
        //現在位置を代入
        player_pos = transform.position;
        //横の移動の制限
        player_pos.x = Mathf.Clamp(player_pos.x, camera.transform.position.x - 11.0f, camera.transform.position.x + 11.0f);
        //縦の移動制限
        player_pos.y = Mathf.Clamp(player_pos.y, -6.0f, 6.0f);
        transform.position = new Vector2(player_pos.x, player_pos.y);
    }

    //弾の発射関数
    void Shot()
    {
        //弾の発射間隔を弾の状態で変更

        //ライフルを装備中の発射間隔
        if (bulletstatus == 0)
        {
            bulletDelay = GameController.Instance.Rapidfire;

            //Spaceキーを押したとき弾を発射
            if (Input.GetKey(KeyCode.Space) && timer > bulletDelay || Input.GetKey(aButton) && timer > bulletDelay)
            {
                //弾を発射する間隔の時間計測の初期化
                timer = 0.0f;

                //弾の実体化
                Instantiate(rifleBullet, new Vector2(transform.position.x + 1.5f, transform.position.y), transform.rotation);

                // サウンドの再生
                audioSource.PlayOneShot(sound[0]);
            }
        }

        ////マシンガンを装備中の発射間隔
        //if (bulletstatus == 1)
        //{
        //    // マシンガンの連射間隔の取得
        //    machineGunDelay = 0.5f;

        //    //Spaceキーを押したとき弾を発射
        //    if (Input.GetKey(KeyCode.Space) && timer > machineGunDelay || Input.GetKey(aButton) && timer > machineGunDelay)
        //    {
        //        //弾を発射する間隔の時間計測の初期化
        //        timer = 0.0f;

        //        //弾の実体化
        //        Instantiate(machinegunBullet, new Vector2(transform.position.x + 1.5f, transform.position.y), transform.rotation);

        //        // サウンドの再生
        //        audioSource.PlayOneShot(sound[1]);
        //    }
        //}

        ////バズーカを装備中の発射間隔
        //if (bulletstatus == 2)
        //{
        //    bulletDelay = 0.8f;

        //    //Spaceキーを押したとき弾を発射
        //    if (Input.GetKey(KeyCode.Space) && timer > bulletDelay || Input.GetKey(aButton) && timer > bulletDelay)
        //    {
        //        //弾を発射する間隔の時間計測の初期化
        //        timer = 0.0f;

        //        //弾の実体化
        //        Instantiate(bazookaBullet, new Vector2(transform.position.x + 1.5f, transform.position.y), transform.rotation);

        //        // サウンドの再生
        //        audioSource.PlayOneShot(sound[2]);
        //    }
        //}
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
        renderer.color = new Color(1f, 1f, 1f, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 小デブリの弾に当たったら
        if (!ondamage && collision.gameObject.tag == "Enemy_Bullet1")
        {
            // ダメージ処理
            hpValue = hpValue - bulletSc.damage;
      
            OndamageEffect();
        }

        //ボスの弾に当たったら
        if (!ondamage && collision.gameObject.tag == "Enemy_Bullet1")
        {
            hpValue = hpValue - bossSc.damage;

            OndamageEffect();
        }

        // スコアの加算
        if (collision.gameObject.tag == "Item")
        {
            score += itemScore;
            GameController.Instance.scoreText = score;
            // スコア内容の変更
            StartCoroutine(PointCount());

            // サウンドの再生
            audioSource.PlayOneShot(sound[3]);
            Debug.Log(score);
        }

        if (collision.gameObject.tag == "Item1")
        {
            score += itemScore1;
            GameController.Instance.scoreText = score;
            // スコア内容の変更
            StartCoroutine(PointCount());

            // サウンドの再生
            audioSource.PlayOneShot(sound[3]);
        }

        if (collision.gameObject.tag == "Item2")
        {
            score += itemScore2;
            GameController.Instance.scoreText = score;
            // スコア内容の変更
            StartCoroutine(PointCount());

            // サウンドの再生
            audioSource.PlayOneShot(sound[3]);
        }
    }
}
