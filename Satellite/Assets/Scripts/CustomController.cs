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
    int ununsettledactivityTime = 0;
    int minimumunununsettledactivityTime = 0;

    //未確定の攻撃の星の画像の表示を数値で管理
    int ununsettledattack = 0;
    int minimumunununsettledattack = 0;

    //未確定の連射速度の星の画像の表示を数値で管理
    int ununsettledrapidfire = 0;
    int minimumunununsettledrapidfire = 0;

    //親愛度
    public Image selectedIntimacyImage;
    //HP
    public Image selectedHpImage;
    //活動時間
    public Image selectedActivityTimeImage;
    //攻撃
    public Image selectedAttackImage;
    //連射速度
    public Image selectedRapidfireImage;
    //出撃
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
    public Image unsettledintimacyStar_first;
    public Image unsettledintimacyStar_second;
    public Image unsettledintimacyStar_third;
    public Image unsettledintimacyStar_fourth;
    public Image unsettledintimacyStar_fifth;

    //HPの星の画像
    public Image[] hpStar;

    //未確定のHPの星の画像
    public Image unsettledhpStar_first;
    public Image unsettledhpStar_second;
    public Image unsettledhpStar_third;
    public Image unsettledhpStar_fourth;
    public Image unsettledhpStar_fifth;

    //活動時間の星の画像
    public Image[] activityTimeStar;

    //未確定の活動時間の星の画像
    public Image unsettledactivityTimeStar_first;
    public Image unsettledactivityTimeStar_second;
    public Image unsettledactivityTimeStar_third;
    public Image unsettledactivityTimeStar_fourth;
    public Image unsettledactivityTimeStar_fifth;

    //攻撃の星の画像
    public Image[] attackStar;

    //未確定の攻撃の星の画像
    public Image unsettledattackStar_first;
    public Image unsettledattackStar_second;
    public Image unsettledattackStar_third;
    public Image unsettledattackStar_fourth;
    public Image unsettledattackStar_fifth;

    //連射速度の星イメージ
    public Image[] rapidfireStar;

    //未確定の連射速度の星イメージ
    public Image unsettledrapidfireStar_first;
    public Image unsettledrapidfireStar_second;
    public Image unsettledrapidfireStar_third;
    public Image unsettledrapidfireStar_fourth;
    public Image unsettledrapidfireStar_fifth;

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
    int consumptionPoint;
    //消費ポイントのテキスト
    public Text consumptionPointText;

    //音
    AudioSource audioSource;
    //音を配列で管理
    public AudioClip[] sound;

    // Start is called before the first frame update
    void Start()
    {
        //シーン開始時に選択中画像を非表示
        selectedIntimacyImage.enabled = false;
        selectedHpImage.enabled = false;
        selectedActivityTimeImage.enabled = false;
        selectedAttackImage.enabled = false;
        selectedRapidfireImage.enabled = false;

        //シーン開始時に選択イメージをグレーに
        sortieImage.color = Color.gray;
        
        //シーン開始時に親愛度の星の画像をを非表示
        for(int i = 0; i < 5; i++)
        {
            intimacyStar[i].enabled = false;
        }

        //シーン開始時に未確定の親愛度の星の画像を非表示
        unsettledintimacyStar_first.enabled = false;
        unsettledintimacyStar_second.enabled = false;
        unsettledintimacyStar_third.enabled = false;
        unsettledintimacyStar_fourth.enabled = false;
        unsettledintimacyStar_fifth.enabled = false;

        //シーン開始時にHpの星を非表示
        for (int i = 0; i < 5; i++)
        {
            hpStar[i].enabled = false;
        }

        //シーン開始時に未確定のHpの星を非表示
        unsettledhpStar_first.enabled = false;
        unsettledhpStar_second.enabled = false;
        unsettledhpStar_third.enabled = false;
        unsettledhpStar_fourth.enabled = false;
        unsettledhpStar_fifth.enabled = false;

        //シーン開始時に活動時間の星を非表示
        for (int i = 0; i < 5; i++)
        {
            activityTimeStar[i].enabled = false;
        }

        //シーン開始時に未確定の活動時間の星を非表示
        unsettledactivityTimeStar_first.enabled = false;
        unsettledactivityTimeStar_second.enabled = false;
        unsettledactivityTimeStar_third.enabled = false;
        unsettledactivityTimeStar_fourth.enabled = false;
        unsettledactivityTimeStar_fifth.enabled = false;

        //シーン開始時に攻撃の星を非表示
        for (int i = 0; i < 5; i++)
        {
            attackStar[i].enabled = false;
        }

        //シーン開始時に未確定の攻撃の星を非表示
        unsettledattackStar_first.enabled = false;
        unsettledattackStar_second.enabled = false;
        unsettledattackStar_third.enabled = false;
        unsettledattackStar_fourth.enabled = false;
        unsettledattackStar_fifth.enabled = false;

        //シーン開始時に連射速度の星を非表示
        for (int i = 0; i < 5; i++)
        {
            rapidfireStar[i].enabled = false;
        }

        //シーン開始時に未確定の連射速度の星を非表示
        unsettledrapidfireStar_first.enabled = false;
        unsettledrapidfireStar_second.enabled = false;
        unsettledrapidfireStar_third.enabled = false;
        unsettledrapidfireStar_fourth.enabled = false;
        unsettledrapidfireStar_fifth.enabled = false;

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
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameController.Instance.score += 10000;
        }

        //十字キー縦の入力
        float dph = Input.GetAxis("D_Pad_H");
        //十字キー横の入力
        float dpv = Input.GetAxis("D_Pad_V");

        //所持ポイントを表示
        possessionPointText.text = (GameController.Instance.score).ToString();

        //強化の確定を選択する画面が表示中にSelectNumberの数値が変更されないようにする
        if (!strengtheningQuestion.activeSelf&&!shortagePointImage.activeSelf)
        {
            //上矢印キーを押したときSelectNumberを減らす
            if (Input.GetKeyDown(KeyCode.UpArrow) || dph > 0)
            {
                selectNumber--;
                audioSource.PlayOneShot(sound[0]);
            }

            //下矢印キーを押したときSelectNumberを増やす
            if (Input.GetKeyDown(KeyCode.DownArrow) || dph < 0)
            {
                selectNumber++;
                audioSource.PlayOneShot(sound[0]);
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
            if (Input.GetKeyDown(KeyCode.UpArrow) || dph > 0)
            {
                strengtheningQuestionnumber = 1;
                audioSource.PlayOneShot(sound[0]);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || dph < 0)
            {
                strengtheningQuestionnumber = 2;
                audioSource.PlayOneShot(sound[0]);
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
            if (Input.GetKeyDown(KeyCode.Backspace)|| Input.GetKeyDown("joystick button 0"))
            {
                shortagePointImage.SetActive(false);
            }
        }

        //ステージ選択画面に戻る
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadScene("StageSelect");
        }

        //親愛度選択中
        if (selectNumber == 0)
        {
            //選択中の画像表示
            selectedIntimacyImage.enabled = true;
            selectedHpImage.enabled = false;
            selectedActivityTimeImage.enabled = false;
            selectedAttackImage.enabled = false;
            selectedRapidfireImage.enabled = false;
            sortieImage.color = Color.gray;

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf&&!shortagePointImage.activeSelf)
            {
                //親愛度選択中に左右キーで強化するレベルを選択
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (ununsettledIntimacy < 5)
                    {
                        ununsettledIntimacy++;

                        audioSource.PlayOneShot(sound[0]);
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (ununsettledIntimacy > minimumUnunsettledIntimacy)
                    {
                        ununsettledIntimacy--;

                        audioSource.PlayOneShot(sound[0]);
                    }
                }
            }

            if (ununsettledIntimacy == 0)
            {
                unsettledintimacyStar_first.enabled = false;
            }

            //未確定の親愛度のレベル1の強化選択状態
            if (ununsettledIntimacy == 1)
            {
                unsettledintimacyStar_first.enabled = true;
                unsettledintimacyStar_second.enabled = false;
                unsettledintimacyStar_third.enabled = false;
                unsettledintimacyStar_fourth.enabled = false;
                unsettledintimacyStar_fifth.enabled = false;

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
                if (minimumUnunsettledIntimacy < 1)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= Level1)
                                {
                                    //ゲームコントローラーの親愛度レベルを1にする
                                    GameController.Instance.intimacyLevel = 1;

                                    minimumUnunsettledIntimacy = 1;

                                    //ポイントを消費
                                    GameController.Instance.score -= Level1;

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

                                    shortagePointImage.SetActive(true);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の親愛度のレベル2の強化選択状態
            if (ununsettledIntimacy == 2)
            {
                unsettledintimacyStar_first.enabled = true;
                unsettledintimacyStar_second.enabled = true;
                unsettledintimacyStar_third.enabled = false;
                unsettledintimacyStar_fourth.enabled = false;
                unsettledintimacyStar_fifth.enabled = false;


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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの親愛度レベルを2にする
                                    GameController.Instance.intimacyLevel = 2;

                                    minimumUnunsettledIntimacy = 2;

                                    //ポイントを消費
                                    GameController.Instance.score -= consumptionPoint;

                                    //強化するか尋ねるウインドウを非表示
                                    strengtheningQuestion.SetActive(false);

                                    strengtheningQuestionnumber = 0;

                                    //強化確定時の音
                                    audioSource.PlayOneShot(sound[1]);
                                }

                                //ポイント不足
                                else
                                {
                                    strengtheningQuestionnumber = 0;

                                    shortagePointImage.SetActive(true);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の親愛度レベル3の強化選択状態
            if (ununsettledIntimacy == 3)
            {
                unsettledintimacyStar_first.enabled = true;
                unsettledintimacyStar_second.enabled = true;
                unsettledintimacyStar_third.enabled = true;
                unsettledintimacyStar_fourth.enabled = false;
                unsettledintimacyStar_fifth.enabled = false;

               

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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの親愛度レベルを3にする
                                    GameController.Instance.intimacyLevel = 3;

                                    minimumUnunsettledIntimacy = 3;

                                    //ポイントを消費
                                    GameController.Instance.score -= consumptionPoint;

                                    strengtheningQuestionnumber = 0;

                                    //強化するか尋ねるウインドウを非表示
                                    strengtheningQuestion.SetActive(false);

                                    //強化確定時の音
                                    audioSource.PlayOneShot(sound[1]);
                                }

                                //ポイント不足
                                else
                                {
                                    strengtheningQuestionnumber = 0;

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の親愛度レベル4の強化選択状態
            if (ununsettledIntimacy == 4)
            {
                unsettledintimacyStar_first.enabled = true;
                unsettledintimacyStar_second.enabled = true;
                unsettledintimacyStar_third.enabled = true;
                unsettledintimacyStar_fourth.enabled = true;
                unsettledintimacyStar_fifth.enabled = false;

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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの親愛度レベルを4にする
                                    GameController.Instance.intimacyLevel = 4;

                                    minimumUnunsettledIntimacy = 4;

                                    //ポイントを消費
                                    GameController.Instance.score -= consumptionPoint;

                                    strengtheningQuestionnumber = 0;

                                    //強化するか尋ねるウインドウを非表示
                                    strengtheningQuestion.SetActive(false);

                                    //強化確定時の音
                                    audioSource.PlayOneShot(sound[1]);

                                }

                                //ポイント不足
                                else
                                {
                                    strengtheningQuestionnumber = 0;

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の親愛度レベル5の強化選択状態
            if (ununsettledIntimacy == 5)
            {
                unsettledintimacyStar_first.enabled = true;
                unsettledintimacyStar_second.enabled = true;
                unsettledintimacyStar_third.enabled = true;
                unsettledintimacyStar_fourth.enabled = true;
                unsettledintimacyStar_fifth.enabled = true;

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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの親愛度レベルを5にする
                                    GameController.Instance.intimacyLevel = 5;

                                    minimumUnunsettledIntimacy = 5;

                                    strengtheningQuestionnumber = 0;

                                    //ポイントを消費
                                    GameController.Instance.score -= consumptionPoint;

                                    //強化するか尋ねるウインドウを非表示
                                    strengtheningQuestion.SetActive(false);

                                    //強化確定時の音
                                    audioSource.PlayOneShot(sound[1]);

                                }

                                //ポイント不足
                                else
                                {
                                    strengtheningQuestionnumber = 0;

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }
                    
        }

        //Hp選択中
        if (selectNumber == 1)
        {
            //選択中の画像表示
            selectedIntimacyImage.enabled = false;
            selectedHpImage.enabled = true;
            selectedActivityTimeImage.enabled = false;
            selectedAttackImage.enabled = false;
            selectedRapidfireImage.enabled = false;
            sortieImage.color = Color.gray;

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf && !shortagePointImage.activeSelf)
            {
                //HP選択中に左右キーで強化するレベルを選択
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (ununsettledHp < 5)
                    {
                        ununsettledHp++;

                        audioSource.PlayOneShot(sound[0]);
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (ununsettledHp > minimumUnunsettledHp)
                    {
                        ununsettledHp--;

                        audioSource.PlayOneShot(sound[0]);
                    }
                }
            }

            if (ununsettledIntimacy == 0)
            {
                unsettledintimacyStar_first.enabled = false;
            }

            //未確定のHPのレベル1の強化選択状態
            if (ununsettledHp == 1)
            {
                unsettledhpStar_first.enabled = true;
                unsettledhpStar_second.enabled = false;
                unsettledhpStar_third.enabled = false;
                unsettledhpStar_fourth.enabled = false;
                unsettledhpStar_fifth.enabled = false;

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
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= Level1)
                                {
                                    //ゲームコントローラーのHPレベルを1にする
                                    GameController.Instance.hpLevel = 1;

                                    minimumUnunsettledHp = 1;

                                    //ポイントを消費
                                    GameController.Instance.score -= Level1;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定のHPのレベル2の強化選択状態
            if (ununsettledHp == 2)
            {
                unsettledhpStar_first.enabled = true;
                unsettledhpStar_second.enabled = true;
                unsettledhpStar_third.enabled = false;
                unsettledhpStar_fourth.enabled = false;
                unsettledhpStar_fifth.enabled = false;

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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーのHPレベルを2にする
                                    GameController.Instance.hpLevel = 2;

                                    minimumUnunsettledHp = 2;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定のHPのレベル3の強化選択状態
            if (ununsettledHp == 3)
            {
                unsettledhpStar_first.enabled = true;
                unsettledhpStar_second.enabled = true;
                unsettledhpStar_third.enabled = true;
                unsettledhpStar_fourth.enabled = false;
                unsettledhpStar_fifth.enabled = false;

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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
                    }

                    //強化するか尋ねるウインドウ表示状態
                    if (strengtheningQuestion.activeSelf)
                    {

                        //Yes選択状態
                        if (strengtheningQuestionnumber == 1)
                        {
                            yes.color = Color.white;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーのHPレベルを3にする
                                    GameController.Instance.hpLevel = 3;

                                    minimumUnunsettledHp = 3;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定のHPのレベル4の強化選択状態
            if (ununsettledHp == 4)
            {
                unsettledhpStar_first.enabled = true;
                unsettledhpStar_second.enabled = true;
                unsettledhpStar_third.enabled = true;
                unsettledhpStar_fourth.enabled = true;
                unsettledhpStar_fifth.enabled = false;

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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーのHPレベルを4にする
                                    GameController.Instance.hpLevel = 4;

                                    minimumUnunsettledHp = 4;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定のHPのレベル5の強化選択状態
            if (ununsettledHp == 5)
            {
                unsettledhpStar_first.enabled = true;
                unsettledhpStar_second.enabled = true;
                unsettledhpStar_third.enabled = true;
                unsettledhpStar_fourth.enabled = true;
                unsettledhpStar_fifth.enabled = true;

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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーのHPレベルを5にする
                                    GameController.Instance.hpLevel = 5;

                                    minimumUnunsettledHp = 5;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }
        }

        //活動時間選択中
        if (selectNumber == 2)
        {
            //選択中の画像表示
            selectedIntimacyImage.enabled = false;
            selectedHpImage.enabled = false;
            selectedActivityTimeImage.enabled = true;
            selectedAttackImage.enabled = false;
            selectedRapidfireImage.enabled = false;
            sortieImage.color = Color.gray;

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf && !shortagePointImage.activeSelf)
            {
                //HP選択中に左右キーで強化するレベルを選択
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (ununsettledactivityTime < 5)
                    {
                        ununsettledactivityTime++;

                        audioSource.PlayOneShot(sound[0]);
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (ununsettledactivityTime > minimumunununsettledactivityTime)
                    {
                        ununsettledactivityTime--;

                        audioSource.PlayOneShot(sound[0]);
                    }
                }
            }

            //何も選択していないとき星を非表示
            if (ununsettledactivityTime == 0)
            {
                unsettledactivityTimeStar_first.enabled = false;
            }

            //未確定の活動時間のレベル1の強化選択状態
            if (ununsettledactivityTime == 1)
            {
                unsettledactivityTimeStar_first.enabled = true;
                unsettledactivityTimeStar_second.enabled = false;
                unsettledactivityTimeStar_third.enabled = false;
                unsettledactivityTimeStar_fourth.enabled = false;
                unsettledactivityTimeStar_fifth.enabled = false;

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
                if (minimumunununsettledactivityTime < 1)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= Level1)
                                {
                                    //ゲームコントローラーの活動時間レベルを1にする
                                    GameController.Instance.activityTimeLevel = 1;

                                    minimumunununsettledactivityTime = 1;

                                    //ポイントを消費
                                    GameController.Instance.score -= Level1;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の活動時間のレベル2の強化選択状態
            if (ununsettledactivityTime == 2)
            {
                unsettledactivityTimeStar_first.enabled = true;
                unsettledactivityTimeStar_second.enabled = true;
                unsettledactivityTimeStar_third.enabled = false;
                unsettledactivityTimeStar_fourth.enabled = false;
                unsettledactivityTimeStar_fifth.enabled = false;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledactivityTime < 2)
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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの活動時間レベルを2にする
                                    GameController.Instance.activityTimeLevel = 2;

                                    minimumunununsettledactivityTime = 2;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の活動時間のレベル3の強化選択状態
            if (ununsettledactivityTime == 3)
            {
                unsettledactivityTimeStar_first.enabled = true;
                unsettledactivityTimeStar_second.enabled = true;
                unsettledactivityTimeStar_third.enabled = true;
                unsettledactivityTimeStar_fourth.enabled = false;
                unsettledactivityTimeStar_fifth.enabled = false;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledactivityTime < 3)
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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの活動時間レベルを3にする
                                    GameController.Instance.activityTimeLevel = 3;

                                    minimumunununsettledactivityTime = 3;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の活動時間のレベル4の強化選択状態
            if (ununsettledactivityTime == 4)
            {
                unsettledactivityTimeStar_first.enabled = true;
                unsettledactivityTimeStar_second.enabled = true;
                unsettledactivityTimeStar_third.enabled = true;
                unsettledactivityTimeStar_fourth.enabled = true;
                unsettledactivityTimeStar_fifth.enabled = false;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledactivityTime < 4)
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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの活動時間レベルを4にする
                                    GameController.Instance.activityTimeLevel = 4;

                                    minimumunununsettledactivityTime = 4;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の活動時間のレベル5の強化選択状態
            if (ununsettledactivityTime == 5)
            {
                unsettledactivityTimeStar_second.enabled = true;
                unsettledactivityTimeStar_third.enabled = true;
                unsettledactivityTimeStar_fourth.enabled = true;
                unsettledactivityTimeStar_fifth.enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledactivityTime < 5)
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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの活動時間レベルを5にする
                                    GameController.Instance.activityTimeLevel = 5;

                                    minimumunununsettledactivityTime = 5;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }
        }

        //攻撃選択中
        if (selectNumber == 3)
        {
            //選択中の画像表示
            selectedIntimacyImage.enabled = false;
            selectedHpImage.enabled = false;
            selectedActivityTimeImage.enabled = false;
            selectedAttackImage.enabled = true;
            selectedRapidfireImage.enabled = false;
            sortieImage.color = Color.gray;

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf && !shortagePointImage.activeSelf)
            {
                //HP選択中に左右キーで強化するレベルを選択
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (ununsettledattack < 5)
                    {
                        ununsettledattack++;

                        audioSource.PlayOneShot(sound[0]);
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (ununsettledattack > minimumunununsettledattack)
                    {
                        ununsettledattack--;

                        audioSource.PlayOneShot(sound[0]);
                    }
                }
            }

            if (ununsettledattack == 0)
            {
                unsettledattackStar_first.enabled = false;
            }

            //未確定の攻撃のレベル1の強化選択状態
            if (ununsettledattack == 1)
            {
                unsettledattackStar_first.enabled = true;
                unsettledattackStar_second.enabled = false;
                unsettledattackStar_third.enabled = false;
                unsettledattackStar_fourth.enabled = false;
                unsettledattackStar_fifth.enabled = false;

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
                if (minimumunununsettledattack < 1)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= Level1)
                                {
                                    //ゲームコントローラーの攻撃レベルを1にする
                                    GameController.Instance.attackLevel = 1;

                                    minimumunununsettledattack = 1;

                                    //ポイントを消費
                                    GameController.Instance.score -= Level1;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の攻撃のレベル2の強化選択状態
            if (ununsettledattack == 2)
            {
                unsettledattackStar_first.enabled = true;
                unsettledattackStar_second.enabled = true;
                unsettledattackStar_third.enabled = false;
                unsettledattackStar_fourth.enabled = false;
                unsettledattackStar_fifth.enabled = false;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledattack < 2)
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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの攻撃レベルを2にする
                                    GameController.Instance.attackLevel = 2;

                                    minimumunununsettledattack = 2;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の攻撃のレベル3の強化選択状態
            if (ununsettledattack == 3)
            {
                unsettledattackStar_first.enabled = true;
                unsettledattackStar_second.enabled = true;
                unsettledattackStar_third.enabled = true;
                unsettledattackStar_fourth.enabled = false;
                unsettledattackStar_fifth.enabled = false;
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

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledattack < 3)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの攻撃レベルを3にする
                                    GameController.Instance.attackLevel = 3;

                                    minimumunununsettledattack = 3;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の攻撃のレベル4の強化選択状態
            if (ununsettledattack == 4)
            {
                unsettledattackStar_first.enabled = true;
                unsettledattackStar_second.enabled = true;
                unsettledattackStar_third.enabled = true;
                unsettledattackStar_fourth.enabled = true;
                unsettledattackStar_fifth.enabled = false;
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

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledattack < 4)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの攻撃レベルを4にする
                                    GameController.Instance.attackLevel = 4;

                                    minimumunununsettledattack = 4;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の攻撃のレベル5の強化選択状態
            if (ununsettledattack == 5)
            {
                unsettledattackStar_first.enabled = true;
                unsettledattackStar_second.enabled = true;
                unsettledattackStar_third.enabled = true;
                unsettledattackStar_fourth.enabled = true;
                unsettledattackStar_fifth.enabled = true;
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

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledattack < 5)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの攻撃レベルを5にする
                                    GameController.Instance.attackLevel = 5;

                                    minimumunununsettledattack = 5;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }
        }

        //連射速度選択中
        if (selectNumber == 4)
        {
            //選択中の画像表示
            selectedIntimacyImage.enabled = false;
            selectedHpImage.enabled = false;
            selectedActivityTimeImage.enabled = false;
            selectedAttackImage.enabled = false;
            selectedRapidfireImage.enabled = true;
            sortieImage.color = Color.gray;

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf && !shortagePointImage.activeSelf)
            {
                //連射速度選択中に左右キーで強化するレベルを選択
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (ununsettledrapidfire < 5)
                    {
                        ununsettledrapidfire++;

                        audioSource.PlayOneShot(sound[0]);
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (ununsettledrapidfire > minimumunununsettledrapidfire)
                    {
                        ununsettledrapidfire--;

                        audioSource.PlayOneShot(sound[0]);
                    }
                }
            }

            if (ununsettledrapidfire == 0)
            {
                unsettledrapidfireStar_first.enabled = false;
            }

            //未確定の活動時間のレベル1の強化選択状態
            if (ununsettledrapidfire == 1)
            {
                unsettledrapidfireStar_first.enabled = true;
                unsettledrapidfireStar_second.enabled = false;
                unsettledrapidfireStar_third.enabled = false;
                unsettledrapidfireStar_fourth.enabled = false;
                unsettledrapidfireStar_fifth.enabled = false;

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
                if (minimumunununsettledrapidfire < 1)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= Level1)
                                {
                                    //ゲームコントローラーの活動時間レベルを1にする
                                    GameController.Instance.rapidfireLevel = 1;

                                    minimumunununsettledrapidfire = 1;

                                    //ポイントを消費
                                    GameController.Instance.score -= Level1;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の活動時間のレベル2の強化選択状態
            if (ununsettledrapidfire == 2)
            {
                unsettledrapidfireStar_first.enabled = true;
                unsettledrapidfireStar_second.enabled = true;
                unsettledrapidfireStar_third.enabled = false;
                unsettledrapidfireStar_fourth.enabled = false;
                unsettledrapidfireStar_fifth.enabled = false;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledrapidfire < 2)
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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
                    }

                    //強化するか尋ねるウインドウ表示状態
                    if (strengtheningQuestion.activeSelf)
                    {

                        //Yes選択状態
                        if (strengtheningQuestionnumber == 1)
                        {
                            yes.color = Color.white;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの活動時間レベルを2にする
                                    GameController.Instance.rapidfireLevel = 2;

                                    minimumunununsettledrapidfire = 2;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の活動時間のレベル3の強化選択状態
            if (ununsettledrapidfire == 3)
            {
                unsettledrapidfireStar_first.enabled = true;
                unsettledrapidfireStar_second.enabled = true;
                unsettledrapidfireStar_third.enabled = true;
                unsettledrapidfireStar_fourth.enabled = false;
                unsettledrapidfireStar_fifth.enabled = false;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledrapidfire < 3)
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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの活動時間レベルを3にする
                                    GameController.Instance.rapidfireLevel = 3;

                                    minimumunununsettledrapidfire = 3;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の活動時間のレベル4の強化選択状態
            if (ununsettledrapidfire == 4)
            {
                unsettledrapidfireStar_first.enabled = true;
                unsettledrapidfireStar_second.enabled = true;
                unsettledrapidfireStar_third.enabled = true;
                unsettledrapidfireStar_fourth.enabled = true;
                unsettledrapidfireStar_fifth.enabled = false;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledrapidfire < 4)
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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの活動時間レベルを4にする
                                    GameController.Instance.rapidfireLevel = 4;

                                    minimumunununsettledrapidfire = 4;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            //未確定の活動時間のレベル5の強化選択状態
            if (ununsettledrapidfire == 5)
            {
                unsettledrapidfireStar_first.enabled = true;
                unsettledrapidfireStar_second.enabled = true;
                unsettledrapidfireStar_third.enabled = true;
                unsettledrapidfireStar_fourth.enabled = true;
                unsettledrapidfireStar_fifth.enabled = true;

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledrapidfire < 5)
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

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        //強化するか選択するウインドウを表示
                        strengtheningQuestion.SetActive(true);
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
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                if (GameController.Instance.score >= consumptionPoint)
                                {
                                    //ゲームコントローラーの活動時間レベルを5にする
                                    GameController.Instance.rapidfireLevel = 5;

                                    minimumunununsettledrapidfire = 5;

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

                                    shortagePointImage.SetActive(true);

                                    //No選択時の音
                                    audioSource.PlayOneShot(sound[3]);
                                }
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.white;
                            if (Input.GetKeyDown(KeyCode.Return))
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
            }
        }

        //出撃選択中
        if (selectNumber == 5)
        {
            //選択中の画像表示
            selectedIntimacyImage.enabled = false;
            selectedHpImage.enabled = false;
            selectedActivityTimeImage.enabled = false;
            selectedAttackImage.enabled = false;
            selectedRapidfireImage.enabled = false;
            sortieImage.color = Color.white;

            //Bボタン、もしくはエンターキーで出撃
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
            {
                SceneManager.LoadScene("Stage1");
            }
        }

        //親愛度の星表示
        for(int i = 0; i < GameController.Instance.intimacyLevel; i++)
        {
            intimacyStar[i].enabled = true;
        }

        //親愛度を選択していないときに未確定の星の画像を非表示
        if (selectNumber != 0)
        {
            ununsettledIntimacy = minimumUnunsettledIntimacy;

            unsettledintimacyStar_first.enabled = false;
            unsettledintimacyStar_second.enabled = false;
            unsettledintimacyStar_third.enabled = false;
            unsettledintimacyStar_fourth.enabled = false;
            unsettledintimacyStar_fifth.enabled = false;
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

            unsettledhpStar_first.enabled = false;
            unsettledhpStar_second.enabled = false;
            unsettledhpStar_third.enabled = false;
            unsettledhpStar_fourth.enabled = false;
            unsettledhpStar_fifth.enabled = false;
        }

        //活動時間の星表示
        for (int i = 0; i < GameController.Instance.activityTimeLevel; i++)
        {
            activityTimeStar[i].enabled = true;
        }

        //活動時間を選択していないときに未確定の星の画像を非表示
        if (selectNumber != 2)
        {
           　 ununsettledactivityTime = minimumunununsettledactivityTime;

            unsettledactivityTimeStar_first.enabled = false;
            unsettledactivityTimeStar_second.enabled = false;
            unsettledactivityTimeStar_third.enabled = false;
            unsettledactivityTimeStar_fourth.enabled = false;
            unsettledactivityTimeStar_fifth.enabled = false;
        }

        //攻撃の星表示
        for (int i = 0; i < GameController.Instance.attackLevel; i++)
        {
            attackStar[i].enabled = true;
        }

        //攻撃を選択していないときに未確定の星の画像を非表示
        if (selectNumber != 3)
        {
            ununsettledattack = minimumunununsettledattack;

            unsettledattackStar_first.enabled = false;
            unsettledattackStar_second.enabled = false;
            unsettledattackStar_third.enabled = false;
            unsettledattackStar_fourth.enabled = false;
            unsettledattackStar_fifth.enabled = false;
        }

        //連射速度の星表示
        for (int i = 0; i < GameController.Instance.rapidfireLevel; i++)
        {
            rapidfireStar[i].enabled = true;
        }

        //連射速度を選択していないときに未確定の星の画像を非表示
        if (selectNumber != 4)
        {
            ununsettledrapidfire = minimumunununsettledrapidfire;

            unsettledrapidfireStar_first.enabled = false;
            unsettledrapidfireStar_second.enabled = false;
            unsettledrapidfireStar_third.enabled = false;
            unsettledrapidfireStar_fourth.enabled = false;
            unsettledrapidfireStar_fifth.enabled = false;
        }
    }
}

