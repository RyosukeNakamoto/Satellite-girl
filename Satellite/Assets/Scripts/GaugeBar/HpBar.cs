using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    // 画像を指定
    [SerializeField]
    Sprite[] hpBar;     // 配列

    // Imageを参照します
    [SerializeField]
    Image image = null;
    // プレイヤースクリプトの取得
    Player playerSc;
    // α値
    [SerializeField]
    float alpha = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        //  HP画像を指定します
        switch (GameController.Instance.hpLevel)
        {
            case 0:
                GetComponent<Image>().sprite = hpBar[0];
                GetComponent<Image>().SetNativeSize();
                break;
            case 1:
                GetComponent<Image>().sprite = hpBar[1];
                GetComponent<Image>().SetNativeSize();
                break;
            case 2:
                GetComponent<Image>().sprite = hpBar[2];
                GetComponent<Image>().SetNativeSize();
                break;
            case 3:
                GetComponent<Image>().sprite = hpBar[3];
                GetComponent<Image>().SetNativeSize();
                break;
            case 4:
                GetComponent<Image>().sprite = hpBar[4];
                GetComponent<Image>().SetNativeSize();
                break;
            case 5:
                GetComponent<Image>().sprite = hpBar[5];
                GetComponent<Image>().SetNativeSize();
                break;
        }
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
        if (playerSc.posX <= -2.0f && playerSc.posY >= 3.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
        }
        // MAXカラーにします
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.maxColorComponent);
        }
    }
}
