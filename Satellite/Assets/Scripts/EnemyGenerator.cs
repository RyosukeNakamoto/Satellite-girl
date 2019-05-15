using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGenerator : MonoBehaviour
{
    // CSVファイルを指定します。
    [SerializeField]
    TextAsset[] csvData;
    // タイルID順にプレハブを指定します。
    public GameObject[] enemyPrefabs;

    public GameObject bossAlert;
    // タイマー
    float timer;
    // BossAlertの表示までのタイム
    public float lossTime = 3.0f;
    // Alert後ボス遷移までのタイム
    public float changeTime = 2.0f;
    // 
    [SerializeField]
    Player playerSc;

    int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 行に分割
        var lines = csvData[GameController.Instance.stage].text.Split('\n');
        // 各行を順に繰返し処理
        for (var enemyY = 0; enemyY < lines.Length; enemyY++)
        {
            var line = lines[enemyY];
            // 列データに分割
            var row = line.Split(',');
            for(var enemyX = 0; enemyX < row.Length; enemyX++)
            {
                var column = row[enemyX];
                var enemyId = int.Parse(column);
                if (enemyId >= 0)
                {
                    enemyCount++ ;
                    var enemy = Instantiate(enemyPrefabs[enemyId], transform);
                    enemy.transform.localPosition = new Vector3(enemyX, -enemyY, 0);
                    //Enemy enemySc = enemy.GetComponent<Enemy>();
                    //enemySc.playerSc = playerSc;
                }
            }
        }
        //Debug.Log(transform.childCount);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.childCount);
        // ジェネレート数
        int ObjectCount = transform.childCount;
        if (ObjectCount==0)
        {            
            timer += Time.deltaTime;
            // 敵が全滅してからAlertまでのカウント
            if (lossTime <= timer )
            {
                // アラートを表示
                bossAlert.gameObject.SetActive(true);
                // ボスシーン遷移までのカウント
                if (lossTime + changeTime <= timer)
                {
                    //SceneManager.LoadScene(string.Format("Boss{0}", GameController.Instance.stage));

                    switch (GameController.Instance.stage)
                    {
                        case 0:
                            SceneManager.LoadScene("Boss1");
                            break;
                        //case 1:
                        //    SceneManager.LoadScene("Boss2");
                        //    break;
                        //case 2:
                        //    SceneManager.LoadScene("Boss3");
                        //    break;
                        //case 3:
                        //    SceneManager.LoadScene("Boss4");
                        //    break;
                        //case 4:
                        //    SceneManager.LoadScene("Boss5");
                        //    break;
                        //case 5:
                        //    SceneManager.LoadScene("Boss6");
                        //    break;
                        //case 6:
                        //    SceneManager.LoadScene("Boss7");
                        //    break;
                        //case 7:
                        //    SceneManager.LoadScene("Boss8");
                        //    break;
                        //case 8:
                        //    SceneManager.LoadScene("Boss9");
                        //    break;
                        //case 9:
                        //    SceneManager.LoadScene("Boss10");
                        //    break;
                        //case 10:
                        //    SceneManager.LoadScene("Boss11");
                        //    break;
                        //case 11:
                        //    SceneManager.LoadScene("Boss12");
                        //    break;
                   }
                }
            }
        }
        //if (ObjectCount == 99)
        //{            
            //foreach (Transform enemy in gameObject.transform)
            //{
               
            //}
        
        //}
    }
}
