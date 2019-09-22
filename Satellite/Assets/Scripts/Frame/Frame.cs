using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frame : MonoBehaviour
{
    // Imageを参照します
    [SerializeField]
    Image image = null;
    Image imageChild;

    // プレイヤースクリプトの取得
    Player playerSc;

    // α値
    [SerializeField]
    float alpha = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        // Playerタグを取得します
        var player = GameObject.FindGameObjectWithTag("Player");
        // Playerタグのスクリプトを取得します
        playerSc = player.GetComponent<Player>();
        // Imageを取得します
        image.GetComponent<Image>();

        // デバッグ
        foreach (Transform child in transform)
        {
            Debug.Log(child);
        }

    }

    // Update is called once per frame
    void Update()
    { 
        // 半透明にします
        if (playerSc.posX <= -2.0f && playerSc.posY >= 3.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            // 子オブジェクトを取得します
            foreach (Transform child in transform)
            {
                imageChild = child.GetComponent<Image>();
                imageChild.color = new Color(imageChild.color.r, imageChild.color.g, imageChild.color.b, alpha);
            }
        }
        // MAXカラーにします
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.maxColorComponent);
            // 子オブジェクトを取得します
            foreach (Transform child in transform)
            {
                imageChild = child.GetComponent<Image>();
                imageChild.color = new Color(imageChild.color.r, imageChild.color.g, imageChild.color.b, imageChild.color.maxColorComponent);
            }
        }
    }
}
