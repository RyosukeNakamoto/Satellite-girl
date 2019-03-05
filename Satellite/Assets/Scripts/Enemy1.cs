using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public int Hp=0;

    // メインカメラを指定
    private const string cameraTagName = "MainCamera";
    // 表示確認(最初はfalse)
    private bool isRendered = false;
    // 攻撃開始までの時間
    public float enemytime = 1.0f;
    // 時間処理計算
    public float timer;
    // 弾を指定
    public GameObject enemyBullet1;
    public GameObject enemyBullet2;
    public GameObject enemyBullet3;
    // 消滅したデブリのカウント
    public int debriCount;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp == 0)
        {
            Destroy(gameObject);
            debriCount++;
        }

        if (isRendered)
        {
            timer += Time.deltaTime;
            // Debug.Log("表示中");
            if (enemytime <= timer)
            {
                bullet();
            }            
        }
        // カメラ範囲から再度外れたらfalse
        isRendered = false;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Hp--;
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

    // 弾を表示する
    void bullet()
    {
        timer = 0.0f;
        Instantiate(enemyBullet1, new Vector2(transform.position.x - 1, transform.position.y), transform.rotation);
        Instantiate(enemyBullet2, new Vector2(transform.position.x - 1, transform.position.y), transform.rotation);
        Instantiate(enemyBullet3, new Vector2(transform.position.x - 1, transform.position.y), transform.rotation);
    }        
}
