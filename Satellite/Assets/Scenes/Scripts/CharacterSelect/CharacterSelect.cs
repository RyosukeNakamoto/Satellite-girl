using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{

    public Canvas[] character;

    bool characterSelect = true;
    bool characterChange = false;

    // Start is called before the first frame update
    void Start()
    {
        //シーン開始時の表示、非表示
        character[0].enabled = true;
        character[1].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //トリガー入力でステージの前半、後半切り替え
        float tri = Input.GetAxis("L_R_Trigger");

        if (tri == 0)
        {
            characterChange = false;
        }

        if (characterChange == false)
        {
            //キーを押したときにキャラクター切り替え
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S)|| tri > 0 || tri < 0)
            {
                if (characterSelect == true)
                {
                    characterSelect = false;

                    characterChange = true;
                }
                else
                {
                    characterSelect = true;

                    characterChange = true;
                }
            }
        }

        //一号機セレステル選択状態
        if (characterSelect == true)
        {
            character[0].enabled = true;
        }
        else
        {
            character[0].enabled = false;
        }
        //二号機ファー選択状態
        if (characterSelect == false)
        {
            character[1].enabled = true;
        }
        else
        {
            character[1].enabled = false;
        }
    }
}
