using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{

    public Canvas[] character;

    int selectNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        //シーン開始時の表示、非表示
        character[0].enabled = true;
        character[1].enabled = false;
        character[2].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //キーを押したときにキャラクター切り替え
        if (Input.GetKeyDown(KeyCode.D))
        {
            selectNumber++;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            selectNumber--;
        }

        //selectNumberが2を越えた時、0に戻す
        if (selectNumber > 2)
        {
            selectNumber = 0;
        }
        //selectNumberが0を下回ったとき、2にする
        if (selectNumber < 0)
        {
            selectNumber = 2;
        }

        //一号機セレステル選択状態
        if (selectNumber == 0)
        {
            character[0].enabled = true;
        }
        else
        {
            character[0].enabled = false;
        }
        //二号機ファー選択状態
        if (selectNumber == 1)
        {
            character[1].enabled = true;
        }
        else
        {
            character[1].enabled = false;
        }
        //三号機ペレグリーネ選択状態
        if (selectNumber == 2)
        {
            character[2].enabled = true;
        }
        else
        {
            character[2].enabled = false;
        }
    }
}
