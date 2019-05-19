using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{

    //プレイヤーの画像色変更（プロト）

    SpriteRenderer playersprite;

    // Start is called before the first frame update
    void Start()
    {
        playersprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //「性格変更」で「機械的な女の子」を選択したときに、
        //プレイヤー画像の色を黒に変更
        if (PersonalityController.mechanical == true)
        {
            playersprite.color = Color.black;
        }

        //「性格変更」で「活発な女の子」を選択したときに、
        //プレイヤー画像の色を赤に変更
        if (PersonalityController.lively == true)
        {
            playersprite.color = Color.red;
        }

        //「性格変更」で「清楚な女の子」を選択したときに、
        //プレイヤー画像の色を青に変更
        if (PersonalityController.neat == true)
        {
            playersprite.color = Color.blue;
        }

        //「性格変更」で「ツンデレな女の子」を選択したときに、
        //プレイヤー画像の色を黄色に変更
        if (PersonalityController.tsundere == true)
        {
            playersprite.color = Color.yellow;
        }
    }
}
