using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointText : MonoBehaviour
{
    // Textを参照します
    [SerializeField]
    Text text = null;

    // リザルト用スコア変数
    float displayscore = 0;
    int maxScore;
    int scoreValue = 0;
    // プレイヤースクリプトの取得
    Player playerSc;

    // Start is called before the first frame update
    void Start()
    {
        // Textを取得します
        text = GetComponent<Text>();
        // プレイヤーからスコアを取得します
        maxScore = Player.score;
        scoreValue = Player.score;
        // リザルトスコアテキスト初期化
        text.text = "" + displayscore;
    }

    // Update is called once per frame
    void Update()
    {
        displayscore += 3.0f * (Player.score - displayscore) * Time.deltaTime;
        text.text = "" + displayscore.ToString("f0");
        //Debug.Log(text.text);
        Debug.Log(Player.score);
        //Debug.Log(scoreValue);
        //Debug.Log(displayscore);
    }
}
