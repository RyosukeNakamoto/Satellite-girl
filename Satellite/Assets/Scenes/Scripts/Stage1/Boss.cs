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

    //一秒ごとに弾を発射するためのもの
    private float targetTime = 1.0f;
    private float currentTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        // ボスのMAXHPスライダー
        hpslider.maxValue = maxhp;
        // ボスのHPスライダー
        hpslider.value = hp;

        clearImage.SetActive(false);
        hpslider.enabled = false;        
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
            currentTime = 0;
            //EnemyShot();
            //プレイヤーに向かって3発、弾発射
            StartCoroutine(AimShot());
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= GameController.Instance.Attack;
            hpslider.value -= GameController.Instance.Attack;
        }
    }
    
    //5方向の弾の発射
    public void EnemyShot()
    {
        Vector3 position = transform.position;
        //弾の実体化
        var bullet = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        bullet.transform.Rotate(0, 0, 120);
        var bullet1 = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        bullet1.transform.Rotate(0, 0, 150);
        var bullet2 = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        bullet2.transform.Rotate(0, 0, 180);
        var bullet3 = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        bullet3.transform.Rotate(0, 0, 210);
        var bullet4 = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        bullet4.transform.Rotate(0, 0, 240);
    }

    //プレイヤーに向かって弾発射
   IEnumerator AimShot()
    {
        for (int i = 0; i < 3; i++)
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
            //0.5秒弾の間隔を空ける
            yield return new WaitForSeconds(0.5f);
        }
    }
    
}
