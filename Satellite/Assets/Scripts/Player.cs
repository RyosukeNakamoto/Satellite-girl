using System.Collections;
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
    [SerializeField]
    public static int hp = 0;
    [SerializeField]
    float activ = 0;

    // プレイヤーのHPゲージ
    public GameObject HpObject;
    public Image HpGauge = null;
    public float HpValue = 0;

    // プレイヤーのスタミナゲージ       
    public GameObject staminaObject;
    public Image staminaGauge = null;
    public float staminaValue = 0;
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
    private int Damage = 25;
    //ゲームオーバー表示
    public GameObject gameOver;
    // ゲームクリア表示
    public GameObject gameClear;

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

    // 
    //発射間隔の時間（オール）
    public float bulletDelay;
    // マシンガンの発射間隔の時間
    public float machineGunDelay;
    private float timer;

    // スコアの値
    public static int score;
    // スコアテキストコンポーネント
    Text scoreText;
    // リザルト画面のスコアスコアテキストコンポーネント
    Text resultScoreText;
    // スコアテキストオブジェクトの参照
    public GameObject scoreObject;
    // リザルト画面のスコア表示
    public GameObject resultScoreObject;
    // アイテムの点数
    int itemScore = 5;
    // バフを使うフラグ
    public bool buffUse = false;
    // バフをかける
    public  static bool buffSet = false;
    // スピードバフON
    private bool speedOnBuff = false;
    // スピードバフOFF
    private bool speedOffBuff = true;

    // 打つ弾のスクリプトを参照
    PlayerBullet playerBulletSc;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        bulletSc = enemyBullet.GetComponent<StraightBullet>();
        bossSc = bossBullet.GetComponent<Bullet>();
        playerBulletSc = rifleBullet.GetComponent<PlayerBullet>();

        Time.timeScale = 1.0f;

        // オーディオのコンポーネント
        audioSource = GetComponent<AudioSource>();

        // スコアテキストのコンポーネント
        scoreText = scoreObject.GetComponent<Text>();
        // スコアを0で初期化
        score = GameController.Instance.scoreText;
        // スコアを表示
        scoreText.text = "Score: " + score;
        // リザルトスコアテキストのコンポーネント
        resultScoreText = resultScoreObject.GetComponent<Text>();
        resultScoreText.text = "" + score + "p";


        // スタミナゲージ
        staminaGauge = staminaObject.GetComponent<Image>();
        staminaGauge.fillAmount = 1;
        // バフゲージ
        buffGauge = buffObject.GetComponent<Image>();
        buffGauge.fillAmount = 0;

        // 一号機セレステルのHPを取得
        hp = GameController.Instance.HitPoint;
        // 一号機セレステルの活動時間を取得
        activ = GameController.Instance.ActivityTime;
        // 一号機セレステルの攻撃力を取得

        // 一号機セレステルの連射間隔を取得

        //// スライダーの値をセット
        // HPのゲージ
        HpGauge = HpObject.GetComponent<Image>();
        HpGauge.fillAmount = GameController.Instance.HitPoint / HpValue;
        HpGauge.fillAmount = GameController.Instance.HpGet;
        // 活動時間のゲージ
        staminaGauge.fillAmount = GameController.Instance.ActivityTime / staminaValue;
        Debug.Log(GameController.Instance.ActivityTime);
    }

    // Update is called once per frame
    void Update()
    {
        buffGauge.fillAmount = buffValue / GameController.Instance.Intimacy;
        // ゲージがMAXになったらバフ発動フラグ
        if (buffGauge.fillAmount >= 1)
        {
            buffUse = true; // バフを使うフラグON
            if (buffUse)
            {
                buffSet = true; // バフをかける
                PlayerBullet.buffTrigger = true;
                speedOnBuff = true;
                speedOffBuff = false;
            }
        }
        // ゲージを使い切ったらバフ終了
        else if (buffGauge.fillAmount <= 0)
        {
            buffUse = false;    // バフフラグOFF
            buffSet = false;    // 
            speedOnBuff = false;    // バフ終了
            speedOffBuff = true;    // 通常モード
        }
        // バフ発動
        if (buffSet)
        {
            // ゲージを消費
            buffValue -= 0.1f;
        }

        //HPが0以下になったときの処理
        if (hp <= 0 || activ <= 0)
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

        if (speedOnBuff)
        {
            speed = speed * 1.3f;
            Debug.Log(speed);
            speedOnBuff = false;
        }
        if (speedOffBuff)
        {
            speed = 10;
            Debug.Log(speed);
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
                staminaGauge.fillAmount -= 0.0025f;
            }
        }
        // 移動していないとき
        else
        {
            activsSwitch = false;
            if (!activsSwitch)
            {
                // ゲージが減っているとき
                if (staminaValue <= staminaGauge.fillAmount)
                {
                    // 活動ゲージの加算
                    staminaGauge.fillAmount += 0.005f;
                }
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
            bulletDelay = GameController.Instance.Rapidfire;

            //Spaceキーを押したとき弾を発射
            if (Input.GetKey(KeyCode.Space) && timer > bulletDelay || Input.GetKey("joystick button 1") && timer > bulletDelay)
            {
                //弾を発射する間隔の時間計測の初期化
                timer = 0.0f;

                //弾の実体化
                Instantiate(rifleBullet, new Vector2(transform.position.x + 1.5f, transform.position.y), transform.rotation);

                // サウンドの再生
                audioSource.PlayOneShot(sound[0]);
            }
        }

        //マシンガンを装備中の発射間隔
        if (bulletstatus == 1)
        {
            // マシンガンの連射間隔の取得
            machineGunDelay = 0.5f;

            //Spaceキーを押したとき弾を発射
            if (Input.GetKey(KeyCode.Space) && timer > machineGunDelay || Input.GetKey("joystick button 1") && timer > machineGunDelay)
            {
                //弾を発射する間隔の時間計測の初期化
                timer = 0.0f;

                //弾の実体化
                Instantiate(machinegunBullet, new Vector2(transform.position.x + 1.5f, transform.position.y), transform.rotation);

                // サウンドの再生
                audioSource.PlayOneShot(sound[1]);
            }
        }

        //バズーカを装備中の発射間隔
        if (bulletstatus == 2)
        {
            bulletDelay = 0.8f;

            //Spaceキーを押したとき弾を発射
            if (Input.GetKey(KeyCode.Space) && timer > bulletDelay || Input.GetKey("joystick button 1") && timer > bulletDelay)
            {
                //弾を発射する間隔の時間計測の初期化
                timer = 0.0f;

                //弾の実体化
                Instantiate(bazookaBullet, new Vector2(transform.position.x + 1.5f, transform.position.y), transform.rotation);

                // サウンドの再生
                audioSource.PlayOneShot(sound[2]);
            }
        }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 小デブリの弾に当たったら
        if (!ondamage && collision.gameObject.tag == "Enemy_Bullet1")
        {
            //hp -= (int)bulletSc.damage;
            //HPバーを減らす（プロト版）
            HpGauge.fillAmount -= bulletSc.damage;
            GameController.Instance.HpGet = HpGauge.fillAmount;
            if (HpGauge.fillAmount <= 0)
            {
                gameOver.SetActive(true);
            }
            //hpSlider.value -= bulletSc.damage;
            OndamageEffect();
        }

        //ボスの弾に当たったら
        if (!ondamage && collision.gameObject.tag == "Enemy_Bullet1")
        {
            Debug.Log("A");
            //hp -= (int)bulletSc.damage;
            //HPバーを減らす（プロト版）
            HpGauge.fillAmount -= bossSc.damage;
            GameController.Instance.HpGet = HpGauge.fillAmount;
            if (HpGauge.fillAmount <= 0)
            {
                gameOver.SetActive(true);
            }
            //hpSlider.value -= bulletSc.damage;
            OndamageEffect();
        }

        // スコアの加算
        if (collision.gameObject.tag == "Item")
        {
            score += itemScore;
            GameController.Instance.scoreText = score;
            // スコア内容の変更
            scoreText.text = "Score: " + score;
            resultScoreText.text = "" + score + "p";
            // サウンドの再生
            audioSource.PlayOneShot(sound[3]);
        }
    }
}
