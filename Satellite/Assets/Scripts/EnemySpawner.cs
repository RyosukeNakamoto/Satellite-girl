using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // こどもプレハブのエネミーを指定します
    public GameObject enemy;

    // 親オブジェクトを指定します
    //public Transform parentObject;

    // Enemyのスクリプトを参照するための変数
    //Enemy enemysc;

    public GameObject boss;

    //public GameObject enemyds;// 禁断の手

    //private int enemyDsCount;

    // Start is called before the first frame update
    void Start()
    {
        // ランダムで20体の敵を生成します
        for (int i = 0; i <= 100; i++)
        {
            // ポジションの指定
            var position = transform.position;

            // 一定の間隔を開けます
            position.x += i * 3.0f;

            // 縦画面を14分割した真ん中12の空間にランダム生成します
            position.y = Random.Range(-6.0f, 6.0f);

            // こどもプレハブを生成します
            GameObject enemyChild = Instantiate(enemy, position, enemy.transform.rotation,transform) as GameObject;
            //GameObject enemyChild = Instantiate(enemy,position, enemy.transform.rotation) as GameObject;
            //enemyChild.transform.parent = parentObject.transform;

            //enemyDsCount = 0;
        }

        // Enemyのスクリプトを参照します
        //enemysc = gameObject.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        int ObjCount = this.transform.childCount;

        if (ObjCount == 98)
        {
            foreach (Transform enemy in gameObject.transform)
            {
                Destroy(enemy.gameObject);

                boss.SetActive(true);
            }
        }
    }
}
