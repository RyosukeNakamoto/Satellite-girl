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
    int hp = 0;
    [SerializeField]
    float activ = 0;

    // プレイヤーのHPゲージ
    public Slider hpSlider;
    // プレイヤーの活動時間ゲージ
    public Slider activTimeSlider;
    // 活動時間ゲージのスイッチ
    bool activsSwitch = false;
    // プレイヤーのバフゲージ       
    public GameObject buffObject;
    Image buffGauge;

    //ダメージフラグ
    public bool ondamage = false;
    public static SpriteRenderer renderer;
    public GameObject enemyBullet;
    Bullet bulletSc;
    private int Damage = 25;
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
    // サウンドを指定
    public AudioClip[] sound;
    // サウンドの変数
    AudioSource audioSource;
    public GameObject machinegunBullet; // マシンガン
    public GameObject bazookaBullet;    // バズーカ
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
    //　アイテムの点数
    int itemScore = 5;


    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        bulletSc = enemyBullet.GetComponent<StraightBullet>();

        Time.timeScale = 1.0f;
        // オーディオのコンポーネント
        audioSource = GetComponent<AudioSource>();

        // スコアテキストのコンポーネント
        scoreText = scoreObject.GetComponent<Text>();
        // スコアを0で初期化
        score = 0;
        // スコアを表示
        scoreText.text = "Score: " + score;
        // リザルトスコアテキストのコンポーネント
        resultScoreText = resultScoreObject.GetComponent<Text>();
        resultScoreText.text = "" + score + "p";

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
        hpSlider.maxValue = GameController.Instance.HitPoint;
        hpSlider.value = hp;
        // 活動時間のゲージ
        activTimeSlider.maxValue = GameController.Instance.ActivityTime;
        activTimeSlider.value = activ;
    }

    // Update is called once per frame
    void Update()
    {
        buffGauge.fillAmount += 0.01f * Time.deltaTime / 10 * 100;
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

        //移動する向きとスピードを代入
        rigidbody.velocity = direction * speed;
        // 移動時の活動時間の変化
        if (x != 0 || y != 0)
        {
            activsSwitch = true;
            if (activsSwitch)
            {
                // 活動ゲージの減算
                activ -= 0.2f;
                activTimeSlider.value = activ;
                // 活動ゲージの値が0以下にはならない
                if (activ < 0)
                {
                    activ = 0;
                }
            }
        }
        // 移動していないとき
        else
        {
            activsSwitch = false;
            if (!activsSwitch)
            {
                // 活動ゲージの加算
                activ += 0.1f;
                activTimeSlider.value = activ;
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
            bulletDelay = 0.5f;

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
            machineGunDelay = GameController.Instance.Rapidfire;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 小デブリの弾に当たったら
        if (!ondamage && collision.gameObject.tag == "Enemy_Bullet1")
        {
            hp -= bulletSc.damage;
            //HPバーを減らす（プロト版）
            hpSlider.value -= bulletSc.damage;
            OndamageEffect();
        }

        // スコアの加算
        if (collision.gameObject.tag == "Item")
        {
            score += itemScore;
            // スコア内容の変更
            scoreText.text = "Score: " + score;
            resultScoreText.text = "" + score + "p";
            // サウンドの再生
            audioSource.PlayOneShot(sound[3]);
        }
    }
}
