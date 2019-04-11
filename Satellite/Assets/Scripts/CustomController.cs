using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomController : MonoBehaviour
{
    //どこを選択中か数値で管理
    public int selectnumber = 0;

    //未確定の親愛度の星の画像の表示を数値で管理
    public int ununsettledintimacy = 0;
    public int minimumununsettledintimacy = 0;

    //未確定のHPの星の画像の表示を数値で管理
    public int ununsettledhp = 0;
    public int minimumununsettledhp = 0;

    //未確定の活動時間の星の画像の表示を数値で管理
    public int ununsettledactivityTime = 0;
    public int minimumunununsettledactivityTime = 0;

    //未確定の攻撃の星の画像の表示を数値で管理
    public int ununsettledattack = 0;
    public int minimumunununsettledattack = 0;

    //未確定の連射速度の星の画像の表示を数値で管理
    public int ununsettledrapidfire = 0;
    public int minimumunununsettledrapidfire = 0;

    //選択中表示イメージ
    public Image intimacyImage;
    public Image hpImage;
    public Image activityTimeImage;
    public Image attackImage;
    public Image rapidfireImage;
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

    //親愛度の星の画像
    public Image intimacyStar_first;
    public Image intimacyStar_second;
    public Image intimacyStar_third;
    public Image intimacyStar_fourth;
    public Image intimacyStar_fifth;

    //未確定の親愛度の星の画像
    public Image unsettledintimacyStar_first;
    public Image unsettledintimacyStar_second;
    public Image unsettledintimacyStar_third;
    public Image unsettledintimacyStar_fourth;
    public Image unsettledintimacyStar_fifth;


    //HPの星の画像
    public Image hpStar_first;
    public Image hpStar_second;
    public Image hpStar_third;
    public Image hpStar_fourth;
    public Image hpStar_fifth;

    //未確定のHPの星の画像
    public Image unsettledhpStar_first;
    public Image unsettledhpStar_second;
    public Image unsettledhpStar_third;
    public Image unsettledhpStar_fourth;
    public Image unsettledhpStar_fifth;

    //活動時間の星の画像
    public Image activityTimeStar_first;
    public Image activityTimeStar_second;
    public Image activityTimeStar_third;
    public Image activityTimeStar_fourth;
    public Image activityTimeStar_fifth;

    //未確定の活動時間の星の画像
    public Image unsettledactivityTimeStar_first;
    public Image unsettledactivityTimeStar_second;
    public Image unsettledactivityTimeStar_third;
    public Image unsettledactivityTimeStar_fourth;
    public Image unsettledactivityTimeStar_fifth;

    //攻撃の星の画像
    public Image attackStar_first;
    public Image attackStar_second;
    public Image attackStar_third;
    public Image attackStar_fourth;
    public Image attackStar_fifth;

    //未確定の攻撃の星の画像
    public Image unsettledattackStar_first;
    public Image unsettledattackStar_second;
    public Image unsettledattackStar_third;
    public Image unsettledattackStar_fourth;
    public Image unsettledattackStar_fifth;

    //連射速度の星イメージ
    public Image rapidfireStar_first;
    public Image rapidfireStar_second;
    public Image rapidfireStar_third;
    public Image rapidfireStar_fourth;
    public Image rapidfireStar_fifth;

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

    //消費ポイントのテキスト
    public Text consumptionPointText;

    // Start is called before the first frame update
    void Start()
    {
        //シーン開始時に選択イメージをグレーに
        intimacyImage.color = Color.gray;
        hpImage.color = Color.gray;
        activityTimeImage.color = Color.gray;
        attackImage.color = Color.gray;
        rapidfireImage.color = Color.gray;
        sortieImage.color = Color.gray;

        //シーン開始時に親愛度の星の画像をを非表示
        intimacyStar_first.enabled = false;
        intimacyStar_second.enabled = false;
        intimacyStar_third.enabled = false;
        intimacyStar_fourth.enabled = false;
        intimacyStar_fifth.enabled = false;

        //シーン開始時に未確定の親愛度の星の画像を非表示
        unsettledintimacyStar_first.enabled = false;
        unsettledintimacyStar_second.enabled = false;
        unsettledintimacyStar_third.enabled = false;
        unsettledintimacyStar_fourth.enabled = false;
        unsettledintimacyStar_fifth.enabled = false;

        //シーン開始時にHpの星を非表示
        hpStar_first.enabled = false;
        hpStar_second.enabled = false;
        hpStar_third.enabled = false;
        hpStar_fourth.enabled = false;
        hpStar_fifth.enabled = false;

        //シーン開始時に未確定のHpの星を非表示
        unsettledhpStar_first.enabled = false;
        unsettledhpStar_second.enabled = false;
        unsettledhpStar_third.enabled = false;
        unsettledhpStar_fourth.enabled = false;
        unsettledhpStar_fifth.enabled = false;

        //シーン開始時に活動時間の星を非表示
        activityTimeStar_first.enabled = false;
        activityTimeStar_second.enabled = false;
        activityTimeStar_third.enabled = false;
        activityTimeStar_fourth.enabled = false;
        activityTimeStar_fifth.enabled = false;

        //シーン開始時に未確定の活動時間の星を非表示
        unsettledactivityTimeStar_first.enabled = false;
        unsettledactivityTimeStar_second.enabled = false;
        unsettledactivityTimeStar_third.enabled = false;
        unsettledactivityTimeStar_fourth.enabled = false;
        unsettledactivityTimeStar_fifth.enabled = false;

        //シーン開始時に攻撃の星を非表示
        attackStar_first.enabled = false;
        attackStar_second.enabled = false;
        attackStar_third.enabled = false;
        attackStar_fourth.enabled = false;
        attackStar_fifth.enabled = false;

        //シーン開始時に未確定の攻撃の星を非表示
        unsettledattackStar_first.enabled = false;
        unsettledattackStar_second.enabled = false;
        unsettledattackStar_third.enabled = false;
        unsettledattackStar_fourth.enabled = false;
        unsettledattackStar_fifth.enabled = false;

        //シーン開始時に連射速度の星を非表示
        rapidfireStar_first.enabled = false;
        rapidfireStar_second.enabled = false;
        rapidfireStar_third.enabled = false;
        rapidfireStar_fourth.enabled = false;
        rapidfireStar_fifth.enabled = false;

        //シーン開始時に未確定の連射速度の星を非表示
        unsettledrapidfireStar_first.enabled = false;
        unsettledrapidfireStar_second.enabled = false;
        unsettledrapidfireStar_third.enabled = false;
        unsettledrapidfireStar_fourth.enabled = false;
        unsettledrapidfireStar_fifth.enabled = false;

        //シーン開始時に強化するか選択するウインドウを非表示
        strengtheningQuestion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //十字キー縦の入力
        float dph = Input.GetAxis("D_Pad_H");
        //十字キー横の入力
        float dpv = Input.GetAxis("D_Pad_V");

        //強化の確定を選択する画面が表示中にSelectnumberの数値が変更されないようにする
        if (!strengtheningQuestion.activeSelf)
        {
            //上矢印キーを押したときSelectnumberを減らす
            if (Input.GetKeyDown(KeyCode.UpArrow) || dph > 0)
            {
                selectnumber--;
            }

            //下矢印キーを押したときSelectnumberを増やす
            if (Input.GetKeyDown(KeyCode.DownArrow) || dph < 0)
            {
                selectnumber++;
            }

            //selectnumberが5を超えたときselectnumberを0にする
            if (selectnumber > 5)
            {
                selectnumber = 0;
            }
            //selectnumberが0以下になったときselectnumberを5にする
            if (selectnumber < 0)
            {
                selectnumber = 5;
            }
        }

        //強化を確定するウインドウでの選択
        if (strengtheningQuestion.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || dph > 0)
            {
                strengtheningQuestionnumber = 1;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || dph < 0)
            {
                strengtheningQuestionnumber = 2;
            }
        }

        if (strengtheningQuestionnumber == 0)
        {
            yes.color = Color.grey;
            no.color = Color.grey;
        }
        

        //親愛度選択中
        if (selectnumber == 0)
        {
            intimacyImage.color = Color.yellow;
            hpImage.color = Color.gray;
            activityTimeImage.color = Color.gray;
            attackImage.color = Color.gray;
            rapidfireImage.color = Color.gray;
            sortieImage.color = Color.gray;

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf)
            {
                //親愛度選択中に左右キーで強化するレベルを選択
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (ununsettledintimacy < 5)
                    {
                        ununsettledintimacy++;
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (ununsettledintimacy > minimumununsettledintimacy)
                    {
                        ununsettledintimacy--;
                    }
                }
            }

            if (ununsettledintimacy == 0)
            {
                unsettledintimacyStar_first.enabled = false;
            }

            //未確定の親愛度のレベル1の強化選択状態
            if (ununsettledintimacy == 1)
            {
                unsettledintimacyStar_first.enabled = true;
                unsettledintimacyStar_second.enabled = false;
                unsettledintimacyStar_third.enabled = false;
                unsettledintimacyStar_fourth.enabled = false;
                unsettledintimacyStar_fifth.enabled = false;

                //消費ポイントの表示を500に変更
                consumptionPointText.text = "500";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumununsettledintimacy < 1)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの親愛度レベルを1にする
                                GameController.Instance.intimacylevel = 1;

                                minimumununsettledintimacy = 1;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                    }
                }
            }

            //未確定の親愛度のレベル2の強化選択状態
            if (ununsettledintimacy == 2)
            {
                unsettledintimacyStar_first.enabled = true;
                unsettledintimacyStar_second.enabled = true;
                unsettledintimacyStar_third.enabled = false;
                unsettledintimacyStar_fourth.enabled = false;
                unsettledintimacyStar_fifth.enabled = false;

                //消費ポイントの表示を600に変更
                consumptionPointText.text = "600";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumununsettledintimacy < 2)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの親愛度レベルを2にする
                                GameController.Instance.intimacylevel = 2;

                                minimumununsettledintimacy = 2;

                                strengtheningQuestionnumber = 0;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                    }
                }
            }

            //未確定の親愛度レベル3の強化選択状態
            if (ununsettledintimacy == 3)
            {
                unsettledintimacyStar_first.enabled = true;
                unsettledintimacyStar_second.enabled = true;
                unsettledintimacyStar_third.enabled = true;
                unsettledintimacyStar_fourth.enabled = false;
                unsettledintimacyStar_fifth.enabled = false;

                //消費ポイントの表示を700に変更
                consumptionPointText.text = "700";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumununsettledintimacy < 3)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの親愛度レベルを3にする
                                GameController.Instance.intimacylevel = 3;

                                minimumununsettledintimacy = 3;

                                strengtheningQuestionnumber = 0;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                    }
                }
            }

            //未確定の親愛度レベル4の強化選択状態
            if (ununsettledintimacy == 4)
            {
                unsettledintimacyStar_first.enabled = true;
                unsettledintimacyStar_second.enabled = true;
                unsettledintimacyStar_third.enabled = true;
                unsettledintimacyStar_fourth.enabled = true;
                unsettledintimacyStar_fifth.enabled = false;

                //消費ポイントの表示を800に変更
                consumptionPointText.text = "800";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumununsettledintimacy < 4)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの親愛度レベルを4にする
                                GameController.Instance.intimacylevel = 4;

                                minimumununsettledintimacy = 4;

                                strengtheningQuestionnumber = 0;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                    }
                }
            }

            //未確定の親愛度レベル5の強化選択状態
            if (ununsettledintimacy == 5)
            {
                unsettledintimacyStar_first.enabled = true;
                unsettledintimacyStar_second.enabled = true;
                unsettledintimacyStar_third.enabled = true;
                unsettledintimacyStar_fourth.enabled = true;
                unsettledintimacyStar_fifth.enabled = true;

                //消費ポイントの表示を1000に変更
                consumptionPointText.text = "1000";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumununsettledintimacy < 5)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの親愛度レベルを5にする
                                GameController.Instance.intimacylevel = 5;

                                minimumununsettledintimacy = 5;

                                strengtheningQuestionnumber = 0;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                    }
                }
            }
                    
        }

        //Hp選択中
        if (selectnumber == 1)
        {
            intimacyImage.color = Color.gray;
            hpImage.color = Color.yellow;
            activityTimeImage.color = Color.gray;
            attackImage.color = Color.gray;
            rapidfireImage.color = Color.gray;
            sortieImage.color = Color.gray;

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf)
            {
                //HP選択中に左右キーで強化するレベルを選択
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (ununsettledhp < 5)
                    {
                        ununsettledhp++;
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (ununsettledhp > minimumununsettledhp)
                    {
                        ununsettledhp--;
                    }
                }
            }

            if (ununsettledintimacy == 0)
            {
                unsettledintimacyStar_second.enabled = false;
            }

            //未確定のHPのレベル1の強化選択状態
            if (ununsettledhp == 1)
            {
                unsettledhpStar_first.enabled = true;
                unsettledhpStar_second.enabled = false;
                unsettledhpStar_third.enabled = false;
                unsettledhpStar_fourth.enabled = false;
                unsettledhpStar_fifth.enabled = false;

                //消費ポイントの表示を500に変更
                consumptionPointText.text = "500";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumununsettledhp < 1)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーのHPレベルを1にする
                                GameController.Instance.hplevel = 1;

                                minimumununsettledhp = 1;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                    }
                }
            }

            //未確定のHPのレベル2の強化選択状態
            if (ununsettledhp == 2)
            {
                unsettledhpStar_first.enabled = true;
                unsettledhpStar_second.enabled = true;
                unsettledhpStar_third.enabled = false;
                unsettledhpStar_fourth.enabled = false;
                unsettledhpStar_fifth.enabled = false;

                //消費ポイントの表示を600に変更
                consumptionPointText.text = "600";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumununsettledhp < 2)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーのHPレベルを2にする
                                GameController.Instance.hplevel = 2;

                                minimumununsettledhp = 2;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                    }
                }
            }

            //未確定のHPのレベル3の強化選択状態
            if (ununsettledhp == 3)
            {
                unsettledhpStar_first.enabled = true;
                unsettledhpStar_second.enabled = true;
                unsettledhpStar_third.enabled = true;
                unsettledhpStar_fourth.enabled = false;
                unsettledhpStar_fifth.enabled = false;

                //消費ポイントの表示を700に変更
                consumptionPointText.text = "700";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumununsettledhp < 3)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーのHPレベルを3にする
                                GameController.Instance.hplevel = 3;

                                minimumununsettledhp = 3;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                    }
                }
            }

            //未確定のHPのレベル4の強化選択状態
            if (ununsettledhp == 4)
            {
                unsettledhpStar_first.enabled = true;
                unsettledhpStar_second.enabled = true;
                unsettledhpStar_third.enabled = true;
                unsettledhpStar_fourth.enabled = true;
                unsettledhpStar_fifth.enabled = false;

                //消費ポイントの表示を800に変更
                consumptionPointText.text = "800";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumununsettledhp < 4)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーのHPレベルを4にする
                                GameController.Instance.hplevel = 4;

                                minimumununsettledhp = 4;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                    }
                }
            }

            //未確定のHPのレベル5の強化選択状態
            if (ununsettledhp == 5)
            {
                unsettledhpStar_first.enabled = true;
                unsettledhpStar_second.enabled = true;
                unsettledhpStar_third.enabled = true;
                unsettledhpStar_fourth.enabled = true;
                unsettledhpStar_fifth.enabled = true;

                //消費ポイントの表示を1000に変更
                consumptionPointText.text = "1000";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumununsettledhp < 5)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーのHPレベルを5にする
                                GameController.Instance.hplevel = 5;

                                minimumununsettledhp = 5;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                    }
                }
            }
        }

        //活動時間選択中
        if (selectnumber == 2)
        {
            intimacyImage.color = Color.gray;
            hpImage.color = Color.gray;
            activityTimeImage.color = Color.yellow;
            attackImage.color = Color.gray;
            rapidfireImage.color = Color.gray;
            sortieImage.color = Color.gray;

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf)
            {
                //HP選択中に左右キーで強化するレベルを選択
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (ununsettledactivityTime < 5)
                    {
                        ununsettledactivityTime++;
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (ununsettledactivityTime > minimumunununsettledactivityTime)
                    {
                        ununsettledactivityTime--;
                    }
                }
            }

            if (ununsettledactivityTime == 0)
            {
                unsettledactivityTimeStar_second.enabled = false;
            }

            //未確定の活動時間のレベル1の強化選択状態
            if (ununsettledactivityTime == 1)
            {
                unsettledactivityTimeStar_first.enabled = true;
                unsettledactivityTimeStar_second.enabled = false;
                unsettledactivityTimeStar_third.enabled = false;
                unsettledactivityTimeStar_fourth.enabled = false;
                unsettledactivityTimeStar_fifth.enabled = false;

                //消費ポイントの表示を500に変更
                consumptionPointText.text = "500";

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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの活動時間レベルを1にする
                                GameController.Instance.activityTimelevel = 1;

                                minimumunununsettledactivityTime = 1;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
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

                //消費ポイントの表示を600に変更
                consumptionPointText.text = "600";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledactivityTime < 2)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの活動時間レベルを2にする
                                GameController.Instance.activityTimelevel = 2;

                                minimumunununsettledactivityTime = 2;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
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

                //消費ポイントの表示を700に変更
                consumptionPointText.text = "700";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledactivityTime < 3)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの活動時間レベルを3にする
                                GameController.Instance.activityTimelevel = 3;

                                minimumunununsettledactivityTime = 3;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
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

                //消費ポイントの表示を800に変更
                consumptionPointText.text = "800";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledactivityTime < 4)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの活動時間レベルを4にする
                                GameController.Instance.activityTimelevel = 4;

                                minimumunununsettledactivityTime = 4;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
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

                //消費ポイントの表示を1000に変更
                consumptionPointText.text = "1000";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledactivityTime < 5)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの活動時間レベルを5にする
                                GameController.Instance.activityTimelevel = 5;

                                minimumunununsettledactivityTime = 5;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                    }
                }
            }
        }

        //攻撃選択中
        if (selectnumber == 3)
        {
            intimacyImage.color = Color.gray;
            hpImage.color = Color.gray;
            activityTimeImage.color = Color.gray;
            attackImage.color = Color.yellow;
            rapidfireImage.color = Color.gray;
            sortieImage.color = Color.gray;

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf)
            {
                //HP選択中に左右キーで強化するレベルを選択
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (ununsettledattack < 5)
                    {
                        ununsettledattack++;
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (ununsettledattack > minimumunununsettledattack)
                    {
                        ununsettledattack--;
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

                //消費ポイントの表示を500に変更
                consumptionPointText.text = "500";

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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの攻撃レベルを1にする
                                GameController.Instance.attacklevel = 1;

                                minimumunununsettledattack = 1;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
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

                //消費ポイントの表示を600に変更
                consumptionPointText.text = "600";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledattack < 2)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの攻撃レベルを2にする
                                GameController.Instance.attacklevel = 2;

                                minimumunununsettledattack = 2;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
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

                //消費ポイントの表示を700に変更
                consumptionPointText.text = "700";

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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの攻撃レベルを3にする
                                GameController.Instance.attacklevel = 3;

                                minimumunununsettledattack = 3;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
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

                //消費ポイントの表示を800に変更
                consumptionPointText.text = "800";

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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの攻撃レベルを4にする
                                GameController.Instance.attacklevel = 4;

                                minimumunununsettledattack = 4;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
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

                //消費ポイントの表示を1000に変更
                consumptionPointText.text = "1000";

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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの攻撃レベルを5にする
                                GameController.Instance.attacklevel = 5;

                                minimumunununsettledattack = 5;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                    }
                }
            }
        }

        //連射速度選択中
        if (selectnumber == 4)
        {
            intimacyImage.color = Color.gray;
            hpImage.color = Color.gray;
            activityTimeImage.color = Color.gray;
            attackImage.color = Color.gray;
            rapidfireImage.color = Color.yellow;
            sortieImage.color = Color.gray;

            //未確定の星を選択してない時は消費ポイントを0表示
            consumptionPointText.text = "0";

            //強化するか尋ねるウインドウが非表示の時に処理
            if (!strengtheningQuestion.activeSelf)
            {
                //連射速度選択中に左右キーで強化するレベルを選択
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (ununsettledrapidfire < 5)
                    {
                        ununsettledrapidfire++;
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (ununsettledrapidfire > minimumunununsettledrapidfire)
                    {
                        ununsettledrapidfire--;
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

                //消費ポイントの表示を500に変更
                consumptionPointText.text = "500";

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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの活動時間レベルを1にする
                                GameController.Instance.rapidfirelevel = 1;

                                minimumunununsettledrapidfire = 1;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
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

                //消費ポイントの表示を600に変更
                consumptionPointText.text = "600";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledrapidfire < 2)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの活動時間レベルを2にする
                                GameController.Instance.rapidfirelevel = 2;

                                minimumunununsettledrapidfire = 2;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
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

                //消費ポイントの表示を700に変更
                consumptionPointText.text = "700";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledrapidfire < 3)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの活動時間レベルを3にする
                                GameController.Instance.rapidfirelevel = 3;

                                minimumunununsettledrapidfire = 3;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
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

                //消費ポイントの表示を800に変更
                consumptionPointText.text = "800";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledrapidfire < 4)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの活動時間レベルを4にする
                                GameController.Instance.rapidfirelevel = 4;

                                minimumunununsettledrapidfire = 4;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
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

                //消費ポイントの表示を1000に変更
                consumptionPointText.text = "1000";

                //現在のレベルが超えていたら強化するか選択するウインドウを表示しない
                if (minimumunununsettledrapidfire < 5)
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
                            yes.color = Color.yellow;
                            no.color = Color.gray;
                            //強化をするか選択
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //ゲームコントローラーの活動時間レベルを5にする
                                GameController.Instance.rapidfirelevel = 5;

                                minimumunununsettledrapidfire = 5;

                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                        //No選択状態
                        if (strengtheningQuestionnumber == 2)
                        {
                            yes.color = Color.gray;
                            no.color = Color.yellow;
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                //強化するか尋ねるウインドウを非表示
                                strengtheningQuestion.SetActive(false);

                                strengtheningQuestionnumber = 0;
                            }
                        }

                    }
                }
            }
        }

        //出撃選択中
        if (selectnumber == 5)
        {
            intimacyImage.color = Color.gray;
            hpImage.color = Color.gray;
            activityTimeImage.color = Color.gray;
            attackImage.color = Color.gray;
            rapidfireImage.color = Color.gray;
            sortieImage.color = Color.yellow;

            //Bボタン、もしくはエンターキーで出撃
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
            {
                SceneManager.LoadScene("Stage1");
            }
        }

        //親愛度レベル1
        if (GameController.Instance.intimacylevel >= 1)
        {
            //星を表示
            intimacyStar_first.enabled = true;

            //親愛度レベル2
            if (GameController.Instance.intimacylevel >= 2)
            {
                //星を表示
                intimacyStar_second.enabled = true;

                //親愛度レベル3
                if (GameController.Instance.intimacylevel >= 3)
                {
                    //星を表示
                    intimacyStar_third.enabled = true;

                    //親愛度レベル4
                    if (GameController.Instance.intimacylevel >= 4)
                    {
                        //星を表示
                        intimacyStar_fourth.enabled = true;

                        //親愛度レベル5
                        if (GameController.Instance.intimacylevel >= 5)
                        {
                            //星を表示
                            intimacyStar_fifth.enabled = true;
                        }
                    }
                }
            }
        }

        //親愛度を選択していないときに未確定の星の画像を非表示
        if (selectnumber != 0)
        {
            ununsettledintimacy = minimumununsettledintimacy;

            unsettledintimacyStar_first.enabled = false;
            unsettledintimacyStar_second.enabled = false;
            unsettledintimacyStar_third.enabled = false;
            unsettledintimacyStar_fourth.enabled = false;
            unsettledintimacyStar_fifth.enabled = false;
        }

        //Hpレベル1
        if (GameController.Instance.hplevel >= 1)
        {
            //星を表示
            hpStar_first.enabled = true;

            //Hpレベル2
            if (GameController.Instance.hplevel >= 2)
            {
                //星を表示
                hpStar_second.enabled = true;

                //Hpレベル3
                if (GameController.Instance.hplevel >= 3)
                {
                    //星を表示
                    hpStar_third.enabled = true;

                    //Hpレベル4
                    if (GameController.Instance.hplevel >= 4)
                    {
                        //星を表示
                        hpStar_fourth.enabled = true;

                        //Hpレベル5
                        if (GameController.Instance.hplevel >= 5)
                        {
                            //星を表示
                            hpStar_fifth.enabled = true;
                        }
                    }
                }
            }
        }

        //HPを選択していないときに未確定の星の画像を非表示
        if (selectnumber != 1)
        {
            ununsettledhp = minimumununsettledhp;

            unsettledhpStar_first.enabled = false;
            unsettledhpStar_second.enabled = false;
            unsettledhpStar_third.enabled = false;
            unsettledhpStar_fourth.enabled = false;
            unsettledhpStar_fifth.enabled = false;
        }

        //活動時間レベル1
        if (GameController.Instance.activityTimelevel >= 1)
        {
            //星を表示
            activityTimeStar_first.enabled = true;

            //活動時間レベル2
            if (GameController.Instance.activityTimelevel >= 2)
            {
                //星を表示
                activityTimeStar_second.enabled = true;

                //活動時間レベル3
                if (GameController.Instance.activityTimelevel >= 3)
                {
                    //星を表示
                    activityTimeStar_third.enabled = true;

                    //活動時間レベル4
                    if (GameController.Instance.activityTimelevel >= 4)
                    {
                        //星を表示
                        activityTimeStar_fourth.enabled = true;

                        //活動時間レベル5
                        if (GameController.Instance.activityTimelevel >= 5)
                        {
                            //星を表示
                            activityTimeStar_fifth.enabled = true;
                        }
                    }
                }
            }
        }

        //活動時間を選択していないときに未確定の星の画像を非表示
        if (selectnumber != 2)
        {
           　 ununsettledactivityTime = minimumunununsettledactivityTime;

            unsettledactivityTimeStar_first.enabled = false;
            unsettledactivityTimeStar_second.enabled = false;
            unsettledactivityTimeStar_third.enabled = false;
            unsettledactivityTimeStar_fourth.enabled = false;
            unsettledactivityTimeStar_fifth.enabled = false;
        }

        //攻撃レベル1
        if (GameController.Instance.attacklevel >= 1)
        {
            //星を表示
            attackStar_first.enabled = true;

            //攻撃レベル2
            if (GameController.Instance.attacklevel >= 2)
            {
                //星を表示
                attackStar_second.enabled = true;

                //攻撃レベル3
                if (GameController.Instance.attacklevel >= 3)
                {
                    //星を表示
                    attackStar_third.enabled = true;

                    //攻撃レベル4
                    if (GameController.Instance.attacklevel >= 4)
                    {
                        //星を表示
                        attackStar_fourth.enabled = true;

                        //攻撃レベル5
                        if (GameController.Instance.attacklevel >= 5)
                        {
                            //星を表示
                            attackStar_fifth.enabled = true;
                        }
                    }
                }
            }
        }

        //攻撃を選択していないときに未確定の星の画像を非表示
        if (selectnumber != 3)
        {
            ununsettledattack = minimumunununsettledattack;

            unsettledattackStar_first.enabled = false;
            unsettledattackStar_second.enabled = false;
            unsettledattackStar_third.enabled = false;
            unsettledattackStar_fourth.enabled = false;
            unsettledattackStar_fifth.enabled = false;
        }

        //連射速度レベル1
        if (GameController.Instance.rapidfirelevel >= 1)
        {
            //星を表示
            rapidfireStar_first.enabled = true;

            //連射速度レベル2
            if (GameController.Instance.rapidfirelevel >= 2)
            {
                //星を表示
                rapidfireStar_second.enabled = true;

                //連射速度レベル3
                if (GameController.Instance.rapidfirelevel >= 3)
                {
                    //星の表示
                    rapidfireStar_third.enabled = true;

                    //連射速度レベル4
                    if (GameController.Instance.rapidfirelevel >= 4)
                    {
                        //星の表示
                        rapidfireStar_fourth.enabled = true;

                        //連射速度レベル5
                        if (GameController.Instance.rapidfirelevel >= 5)
                        {
                            //星の表示
                            rapidfireStar_fifth.enabled = true;
                        }
                    }
                }
            }
        }

        //連射速度を選択していないときに未確定の星の画像を非表示
        if (selectnumber != 4)
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

