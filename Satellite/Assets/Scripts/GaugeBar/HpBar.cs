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
    public Image image = null;
    // プレイヤースクリプトの取得
    Player playerSc;
    // α値
    [SerializeField]
    float alpha = 0.25f;

    // プレイヤーのHPゲージ
    int maxPower;       // 最大HP
    int hpValue;        // 現在のHP
    float displayHp;    // 表示中のHP

    // 点滅フラグ
    public bool blink = false;

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

        // HPのゲージ
        image.fillAmount = GameController.Instance.hpGet;
        // MAXHPのセット
        maxPower = GameController.Instance.HitPoint;    // 最大HP       
        displayHp = GameController.Instance.HitPoint;   // 表示中のHP

       
    }

    // Update is called once per frame
    void Update()
    {
        // HPを更新
        hpValue = playerSc.hpValue;
        // HPの処理
        displayHp += 2.5f * (hpValue - displayHp) * Time.deltaTime;
        image.fillAmount = displayHp / maxPower;

        // 半透明にします
        if (playerSc.posX <= -2.0f && playerSc.posY >= 3.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
        }
        // MAXカラーにします(戻す)
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.maxColorComponent);
        }
    }
    // 点滅処理
    //IEnumerator Blink(){
    //    //yield return new WaitForSeconds(1);
    //  //  ondamage = false;
    //    image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    //    yield return new WaitForSeconds(0.2f);
    //    Debug.Log(image.color);
    //    image.color = new Color(1f, 1f, 1f, 1.0f);
    //    yield return new WaitForSeconds(0.2f);
    //    //Debug.Log(image.color);
    //}
}
