using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // CSVファイルを指定します。
    public TextAsset csvData;
    // タイルID順にプレハブを指定します。
    public GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        // 行に分割
        var lines = csvData.text.Split('\n');
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
                    var enemy = Instantiate(enemyPrefabs[enemyId], transform);
                    enemy.transform.localPosition = new Vector3(enemyX, -enemyY, 0);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
