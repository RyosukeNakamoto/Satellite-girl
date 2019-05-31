using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCharacter : MonoBehaviour
{
    // Imageを扱う変数
    Image image;
    // α値の変数
    float alfa;
    // 点滅のチェンジ
    bool blinkChange = false;

    // 点滅の早さ
    [SerializeField] float blinkSpeed;

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
        if (alfa >= 1)
            blinkChange = true;

        if (alfa <= 0)
            blinkChange = false;

        if (blinkChange)
        {
            // α値変更の計算
            alfa -= Time.deltaTime / blinkSpeed;
            // α値変更の代入
            image.color = new Color(255, 255, 255, alfa);
        }
        if (!blinkChange)
        {
            // α値変更の計算
            alfa += Time.deltaTime / blinkSpeed;
            // α値変更の代入
            image.color = new Color(255, 255, 255, alfa);
        }
    }
}
