﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    //seectnumberによって選択中のものを判定
    public int selectnumber = 4;

    //オプションオブジェクトのアウトライン
    public Outline option;
    //
    public Outline back;
    public Outline save;
    public Outline custom;
    public Outline sortie;

    // Start is called before the first frame update
    void Start()
    {
        //シーン開始時にすべてのアウトラインを非表示
        option.enabled = false;
        back.enabled = false;
        save.enabled = false;
        custom.enabled = false;
        sortie.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //上矢印キーを押したときSelectnumberを減らす
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectnumber--;
        }

        //下矢印キーを押したときSelectnumberを増やす
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectnumber++;
        }

        //selectnumberが5になったとき、selectnumberを0にする
        if (selectnumber == 5)
        {
            selectnumber = 0;
        }
        //selectnumberが-1になったとき、selectnumberを4にする
        if (selectnumber == -1)
        {
            selectnumber = 4;
        }

        //「オプション」を選択状態
        if (selectnumber == 0)
        {
            option.enabled = true;
            back.enabled = false;
            save.enabled = false;
            custom.enabled = false;
            sortie.enabled = false;
        }

        //「タイトルに戻る」を選択状態
        if (selectnumber == 1)
        {
            option.enabled = false;
            back.enabled = true;
            save.enabled = false;
            custom.enabled = false;
            sortie.enabled = false;

            //エンターキーを押したときタイトルへ遷移
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Title");
            }
        }

        //「セーブ」を選択状態
        if (selectnumber == 2)
        {
            option.enabled = false;
            back.enabled = false;
            save.enabled = true;
            custom.enabled = false;
            sortie.enabled = false;
        }

        //「改造」を選択状態
        if (selectnumber == 3)
        {
            option.enabled = false;
            back.enabled = false;
            save.enabled = false;
            custom.enabled = true;
            sortie.enabled = false;

            //エンターキーを押したとき「カスタム」へシーン遷移
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Custom");
            }
        }

        //「出撃」を選択状態
        if (selectnumber == 4)
        {
            option.enabled = false;
            back.enabled = false;
            save.enabled = false;
            custom.enabled = false;
            sortie.enabled = true;

            //エンターキーを押したとき「ステージセレクト画面」へシーン遷移
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("StageSelect");
            }
        }

    }
}
