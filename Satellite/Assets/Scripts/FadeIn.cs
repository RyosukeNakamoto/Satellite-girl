﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    // Imageを扱う変数
    Image image;
    // α値の変数
    float alfa;
    // フェードインする早さ
    [SerializeField] float fadeSpeed;
    // フェードアウト完了のフラグ
    public static bool fadeInOk = false;

    // Start is called before the first frame update
    void Start()
    {
        // Imageを取得
        image = GetComponent<Image>();
        // α値の取得
        alfa = image.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        // α値変更の計算
        alfa -= Time.deltaTime / fadeSpeed;
        // α値変更の代入
        image.color = new Color(0, 0, 0, alfa);
        // フェードイン完了の合図
        if (alfa <= 0)
        {
            fadeInOk = true;
            Destroy(gameObject);
        }
    }
}
