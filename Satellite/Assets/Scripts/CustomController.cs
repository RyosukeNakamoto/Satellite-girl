using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomController : MonoBehaviour
{
    [SerializeField]
    Color selectedColor = Color.yellow;

    //どこを選択中か数値で管理
    int selectNumber = 0;

    //未確定の親愛度の星の画像の表示を数値で管理
    int ununsettledIntimacy = 0;
    int minimumUnunsettledIntimacy = 0;

    //未確定のHPの星の画像の表示を数値で管理
    int ununsettledHp = 0;
    int minimumUnunsettledHp = 0;

    //未確定の活動時間の星の画像の表示を数値で管理
    int ununsettledActivityTime = 0;
    int minimumUnununsettledActivityTime = 0;

    //未確定の攻撃の星の画像の表示を数値で管理
    int ununsettledAttack = 0;
    int minimumUnununsettledAttack = 0;

    //未確定の連射速度の星の画像の表示を数値で管理
    int ununsettledRapidfire = 0;
    int minimumUnununsettledRapidfire = 0;

    //選択中の画像表示
    public Image[] selectedImage;
    public Image sortieImage;

    /*
    //それぞれのパラメーターのレベル
    public int intimacylevel = 0;
    public int hplevel = 0;
    public int activityTimelevel = 0;
    public int attacklevel = 0;
    public int rapidfirelevel = 0;
    public int sortielevel = 0;
    */
    //レベルごとの消費ポイント
    int Level1 = 500;
    int Level2 = 600;
    int Level3 = 700;
    int Level4 = 800;
    int Level5 = 1000;

    //親愛度の星の画像
    public Image[] intimacyStar;

    //未確定の親愛度の星の画像
    public Image[] unsettledIntimacyStar;

    //HPの星の画像
    public Image[] hpStar;

    //未確定のHPの星の画像
    public Image[] unsettledHpStar;

    //活動時間の星の画像
    public Image[] activityTimeStar;

    //未確定の活動時間の星の画像
    public Image[] unsettledActivityTimeStar;

    //攻撃の星の画像
    public Image[] attackStar;

    //未確定の攻撃の星の画像
    public Image[] unsettledAttackStar;

    //連射速度の星イメージ
    public Image[] rapidfireStar;

    //未確定の連射速度の星イメージ
    public Image[] unsettledRapidfireStar;

    //強化するか選択するオブジェクト
    public GameObject strengtheningQuestion;
    //強化するかどうか数値で管理
    public int strengtheningQuestionnumber = 0;
    //強化のYesイメージ
    public Image yes;
    //強化のNoイメージ
    public Image no;

    //ポイントが不足していた場合に表示する画像
    public GameObject shortagePointImage;

    //所持ポイント
    public Text possessionPointText;
    //消費ポイント
    public int consumptionPoint;
    //消費ポイントのテキスト
    public Text consumptionPointText;

    //選択したステージによってテキストを変更
    public Text selectedStage;

    //音
    AudioSource audioSource;
    //音を配列で管理
    public AudioClip[] sound;

    bool dpvInput = false;
    bool dphInput = false;

    bool shortagePoint = false;

    // Start is called before the first frame update
    void Start()
    {
        //シーン開始時に星の画像、未確定の星の画像を非表示
        for (int i = 0; i < 5; i++)
        {
            //シーン開始時に選択中画像を非表示
            selectedImage[i].enabled = false;
            //親愛度
            intimacyStar[i].enabled = false;
            unsettledIntimacyStar[i].enabled = false;
            //HP
            hpStar[i].enabled = false;
            unsettledHpStar[i].enabled = false;
            //活動時間
            activityTimeStar[i].enabled = false;
            unsettledActivityTimeStar[i].enabled = false;
            //攻撃
            attackStar[i].enabled = false;
            unsettledAttackStar[i].enabled = false;
            //連射速度
            rapidfireStar[i].enabled = false;
            unsettledRapidfireStar[i].enabled = false;
        }

        //シーン開始時に出撃選択イメージをグレーに
        sortieImage.color = Color.gray;

        //シーン開始時に強化するか選択するウインドウを非表示
        strengtheningQuestion.SetActive(false);

        //シーン開始時にポイントが不足してた場合のウインドウ非表示
        shortagePointImage.SetActive(false);

        //音のコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //デバッグ用
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameController.Instance.score += 10000;
        }

        //十字キー縦の入力
        float dph = Input.GetAxis("D_Pad_H");
        //十字キー横の入力
        float dpv = Input.GetAxis("D_Pad_V");

        if (dph == 0)
        {
            dphInput = false;
        }
        if (dpv == 0)
        {
            dpvInput = false;
        }

        /*
        //トリガー入力でキャラクター切り替え
        float tri = Input.GetAxis("L_R_Trigger");
        */

        //所持ポイントを表示
        possessionPointText.text = (GameController.Instance.score).ToString();

        //強化の確定を選択する画面が表示中にSelectNumberの数値が変更されないようにする
        if (!strengtheningQuestion.activeSelf && !shortagePointImage.activeSelf)
        {
            if (dphInput == false)
            {
                //上矢印キーを押したときSelectNumberを減らす
                if (Input.GetKeyDown(KeyCode.UpArrow) || dph > 0)
                {
                    selectNumber--;
                    audioSource.PlayOneShot(sound[0]);

                    dphInput = true;
                }

                //下矢印キーを押したときSelectNumberを増やす
                if (Input.GetKeyDown(KeyCode.DownArrow) || dph < 0)
                {
                    selectNumber++;
                    audioSource.PlayOneShot(sound[0]);

                    dphInput = true;
                }
            }

            //selectNumberが5を超えたときselectNumberを0にする
            if (selectNumber > 5)
            {
                selectNumber = 0;
            }
            //selectNumberが0以下になったときselectNumberを5にする
            if (selectNumber < 0)
            {
                selectNumber = 5;
            }
        }

        //強化を確定するウインドウでの選択
        if (strengtheningQuestion.activeSelf)
        {
            if (dphInput == false)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || dph > 0)
                {
                    strengtheningQuestionnumber = 1;
                    audioSource.PlayOneShot(sound[0]);

                    dphInput = true;
                }

                if (Input.GetKeyDown(KeyCode.DownArrow) || dph < 0)
                {
                    strengtheningQuestionnumber = 2;
                    audioSource.PlayOneShot(sound[0]);

                    dphInput = true;
                }
            }
        }

        //強化を確定するウインドウが表示されたときはどこも選択していない状態にする
        if (strengtheningQuestionnumber == 0)
        {
            yes.color = Color.grey;
            no.color = Color.grey;
        }

        //ポイントが不足してた時に画像が表示されているときの処理
        if (shortagePointImage.activeSelf)
        {
            //強化を確定するウインドウを非表示
            strengtheningQuestion.SetActive(false);

            //キーを押したときに非表示
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown("joystick button 0"))
            {
                shortagePointImage.SetActive(false);

                shortagePoint = true;
            }
        }
        else
        {
            shortagePoint = false;
        }

        if (shortagePoint == false)
        {
            //ステージ選択画面に戻る
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
            {
                SceneManager.LoadScene("StageSelect");
            }
        }

        //親愛度選択中
        if (selectNumber == 0)
        {
            //選択中の画像表示
            selectedImage[0].enabled = true;

            //選択画像を点滅
            float bling = Mathf.Abs(Mathf.Sin(Time.time * 3));
            selectedImage[0].GetComponent<Image>().color = new Color(1f, 1f, 1f, bling);

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf && !shortagePointImage.activeSelf)
            {
                if (dpvInput == false)
                {
                    //親愛度選択中に左右キーで強化するレベルを選択
                    if (Input.GetKeyDown(KeyCode.RightArrow) || dpv > 0)
                    {
                        if (ununsettledIntimacy < 5)
                        {
                            ununsettledIntimacy++;

                            audioSource.PlayOneShot(sound[0]);

                            dpvInput = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow) || dpv < 0)
                    {
                        if (ununsettledIntimacy > minimumUnunsettledIntimacy)
                        {
                            ununsettledIntimacy--;

                            audioSource.PlayOneShot(sound[0]);

                            dpvInput = true;
                        }
                    }
                }
            }

            //未確定の親愛度のレベル1の強化選択状態
            if (ununsettledIntimacy >= 1)
            {
                //未確定の星表示
                unsettledIntimacyStar[0].enabled = true;
                //消費ポイントの変更
                consumptionPoint = Level1;

                if (GameController.Instance.intimacyLevel == 0)
                {
                    //消費ポイントの表示を500に変更
                    consumptionPointText.text = "500";
                }
                else
                {
                    //消費ポイントの表示を0に変更
                    consumptionPointText.text = "0";
                }

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnunsettledIntimacy < 1 && !shortagePointImage.activeSelf)
                {
                    if (Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown("joystick button 1"))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
                    }

                }
            }
            else
            {
                //未確定の星非表示
                unsettledIntimacyStar[0].enabled = false;
            }

            //未確定の親愛度のレベル2の強化選択状態
            if (ununsettledIntimacy >= 2)
            {
                //未確定の星表示
                unsettledIntimacyStar[1].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnunsettledIntimacy < 2)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.intimacyLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2;
                            break;

                        case 1:
                            consumptionPoint = Level2;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledIntimacyStar[1].enabled = false;
            }

            //未確定の親愛度レベル3の強化選択状態
            if (ununsettledIntimacy >= 3)
            {
                //未確定の星表示
                unsettledIntimacyStar[2].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnunsettledIntimacy < 3)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.intimacyLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3;
                            break;

                        case 2:
                            consumptionPoint = Level3;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledIntimacyStar[2].enabled = false;
            }

            //未確定の親愛度レベル4の強化選択状態
            if (ununsettledIntimacy >= 4)
            {
                //未確定の星表示
                unsettledIntimacyStar[3].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnunsettledIntimacy < 4)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.intimacyLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3 + Level4;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3 + Level4;
                            break;

                        case 2:
                            consumptionPoint = Level3 + Level4;
                            break;

                        case 3:
                            consumptionPoint = Level4;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledIntimacyStar[3].enabled = false;
            }

            //未確定の親愛度レベル5の強化選択状態
            if (ununsettledIntimacy == 5)
            {
                //未確定の星表示
                unsettledIntimacyStar[4].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnunsettledIntimacy < 5)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.intimacyLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3 + Level4 + Level5;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3 + Level4 + Level5;
                            break;

                        case 2:
                            consumptionPoint = Level3 + Level4 + Level5;
                            break;

                        case 3:
                            consumptionPoint = Level4 + Level5;
                            break;
                        case 4:
                            consumptionPoint = Level5;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledIntimacyStar[4].enabled = false;
            }
            //強化するか尋ねるウインドウ表示状態
            if (strengtheningQuestion.activeSelf)
            {

                //Yes選択状態
                if (strengtheningQuestionnumber == 1)
                {
                    yes.color = Color.white;
                    no.color = Color.gray;
                    //強化を確定
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        if (GameController.Instance.score >= Level1)
                        {
                            //ゲームコントローラーの親愛度レベルを変更する
                            GameController.Instance.intimacyLevel = ununsettledIntimacy;

                            minimumUnunsettledIntimacy = ununsettledIntimacy;

                            //ポイントを消費
                            GameController.Instance.score -= consumptionPoint;

                            //強化するか尋ねるウインドウを非表示
                            strengtheningQuestion.SetActive(false);

                            strengtheningQuestionnumber = 0;

                            //強化確定時の音
                            audioSource.PlayOneShot(sound[1]);
                        }

                        //強化するポイントが不足していた場合に画像表示
                        else
                        {
                            strengtheningQuestionnumber = 0;

                            //強化するか尋ねるウインドウを非表示
                            strengtheningQuestion.SetActive(false);

                            //音の再生
                            audioSource.PlayOneShot(sound[3]);

                            //画像表示
                            shortagePointImage.SetActive(true);


                        }
                    }
                }

                //No選択状態
                if (strengtheningQuestionnumber == 2)
                {
                    yes.color = Color.gray;
                    no.color = Color.white;
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //強化するか尋ねるウインドウを非表示
                        strengtheningQuestion.SetActive(false);

                        strengtheningQuestionnumber = 0;

                        //No選択時の音
                        audioSource.PlayOneShot(sound[3]);
                    }
                }

            }

        }
        else
        {
            //選択イメージの非表示
            selectedImage[0].enabled = false;
        }

        //Hp選択中
        if (selectNumber == 1)
        {
            //選択中の画像表示
            selectedImage[1].enabled = true;

            //選択画像を点滅
            float bling = Mathf.Abs(Mathf.Sin(Time.time * 3));
            selectedImage[1].GetComponent<Image>().color = new Color(1f, 1f, 1f, bling);

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf && !shortagePointImage.activeSelf)
            {
                if (dpvInput == false)
                {
                    //HP選択中に左右キーで強化するレベルを選択
                    if (Input.GetKeyDown(KeyCode.RightArrow) || dpv > 0)
                    {
                        if (ununsettledHp < 5)
                        {
                            ununsettledHp++;

                            audioSource.PlayOneShot(sound[0]);

                            dpvInput = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow) || dpv < 0)
                    {
                        if (ununsettledHp > minimumUnunsettledHp)
                        {
                            ununsettledHp--;

                            audioSource.PlayOneShot(sound[0]);

                            dpvInput = true;
                        }
                    }
                }
            }

            //未確定のHPのレベル1の強化選択状態
            if (ununsettledHp >= 1)
            {
                //未確定の星表示
                unsettledHpStar[0].enabled = true;

                //消費ポイントを変更
                consumptionPoint = Level1;

                if (GameController.Instance.hpLevel == 0)
                {
                    //消費ポイントの表示を500に変更
                    consumptionPointText.text = "500";
                }
                else
                {
                    //消費ポイントの表示を0に変更
                    consumptionPointText.text = "0";
                }

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnunsettledHp < 1)
                {
                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledHpStar[0].enabled = false;
            }

            //未確定のHPのレベル2の強化選択状態
            if (ununsettledHp >= 2)
            {
                //未確定の星表示
                unsettledHpStar[1].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnunsettledHp < 2)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.hpLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2;
                            break;

                        case 1:
                            consumptionPoint = Level2;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledHpStar[1].enabled = false;
            }

            //未確定のHPのレベル3の強化選択状態
            if (ununsettledHp >= 3)
            {
                //未確定の星表示
                unsettledHpStar[2].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnunsettledHp < 3)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.hpLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3;
                            break;

                        case 2:
                            consumptionPoint = Level3;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星表示
                unsettledHpStar[2].enabled = false;
            }

            //未確定のHPのレベル4の強化選択状態
            if (ununsettledHp >= 4)
            {
                unsettledHpStar[3].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnunsettledHp < 4)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.hpLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3 + Level4;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3 + Level4;
                            break;

                        case 2:
                            consumptionPoint = Level3 + Level4;
                            break;

                        case 3:
                            consumptionPoint = Level4;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledHpStar[3].enabled = false;
            }

            //未確定のHPのレベル5の強化選択状態
            if (ununsettledHp == 5)
            {
                //未確定の星表示
                unsettledHpStar[4].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnunsettledHp < 5)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.hpLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3 + Level4 + Level5;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3 + Level4 + Level5;
                            break;

                        case 2:
                            consumptionPoint = Level3 + Level4 + Level5;
                            break;

                        case 3:
                            consumptionPoint = Level4 + Level5;
                            break;

                        case 4:
                            consumptionPoint = Level5;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledHpStar[4].enabled = false;
            }
            //強化するか尋ねるウインドウ表示状態
            if (strengtheningQuestion.activeSelf)
            {

                //Yes選択状態
                if (strengtheningQuestionnumber == 1)
                {
                    yes.color = Color.white;
                    no.color = Color.gray;
                    //強化を確定
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        if (GameController.Instance.score >= consumptionPoint)
                        {
                            //ゲームコントローラーのHPレベルを変更する
                            GameController.Instance.hpLevel = ununsettledHp;

                            minimumUnunsettledHp = ununsettledHp;

                            //ポイントを消費
                            GameController.Instance.score -= consumptionPoint;

                            //強化するか尋ねるウインドウを非表示
                            strengtheningQuestion.SetActive(false);

                            strengtheningQuestionnumber = 0;

                            //強化確定時の音
                            audioSource.PlayOneShot(sound[2]);
                        }

                        //ポイント不足の画像表示
                        else
                        {
                            strengtheningQuestionnumber = 0;

                            //強化するか尋ねるウインドウを非表示
                            strengtheningQuestion.SetActive(false);

                            //音の再生
                            audioSource.PlayOneShot(sound[3]);

                            //画像表示
                            shortagePointImage.SetActive(true);

                            //音の再生
                            audioSource.PlayOneShot(sound[3]);
                        }
                    }
                }

                //No選択状態
                if (strengtheningQuestionnumber == 2)
                {
                    yes.color = Color.gray;
                    no.color = Color.white;
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //強化するか尋ねるウインドウを非表示
                        strengtheningQuestion.SetActive(false);

                        strengtheningQuestionnumber = 0;

                        //No選択時の音
                        audioSource.PlayOneShot(sound[3]);
                    }
                }

            }
        }
        else
        {
            selectedImage[1].enabled = false;
        }

        //活動時間選択中
        if (selectNumber == 2)
        {
            //選択中の画像表示
            selectedImage[2].enabled = true;

            //選択画像を点滅
            float bling = Mathf.Abs(Mathf.Sin(Time.time * 3));
            selectedImage[2].GetComponent<Image>().color = new Color(1f, 1f, 1f, bling);

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf && !shortagePointImage.activeSelf)
            {
                if (dpvInput == false)
                {
                    //活動時間選択中に左右キーで強化するレベルを選択
                    if (Input.GetKeyDown(KeyCode.RightArrow)|| dpv > 0)
                    {
                        if (ununsettledActivityTime < 5)
                        {
                            ununsettledActivityTime++;

                            audioSource.PlayOneShot(sound[0]);

                            dpvInput = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow)|| dpv < 0)
                    {
                        if (ununsettledActivityTime > minimumUnununsettledActivityTime)
                        {
                            ununsettledActivityTime--;

                            audioSource.PlayOneShot(sound[0]);

                            dpvInput = true;
                        }
                    }
                }
            }

            //未確定の活動時間のレベル1の強化選択状態
            if (ununsettledActivityTime >= 1)
            {
                //未確定の星表示
                unsettledActivityTimeStar[0].enabled = true;

                //消費ポイントを変更
                consumptionPoint = Level1;

                if (GameController.Instance.activityTimeLevel == 0)
                {
                    //消費ポイントの表示を500に変更
                    consumptionPointText.text = "500";
                }
                else
                {
                    //消費ポイントの表示を0に変更
                    consumptionPointText.text = "0";
                }

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledActivityTime < 1)
                {
                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledActivityTimeStar[0].enabled = false;
            }

            //未確定の活動時間のレベル2の強化選択状態
            if (ununsettledActivityTime >= 2)
            {
                //未確定の星表示
                unsettledActivityTimeStar[1].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledActivityTime < 2)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.activityTimeLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2;
                            break;

                        case 1:
                            consumptionPoint = Level2;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledActivityTimeStar[1].enabled = false;
            }

            //未確定の活動時間のレベル3の強化選択状態
            if (ununsettledActivityTime >= 3)
            {
                //未確定の星表示
                unsettledActivityTimeStar[2].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledActivityTime < 3)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.activityTimeLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3;
                            break;

                        case 2:
                            consumptionPoint = Level3;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledActivityTimeStar[2].enabled = false;
            }

            //未確定の活動時間のレベル4の強化選択状態
            if (ununsettledActivityTime >= 4)
            {
                //未確定の星表示
                unsettledActivityTimeStar[3].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledActivityTime < 4)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.activityTimeLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3 + Level4;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3 + Level4;
                            break;

                        case 2:
                            consumptionPoint = Level3 + Level4;
                            break;

                        case 3:
                            consumptionPoint = Level4;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledActivityTimeStar[3].enabled = false;
            }

            //未確定の活動時間のレベル5の強化選択状態
            if (ununsettledActivityTime == 5)
            {
                unsettledActivityTimeStar[4].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledActivityTime < 5)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.activityTimeLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3 + Level4 + Level5;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3 + Level4 + Level5;
                            break;

                        case 2:
                            consumptionPoint = Level3 + Level4 + Level5;
                            break;

                        case 3:
                            consumptionPoint = Level4 + Level5;
                            break;

                        case 4:
                            consumptionPoint = Level5;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledActivityTimeStar[4].enabled = false;
            }
            //強化するか尋ねるウインドウ表示状態
            if (strengtheningQuestion.activeSelf)
            {
                //Yes選択状態
                if (strengtheningQuestionnumber == 1)
                {
                    yes.color = Color.white;
                    no.color = Color.gray;
                    //強化を確定
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        if (GameController.Instance.score >= consumptionPoint)
                        {
                            //ゲームコントローラーの活動時間レベルを変更する
                            GameController.Instance.activityTimeLevel = ununsettledActivityTime;

                            minimumUnununsettledActivityTime = ununsettledActivityTime;

                            //ポイントを消費
                            GameController.Instance.score -= consumptionPoint;

                            //強化するか尋ねるウインドウを非表示
                            strengtheningQuestion.SetActive(false);

                            strengtheningQuestionnumber = 0;

                            //強化確定時の音
                            audioSource.PlayOneShot(sound[2]);
                        }

                        //ポイント不足
                        else
                        {
                            strengtheningQuestionnumber = 0;

                            //強化するか尋ねるウインドウを非表示
                            strengtheningQuestion.SetActive(false);

                            //音の再生
                            audioSource.PlayOneShot(sound[3]);

                            //画像表示
                            shortagePointImage.SetActive(true);

                            //音の再生
                            audioSource.PlayOneShot(sound[3]);
                        }
                    }
                }

                //No選択状態
                if (strengtheningQuestionnumber == 2)
                {
                    yes.color = Color.gray;
                    no.color = Color.white;
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //強化するか尋ねるウインドウを非表示
                        strengtheningQuestion.SetActive(false);

                        strengtheningQuestionnumber = 0;

                        //No選択時の音
                        audioSource.PlayOneShot(sound[3]);
                    }
                }
            }
        }
        //選択中の画像非表示
        else
        {
            selectedImage[2].enabled = false;
        }

        //攻撃選択中
        if (selectNumber == 3)
        {
            //選択中の画像表示
            selectedImage[3].enabled = true;

            //選択画像を点滅
            float bling = Mathf.Abs(Mathf.Sin(Time.time * 3));
            selectedImage[3].GetComponent<Image>().color = new Color(1f, 1f, 1f, bling);

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf && !shortagePointImage.activeSelf)
            {
                if (dpvInput == false)
                {
                    //攻撃選択中に左右キーで強化するレベルを選択
                    if (Input.GetKeyDown(KeyCode.RightArrow)|| dpv > 0)
                    {
                        if (ununsettledAttack < 5)
                        {
                            ununsettledAttack++;

                            audioSource.PlayOneShot(sound[0]);

                            dpvInput = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow)|| dpv < 0)
                    {
                        if (ununsettledAttack > minimumUnununsettledAttack)
                        {
                            ununsettledAttack--;

                            audioSource.PlayOneShot(sound[0]);

                            dpvInput = true;
                        }
                    }
                }
            }

            //未確定の攻撃のレベル1の強化選択状態
            if (ununsettledAttack >= 1)
            {
                //未確定の星表示
                unsettledAttackStar[0].enabled = true;

                //消費ポイントを変更
                consumptionPoint = Level1;

                if (GameController.Instance.attackLevel == 0)
                {
                    //消費ポイントの表示を500に変更
                    consumptionPointText.text = "500";
                }
                else
                {
                    //消費ポイントの表示を0に変更
                    consumptionPointText.text = "0";
                }

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledAttack < 1)
                {
                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledAttackStar[0].enabled = false;
            }

            //未確定の攻撃のレベル2の強化選択状態
            if (ununsettledAttack >= 2)
            {
                //未確定の星表示
                unsettledAttackStar[1].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledAttack < 2)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.attackLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2;
                            break;

                        case 1:
                            consumptionPoint = Level2;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledAttackStar[1].enabled = false;
            }

            //未確定の攻撃のレベル3の強化選択状態
            if (ununsettledAttack >= 3)
            {
                //未確定の星表示
                unsettledAttackStar[2].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledAttack < 3)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.attackLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3;
                            break;

                        case 2:
                            consumptionPoint = Level3;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();


                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledAttackStar[2].enabled = false;
            }

            //未確定の攻撃のレベル4の強化選択状態
            if (ununsettledAttack >= 4)
            {
                //未確定の星表示
                unsettledAttackStar[3].enabled = true;


                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledAttack < 4)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.attackLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3 + Level4;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3 + Level4;
                            break;

                        case 2:
                            consumptionPoint = Level3 + Level4;
                            break;

                        case 3:
                            consumptionPoint = Level4;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();


                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledAttackStar[3].enabled = false;
            }

            //未確定の攻撃のレベル5の強化選択状態
            if (ununsettledAttack == 5)
            {
                //未確定の星表示
                unsettledAttackStar[4].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledAttack < 5)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.attackLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3 + Level4 + Level5;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3 + Level4 + Level5;
                            break;

                        case 2:
                            consumptionPoint = Level3 + Level4 + Level5;
                            break;

                        case 3:
                            consumptionPoint = Level4 + Level5;
                            break;

                        case 4:
                            consumptionPoint = Level5;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();


                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledAttackStar[4].enabled = false;
            }
            //強化するか尋ねるウインドウ表示状態
            if (strengtheningQuestion.activeSelf)
            {

                //Yes選択状態
                if (strengtheningQuestionnumber == 1)
                {
                    yes.color = Color.white;
                    no.color = Color.gray;
                    //強化を確定
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        if (GameController.Instance.score >= consumptionPoint)
                        {
                            //ゲームコントローラーの攻撃レベルを変更する
                            GameController.Instance.attackLevel = ununsettledAttack;

                            minimumUnununsettledAttack = ununsettledAttack;

                            //ポイントを消費
                            GameController.Instance.score -= consumptionPoint;

                            //強化するか尋ねるウインドウを非表示
                            strengtheningQuestion.SetActive(false);

                            strengtheningQuestionnumber = 0;

                            //強化確定時の音
                            audioSource.PlayOneShot(sound[2]);
                        }

                        //ポイント不足の画像表示
                        else
                        {
                            strengtheningQuestionnumber = 0;

                            //強化するか尋ねるウインドウを非表示
                            strengtheningQuestion.SetActive(false);

                            //音の再生
                            audioSource.PlayOneShot(sound[3]);

                            //画像表示
                            shortagePointImage.SetActive(true);

                            //音の再生
                            audioSource.PlayOneShot(sound[3]);
                        }
                    }
                }

                //No選択状態
                if (strengtheningQuestionnumber == 2)
                {
                    yes.color = Color.gray;
                    no.color = Color.white;
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //強化するか尋ねるウインドウを非表示
                        strengtheningQuestion.SetActive(false);

                        strengtheningQuestionnumber = 0;

                        //No選択時の音
                        audioSource.PlayOneShot(sound[3]);
                    }
                }
            }
        }
        else
        {
            //選択中の画像非表示
            selectedImage[3].enabled = false;
        }

        //連射速度選択中
        if (selectNumber == 4)
        {
            //選択中の画像表示
            selectedImage[4].enabled = true;

            //選択画像を点滅
            float bling = Mathf.Abs(Mathf.Sin(Time.time * 3));
            selectedImage[4].GetComponent<Image>().color = new Color(1f, 1f, 1f, bling);

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf && !shortagePointImage.activeSelf)
            {
                if (dpvInput == false)
                {
                    //連射速度選択中に左右キーで強化するレベルを選択
                    if (Input.GetKeyDown(KeyCode.RightArrow)|| dpv>0)
                    {
                        if (ununsettledRapidfire < 5)
                        {
                            ununsettledRapidfire++;

                            audioSource.PlayOneShot(sound[0]);

                            dpvInput = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow)|| dpv < 0)
                    {
                        if (ununsettledRapidfire > minimumUnununsettledRapidfire)
                        {
                            ununsettledRapidfire--;

                            audioSource.PlayOneShot(sound[0]);

                            dpvInput = true;
                        }
                    }
                }
            }

            //未確定の活動時間のレベル1の強化選択状態
            if (ununsettledRapidfire >= 1)
            {
                //未確定の星表示
                unsettledRapidfireStar[0].enabled = true;

                //消費ポイントを変更
                consumptionPoint = Level1;

                if (GameController.Instance.rapidfireLevel == 0)
                {
                    //消費ポイントの表示を500に変更
                    consumptionPointText.text = "500";
                }
                else
                {
                    //消費ポイントの表示を0に変更
                    consumptionPointText.text = "0";
                }

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledRapidfire < 1)
                {
                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledRapidfireStar[0].enabled = false;
            }

            //未確定の活動時間のレベル2の強化選択状態
            if (ununsettledRapidfire >= 2)
            {
                //未確定の星表示
                unsettledRapidfireStar[1].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledRapidfire < 2)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.rapidfireLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2;
                            break;

                        case 1:
                            consumptionPoint = Level2;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledRapidfireStar[1].enabled = false;
            }

            //未確定の活動時間のレベル3の強化選択状態
            if (ununsettledRapidfire >= 3)
            {
                //未確定の星表示
                unsettledRapidfireStar[2].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledRapidfire < 3)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.rapidfireLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3;
                            break;

                        case 2:
                            consumptionPoint = Level3;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledRapidfireStar[2].enabled = false;
            }

            //未確定の活動時間のレベル4の強化選択状態
            if (ununsettledRapidfire >= 4)
            {
                //未確定の星表示
                unsettledRapidfireStar[3].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledRapidfire < 4)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.rapidfireLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3 + Level4;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3 + Level4;
                            break;

                        case 2:
                            consumptionPoint = Level3 + Level4;
                            break;

                        case 3:
                            consumptionPoint = Level4;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledRapidfireStar[3].enabled = false;
            }

            //未確定の活動時間のレベル5の強化選択状態
            if (ununsettledRapidfire == 5)
            {
                //未確定の星表示
                unsettledRapidfireStar[4].enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumUnununsettledRapidfire < 5)
                {
                    //消費ポイントを現在のレベルによって変更
                    switch (GameController.Instance.rapidfireLevel)
                    {
                        case 0:
                            consumptionPoint = Level1 + Level2 + Level3 + Level4 + Level5;
                            break;

                        case 1:
                            consumptionPoint = Level2 + Level3 + Level4 + Level5;
                            break;

                        case 2:
                            consumptionPoint = Level3 + Level4 + Level5;
                            break;

                        case 3:
                            consumptionPoint = Level4 + Level5;
                            break;

                        case 4:
                            consumptionPoint = Level5;
                            break;
                    }

                    //消費ポイントの表示を変更
                    consumptionPointText.text = (consumptionPoint).ToString();

                    //ポイント不足が非表示のとき
                    if (!shortagePointImage.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                        {
                            //強化するか選択するウインドウを表示
                            strengtheningQuestion.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                //未確定の星非表示
                unsettledRapidfireStar[4].enabled = false;
            }
            //強化するか尋ねるウインドウ表示状態
            if (strengtheningQuestion.activeSelf)
            {

                //Yes選択状態
                if (strengtheningQuestionnumber == 1)
                {
                    yes.color = Color.white;
                    no.color = Color.gray;
                    //強化を確定
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        if (GameController.Instance.score >= consumptionPoint)
                        {
                            //ゲームコントローラーの活動時間レベルを変更する
                            GameController.Instance.rapidfireLevel = ununsettledRapidfire;

                            minimumUnununsettledRapidfire = ununsettledRapidfire;

                            //ポイントを消費
                            GameController.Instance.score -= consumptionPoint;

                            //強化するか尋ねるウインドウを非表示
                            strengtheningQuestion.SetActive(false);

                            strengtheningQuestionnumber = 0;

                            //強化確定時の音
                            audioSource.PlayOneShot(sound[2]);
                        }

                        //ポイント不足
                        else
                        {
                            strengtheningQuestionnumber = 0;

                            //強化するか尋ねるウインドウを非表示
                            strengtheningQuestion.SetActive(false);

                            //音の再生
                            audioSource.PlayOneShot(sound[3]);

                            //画像表示
                            shortagePointImage.SetActive(true);

                            //音の再生
                            audioSource.PlayOneShot(sound[3]);
                        }
                    }
                }

                //No選択状態
                if (strengtheningQuestionnumber == 2)
                {
                    yes.color = Color.gray;
                    no.color = Color.white;
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //強化するか尋ねるウインドウを非表示
                        strengtheningQuestion.SetActive(false);

                        strengtheningQuestionnumber = 0;

                        //No選択時の音
                        audioSource.PlayOneShot(sound[3]);
                    }
                }

            }
        }
        //選択中の画像非表示
        else
        {
            selectedImage[4].enabled = false;
        }

        //出撃選択中
        if (selectNumber == 5)
        {
            //選択中の画像表示
            sortieImage.color = Color.white;

            //選択画像を点滅
            float bling = Mathf.Abs(Mathf.Sin(Time.time * 3));
            sortieImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, bling);

            //Bボタン、もしくはエンターキーで出撃
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
            {
                switch (GameController.Instance.stage)
                {
                    case 0:
                        SceneManager.LoadScene("Stage1");
                        break;
                    case 1:
                        SceneManager.LoadScene("Stage2");
                        break;
                    case 2:
                        SceneManager.LoadScene("Stage3");
                        break;
                    case 3:
                        SceneManager.LoadScene("Stage4");
                        break;
                    case 4:
                        SceneManager.LoadScene("Stage5");
                        break;
                    case 5:
                        SceneManager.LoadScene("Stage6");
                        break;
                    case 6:
                        SceneManager.LoadScene("Stage7");
                        break;
                    case 7:
                        SceneManager.LoadScene("Stage8");
                        break;
                    case 8:
                        SceneManager.LoadScene("Stage9");
                        break;
                    case 9:
                        SceneManager.LoadScene("Stage10");
                        break;
                    case 10:
                        SceneManager.LoadScene("Stage11");
                        break;
                    case 11:
                        SceneManager.LoadScene("Stage12");
                        break;
                }
            }
        }
        else
        {
            //選択中の画像非表示
            sortieImage.color = Color.gray;
        }

        //親愛度の星表示
        for (int i = 0; i < GameController.Instance.intimacyLevel; i++)
        {
            intimacyStar[i].enabled = true;
        }

        //親愛度を選択していないときに未確定の星の画像を非表示
        if (selectNumber != 0)
        {
            ununsettledIntimacy = minimumUnunsettledIntimacy;

            for (int i = 0; i < 5; i++)
            {
                unsettledIntimacyStar[i].enabled = false;
            }
        }

        //Hpの星表示
        for (int i = 0; i < GameController.Instance.hpLevel; i++)
        {
            hpStar[i].enabled = true;
        }

        //HPを選択していないときに未確定の星の画像を非表示
        if (selectNumber != 1)
        {
            ununsettledHp = minimumUnunsettledHp;

            for (int i = 0; i < 5; i++)
            {
                unsettledHpStar[i].enabled = false;
            }
        }

        //活動時間の星表示
        for (int i = 0; i < GameController.Instance.activityTimeLevel; i++)
        {
            activityTimeStar[i].enabled = true;
        }

        //活動時間を選択していないときに未確定の星の画像を非表示
        if (selectNumber != 2)
        {
            ununsettledActivityTime = minimumUnununsettledActivityTime;

            for (int i = 0; i < 5; i++)
            {
                unsettledActivityTimeStar[i].enabled = false;
            }
        }

        //攻撃の星表示
        for (int i = 0; i < GameController.Instance.attackLevel; i++)
        {
            attackStar[i].enabled = true;
        }

        //攻撃を選択していないときに未確定の星の画像を非表示
        if (selectNumber != 3)
        {
            ununsettledAttack = minimumUnununsettledAttack;

            for (int i = 0; i < 5; i++)
            {
                unsettledAttackStar[i].enabled = false;
            }
        }

        //連射速度の星表示
        for (int i = 0; i < GameController.Instance.rapidfireLevel; i++)
        {
            rapidfireStar[i].enabled = true;
        }

        //連射速度を選択していないときに未確定の星の画像を非表示
        if (selectNumber != 4)
        {
            ununsettledRapidfire = minimumUnununsettledRapidfire;

            for (int i = 0; i < 5; i++)
            {
                unsettledRapidfireStar[i].enabled = false;
            }
        }

        //選択したステージのテキスト表示の変更
        switch (GameController.Instance.stage)
        {
            case 0:
                selectedStage.text = ("Stage-1");
                break;
            case 1:
                selectedStage.text = ("Stage-2");
                break;
            case 2:
                selectedStage.text = ("Stage-3");
                break;
            case 3:
                selectedStage.text = ("Stage-4");
                break;
            case 4:
                selectedStage.text = ("Stage-5");
                break;
            case 5:
                selectedStage.text = ("Stage-6");
                break;
            case 6:
                selectedStage.text = ("Stage-7");
                break;
            case 7:
                selectedStage.text = ("Stage-8");
                break;
            case 8:
                selectedStage.text = ("Stage-9");
                break;
            case 9:
                selectedStage.text = ("Stage-10");
                break;
            case 10:
                selectedStage.text = ("Stage-11");
                break;
            case 11:
                selectedStage.text = ("Stage-12");
                break;
        }
    }
}

