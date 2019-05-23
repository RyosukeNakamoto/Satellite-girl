using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{

    //ボスのHP設定
    public float hp=100f;
    public float maxhp=100;

    public GameObject HpObject;
    public Image HpGauge = null;
    public float HpValue = 1;

    //ボスのHPスライダー
    public Slider hpslider;
    //クリア画面
    public GameObject clearImage;

    public Transform target;
    public float offset;

    //プレイヤーオブジェクト
    public GameObject player;
    //ボス弾プレハブ
    public GameObject bulletPrefab;
    public GameObject aimBullet;
    //ボス隕石プレハブ
    public GameObject meteoriteSmall;
    public GameObject meteoriteMedium;
    public GameObject meteoriteLarge;
    //デブリプレハブ
    public GameObject debriSmall;
    public GameObject debriMedium;
    public GameObject debriLarge;

    //ボスレーザープレハブ
    public GameObject laserPrefab;
    public GameObject largeLaserPrefab;

    //一秒ごとに弾を発射するためのもの
    private float targetTime = 1.0f;
    private float currentTime = 0;

    //ボス攻撃パターン
    float bossAttack = 0;
    //ボスポイント
    int bossPoint;

    //オーディオ
    AudioSource audioSource;
    public AudioClip[] sound;

    // Start is called before the first frame update
    void Start()
    {
        // HPのゲージ
        HpGauge = HpObject.GetComponent<Image>();
        switch (GameController.Instance.stage)
        {
            case 0:
                maxhp = 450;
                bossPoint = 60;
                break;
            case 1:
                maxhp = 1500;
                bossPoint = 180;
                break;
            case 2:
                maxhp = 3000;
                bossPoint = 300;
                break;
        }
        HpGauge.fillAmount = 1;

        clearImage.SetActive(false);

        //音のコンポーネントを取得
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.x = target.position.x + offset;
        transform.position = pos;

        //ボスの体力が0になったときに、自分を消去
        if (HpGauge.fillAmount <= 0)
        {
            //スコア加算
            Player.score += bossPoint;
            Debug.Log(Player.score);

            Destroy(gameObject);
            
            clearImage.SetActive(true);

            // sceneをまたいで保存
            GameController.Instance.score += Player.score;
        }

        currentTime += Time.deltaTime;

        //3秒ごとに弾、発射
        if (currentTime>3)
        {
            
            //ステージによって攻撃パターン変更
            switch (GameController.Instance.stage)
            {
                case 0:
                    bossAttack = Random.Range(0, 3);
                    break;
                case 1:
                    bossAttack = Random.Range(3, 10);
                    break;
                case 2:
                    bossAttack = Random.Range(3, 13);
                    break;
            }
            
            currentTime = 0;

            switch (bossAttack)
            {
                //隕石(小)発射
                case 0:
                    ShotMeteoriteSmall();
                    break;
                //隕石(中)発射
                case 1:
                    ShotMeteoriteMedium(); ;
                    break;
                //隕石(大)発射
                case 2:
                    ShotMeteoriteLarge(); ;
                    break;
                //三方向に弾発射
                case 3:
                    EnemyShotThreeDirections();
                    break;
                //プレイヤーに向かって三発発射
                case 4:
                    StartCoroutine("AimShotThreeConsecutive");
                    break;
                //デブリ(小)発生
                case 5:
                    debriOccurrenceSmall();
                    break;
                //デブリ(中)発生
                case 6:
                    debriOccurrenceMedium();
                    break;
                //デブリ(大)発生
                case 7:
                    debriOccurrenceLarge();
                    break;
                    //五方向に弾発射
                case 8:
                    EnemyShotFiveDirections();
                    break;
                //プレイヤーに向かって四発発射
                case 9:
                    StartCoroutine("AimShotFourConsecutive");
                    break;
                //プレイヤーに向かって五発発射
                case 10:
                    StartCoroutine("AimShotFiveConsecutive");
                    break;
                //六方向にレーザー発射
                case 11:
                    Laser();
                    break;
                //太いレーザー発射
                case 12:
                    LargeLaser();
                    break;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.tag == "Bullet")
        {
            HpGauge.fillAmount -= HpValue / maxhp * GameController.Instance.Attack;
            Debug.Log(HpValue / maxhp * GameController.Instance.Attack);
        }
    }

    //プレイヤーに向かって隕石(小)発射
    public void ShotMeteoriteSmall()
    {
        //座標を変数posに保存
        var position = this.gameObject.transform.position;
        //弾のプレハブを作成
        var bullet = Instantiate(meteoriteSmall) as GameObject;
        //弾のプレハブの位置を自分の位置にする
        bullet.transform.position = position;

        //プレイヤーの位置から自分の位置を引く
        Vector2 vec = player.transform.position - position;
        //弾のRigidBody2Dコンポネントのvelocityに、求めたベクトルを入れて力を加える
        bullet.GetComponent<Rigidbody2D>().velocity = vec;
    }

    //プレイヤーに向かって隕石(中)発射
    public void ShotMeteoriteMedium()
    {
        //座標を変数posに保存
        var position = this.gameObject.transform.position;
        //弾のプレハブを作成
        var bullet = Instantiate(meteoriteMedium) as GameObject;
        //弾のプレハブの位置を自分の位置にする
        bullet.transform.position = position;

        //プレイヤーの位置から自分の位置を引く
        Vector2 vec = player.transform.position - position;
        //弾のRigidBody2Dコンポネントのvelocityに、求めたベクトルを入れて力を加える
        bullet.GetComponent<Rigidbody2D>().velocity = vec;
    }

    //プレイヤーに向かって隕石(大)発射
    public void ShotMeteoriteLarge()
    {
        //座標を変数posに保存
        var position = this.gameObject.transform.position;
        //弾のプレハブを作成
        var bullet = Instantiate(meteoriteLarge) as GameObject;
        //弾のプレハブの位置を自分の位置にする
        bullet.transform.position = position;

        //プレイヤーの位置から自分の位置を引く
        Vector2 vec = player.transform.position - position;
        //弾のRigidBody2Dコンポネントのvelocityに、求めたベクトルを入れて力を加える
        bullet.GetComponent<Rigidbody2D>().velocity = vec;
    }

    //デブリ(小)発生
    public void debriOccurrenceSmall()
    {
        //座標を変数posに保存
        Vector2 position = this.gameObject.transform.position;
        position.y = Random.Range(-5, 5);
        //デブリのプレハブを作成
        var bullet = Instantiate(debriSmall) as GameObject;
        //デブリのプレハブの位置を変更
        bullet.transform.position = position;
    }

    //デブリ(中)発生
    public void debriOccurrenceMedium()
    {
        //座標を変数posに保存
        Vector2 position = this.gameObject.transform.position;
        position.y = Random.Range(-5, 5);
        //デブリのプレハブを作成
        var bullet = Instantiate(debriMedium) as GameObject;
        //デブリのプレハブの位置を変更
        bullet.transform.position = position;
    }

    //デブリ(大)発生
    public void debriOccurrenceLarge()
    {
        //座標を変数posに保存
        Vector2 position = this.gameObject.transform.position;
        position.y = Random.Range(-5, 5);
        //デブリのプレハブを作成
        var bullet = Instantiate(debriLarge) as GameObject;
        //デブリのプレハブの位置を変更
        bullet.transform.position = position;
    }

    //3方向の弾の発射
    public void EnemyShotThreeDirections()
    {
        Vector3 position = transform.position;
        //弾の実体化
        var bullet = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        bullet.transform.Rotate(0, 0, -45);
        var bullet1 = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        bullet1.transform.Rotate(0, 0, 0);
        var bullet2 = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        bullet2.transform.Rotate(0, 0, 45);

        //音の再生
        audioSource.PlayOneShot(sound[0]);
    }

    
    //5方向の弾の発射
    public void EnemyShotFiveDirections()
    {
        Vector3 position = transform.position;
        //弾の実体化
        var bullet = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        bullet.transform.Rotate(0, 0, -60);
        var bullet1 = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        bullet1.transform.Rotate(0, 0, -30);
        var bullet2 = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        bullet2.transform.Rotate(0, 0, 0);
        var bullet3 = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        bullet3.transform.Rotate(0, 0, 30);
        var bullet4 = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        bullet4.transform.Rotate(0, 0, 60);

        //音の再生
        audioSource.PlayOneShot(sound[0]);
    }

    //プレイヤーに向かって弾3発発射
   IEnumerator AimShotThreeConsecutive()
    {
        for (int i = 0; i < 3; i++)
        {
            //座標を変数posに保存
            var position = this.gameObject.transform.position;
            //弾のプレハブを作成
            var bullet = Instantiate(aimBullet) as GameObject;
            //弾のプレハブの位置を自分の位置にする
            bullet.transform.position = position;

            //プレイヤーの位置から自分の位置を引く
            Vector2 vec = player.transform.position - position;
            //弾のRigidBody2Dコンポネントのvelocityに、求めたベクトルを入れて力を加える
            bullet.GetComponent<Rigidbody2D>().velocity = vec;
            //音の再生
            audioSource.PlayOneShot(sound[0]);
            //0.5秒弾の間隔を空ける
            yield return new WaitForSeconds(0.5f);
        }
    }

    //プレイヤーに向かって弾4発発射
    IEnumerator AimShotFourConsecutive()
    {
        for (int i = 0; i < 4; i++)
        {
            //座標を変数に保存
            var position = this.gameObject.transform.position;
            //弾のプレハブを作成
            var bullet = Instantiate(aimBullet) as GameObject;
            //弾のプレハブの位置を自分の位置にする
            bullet.transform.position = position;

            //プレイヤーの位置から自分の位置を引く
            Vector2 vec = player.transform.position - position;
            //弾のRigidBody2Dコンポネントのvelocityに、求めたベクトルを入れて力を加える
            bullet.GetComponent<Rigidbody2D>().velocity = vec;
            //音の再生
            audioSource.PlayOneShot(sound[0]);
            //0.5秒弾の間隔を空ける
            yield return new WaitForSeconds(0.5f);
        }
    }

    //プレイヤーに向かって弾5発発射
    IEnumerator AimShotFiveConsecutive()
    {
        for (int i = 0; i < 5; i++)
        {
            //座標を変数posに保存
            var pos = this.gameObject.transform.position;
            //弾のプレハブを作成
            var bullet = Instantiate(aimBullet) as GameObject;
            //弾のプレハブの位置を自分の位置にする
            bullet.transform.position = pos;

            //プレイヤーの位置から自分の位置を引く
            Vector2 vec = player.transform.position - pos;
            //弾のRigidBody2Dコンポネントのvelocityに、求めたベクトルを入れて力を加える
            bullet.GetComponent<Rigidbody2D>().velocity = vec;
            //音の再生
            audioSource.PlayOneShot(sound[0]);
            //0.5秒弾の間隔を空ける
            yield return new WaitForSeconds(0.5f);
        }
    }

    //レーザー6発発射
    public void Laser()
    {
        Vector3 position = transform.position;

        //音の再生
        audioSource.PlayOneShot(sound[1]);
        //レーザーの実体化
        position.x = 22.5f;
        position.y = -0.8f;
        var laser = Instantiate(laserPrefab, position, laserPrefab.transform.rotation);
        laser.transform.SetParent(transform, false);
        laser.transform.Rotate(0, 0, -12);
        //laser.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 3.1f);
        laser.transform.parent = transform;

        position.x = 22.5f;
        position.y = 0.8f;
        var laser1 = Instantiate(laserPrefab, position, laserPrefab.transform.rotation);
        laser1.transform.SetParent(transform, false);
        laser1.transform.Rotate(0, 0, 12);
        laser1.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, -3.1f);
        laser1.transform.parent = transform;

        position.x = 22.5f;
        position.y = -0.4f;
        var laser2 = Instantiate(laserPrefab, position, laserPrefab.transform.rotation);
        laser2.transform.SetParent(transform, false);
        laser2.transform.Rotate(0, 0, -7);
        laser2.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 1.8f);
        laser2.transform.parent = transform;

        position.x = 22.5f;
        position.y = 0.4f;
        var laser3 = Instantiate(laserPrefab, position, laserPrefab.transform.rotation);
        laser3.transform.SetParent(transform, false);
        laser3.transform.Rotate(0, 0, 7);
        laser3.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, -1.8f);
        laser3.transform.parent = transform;


        position.x = 22.5f;
        position.y = -0.2f;
        var laser4 = Instantiate(laserPrefab, position, laserPrefab.transform.rotation);
        laser4.transform.SetParent(transform, false);
        laser4.transform.Rotate(0, 0, -2.5f);
        laser4.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0.7f);
        laser4.transform.parent = transform;

        position.x = 22.5f;
        position.y = 0.2f;
        var laser5 = Instantiate(laserPrefab, position, laserPrefab.transform.rotation);
        laser5.transform.SetParent(transform, false);
        laser5.transform.Rotate(0, 0, 2.5f);
        laser5.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, -0.7f);
        laser5.transform.parent = transform;
        
    }

    //太いレーザー発射
    public void LargeLaser()
    {
        Vector3 position = transform.position;
        position.x = 36f;

        //音の再生
        audioSource.PlayOneShot(sound[1]);

        var largeLaser = Instantiate(largeLaserPrefab, position, largeLaserPrefab.transform.rotation);
        largeLaser.transform.SetParent(transform, false);
        largeLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(-30, 0);
        largeLaser.transform.parent = transform;
        
    }
    
}
