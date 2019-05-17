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

    //ボスのHPスライダー
    public Slider hpslider;

    public GameObject clearImage;

    public Transform target;
    public float offset;

    //プレイヤーオブジェクト
    public GameObject player;
    //ボス弾プレハブ
    public GameObject bulletPrefab;
    public GameObject aimBullet;

    //ボスレーザープレハブ
    public GameObject laserPrefab;
    public GameObject largeLaserPrefab;

    //一秒ごとに弾を発射するためのもの
    private float targetTime = 1.0f;
    private float currentTime = 0;

    //ボス攻撃パターン
    public float bossAttack = 0;

    //オーディオ
    AudioSource audioSource;
    public AudioClip[] sound;

    // Start is called before the first frame update
    void Start()
    {
        // ボスのMAXHPスライダー
        hpslider.maxValue = maxhp;
        // ボスのHPスライダー
        hpslider.value = hp;

        clearImage.SetActive(false);
        hpslider.enabled = false;

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
        if (hp <= 0)
        {
            Destroy(gameObject);

            clearImage.SetActive(true);
            // sceneをまたいで保存
            GameController.Instance.score += Player.score;
        }

        currentTime += Time.deltaTime;

        //5秒ごとに弾、発射
        if (currentTime>5)
        {

            bossAttack = Random.Range(0, 5);
            currentTime = 0;

            switch (bossAttack)
            {
                //3方向の弾発射
                case 0:
                    EnemyShotThreeDirections();
                    break;
                //5方向の弾発射
                case 1:
                    EnemyShotFiveDirections();
                    break;
                //プレイヤーに向かって弾3発発射
                case 2:
                    StartCoroutine("AimShotThreeConsecutive");
                    break;
                //プレイヤーに向かって弾4発発射
                case 3:
                    StartCoroutine("AimShotFourConsecutive");
                    break;
                //プレイヤーに向かって弾5発発射
                case 4:
                    StartCoroutine("AimShotFiveConsecutive");
                    break;
                //レーザー6発発射
                case 5:
                    Laser();
                    break;
                //太いレーザー発射
                case 6:
                    LargeLaser();
                    break;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= GameController.Instance.Attack;
            hpslider.value -= GameController.Instance.Attack;
        }
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
        laser.transform.Rotate(0, 0, -9);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 3.1f);
        laser.transform.parent = transform;

        position.x = 22.5f;
        position.y = 0.8f;
        var laser1 = Instantiate(laserPrefab, position, laserPrefab.transform.rotation);
        laser1.transform.SetParent(transform, false);
        laser1.transform.Rotate(0, 0, 9);
        laser1.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, -3.1f);
        laser1.transform.parent = transform;

        position.x = 22.5f;
        position.y = -0.4f;
        var laser2 = Instantiate(laserPrefab, position, laserPrefab.transform.rotation);
        laser2.transform.SetParent(transform, false);
        laser2.transform.Rotate(0, 0, -5);
        laser2.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 1.8f);
        laser2.transform.parent = transform;

        position.x = 22.5f;
        position.y = 0.4f;
        var laser3 = Instantiate(laserPrefab, position, laserPrefab.transform.rotation);
        laser3.transform.SetParent(transform, false);
        laser3.transform.Rotate(0, 0, 5);
        laser3.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, -1.8f);
        laser3.transform.parent = transform;


        position.x = 22.5f;
        position.y = -0.2f;
        var laser4 = Instantiate(laserPrefab, position, laserPrefab.transform.rotation);
        laser4.transform.SetParent(transform, false);
        laser4.transform.Rotate(0, 0, -2);
        laser4.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0.7f);
        laser4.transform.parent = transform;

        position.x = 22.5f;
        position.y = 0.2f;
        var laser5 = Instantiate(laserPrefab, position, laserPrefab.transform.rotation);
        laser5.transform.SetParent(transform, false);
        laser5.transform.Rotate(0, 0, 2);
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
