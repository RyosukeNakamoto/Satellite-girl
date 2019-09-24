using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    // Imageを参照します
    [SerializeField]
    Image image = null;
    // こどものTextを取得します
    Text textChild;

    // α値
    [SerializeField]
    float alpha = 0.25f;

    // プレイヤースクリプトの取得
    Player playerSc;

    // Start is called before the first frame update
    void Start()
    {
        // Playerタグを取得します
        var player = GameObject.FindGameObjectWithTag("Player");
        // Playerタグのスクリプトを取得します
        playerSc = player.GetComponent<Player>();
        // Imageを取得します
        image.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // 半透明にします
        if (playerSc.posX >= 6.0f && playerSc.posY >= 4.0f)
        {
            // α値を下げます
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            // 子オブジェクトを取得します
            foreach (Transform child in transform)
            {
                // imageを取得します
                textChild = child.GetComponent<Text>();
                // α値を下げます
                textChild.color = new Color(textChild.color.r, textChild.color.g, textChild.color.b, alpha);
            }
        }
        // MAXカラーにします
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.maxColorComponent);
            // 子オブジェクトを取得します
            foreach (Transform child in transform)
            {
                textChild = child.GetComponent<Text>();
                textChild.color = new Color(textChild.color.r, textChild.color.g, textChild.color.b, textChild.color.maxColorComponent);
            }
        }
    }
}
