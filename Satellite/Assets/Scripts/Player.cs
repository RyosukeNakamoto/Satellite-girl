using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;

    // 速度
    public float Speed = 100.0f;
    //プレイヤーの位置
    private Vector2 player_pos;

    public GameObject camera;
    //発射する弾
    public GameObject Bullet;
    //発射間隔の時間
    public float Bulletderay = 0.5f;
    private float Timer;

    int key;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 移動処理
        Move();
        //移動制限
        Clamp();
        //弾を発射する処理
        Shot();
        //発射間隔の時間計測
        Timer += Time.deltaTime;
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
        rigidbody.velocity = direction * Speed;
    }

    //プレイヤーの移動制限関数
    void Clamp()
    {
        //現在位置を代入
        player_pos = transform.position;
        //横の移動の制限
        player_pos.x = Mathf.Clamp(player_pos.x, camera.transform.position.x - 7.0f, camera.transform.position.x + 7.0f);
        //縦の移動制限
        player_pos.y = Mathf.Clamp(player_pos.y, -3.9f, 3.9f);
        transform.position = new Vector2(player_pos.x, player_pos.y);
    }

    //弾の発射関数
    void Shot()
    {
        //Spaceキーを押したとき弾を発射
        if (Input.GetKey(KeyCode.Space)&&Timer>Bulletderay)
        {
            //弾を発射する間隔の時間計測の初期化
            Timer = 0.0f;

            //弾の実体化
            Instantiate(Bullet, transform.position, transform.rotation);
        }
    }
}
