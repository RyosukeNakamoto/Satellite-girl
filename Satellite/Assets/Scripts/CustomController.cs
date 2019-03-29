using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomController : MonoBehaviour
{
    //どこを選択中か数値で管理
    public int selectnumber = 0;

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

    //親愛度の星のイメージ
    public Image intimacyStar_second;
    public Image intimacyStar_third;
    public Image intimacyStar_fourth;
    public Image intimacyStar_fifth;

    //HPの星イメージ
    public Image hpStar_second;
    public Image hpStar_third;
    public Image hpStar_fourth;
    public Image hpSatr_fifth;

    //活動時間の星イメージ
    public Image activityTimeStar_second;
    public Image activityTimeStar_third;
    public Image activityTimeStar_fourth;
    public Image activityTimeStar_fifth;

    //攻撃の星イメージ
    public Image attackStar_second;
    public Image attackStar_third;
    public Image attackStar_fourth;
    public Image attackStar_fifth;

    //連射速度の星イメージ
    public Image rapidfireStar_second;
    public Image rapidfireStar_third;
    public Image rapidfireStar_fourth;
    public Image rapidfireStar_fifth;

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

        //シーン開始時に親愛度の星を非表示
        intimacyStar_second.enabled = false;
        intimacyStar_third.enabled = false;
        intimacyStar_fourth.enabled = false;
        intimacyStar_fifth.enabled = false;

        //シーン開始時にHpの星を非表示
        hpStar_second.enabled = false;
        hpStar_third.enabled = false;
        hpStar_fourth.enabled = false;
        hpSatr_fifth.enabled = false;

        //シーン開始時に活動時間の星を非表示
        activityTimeStar_second.enabled = false;
        activityTimeStar_third.enabled = false;
        activityTimeStar_fourth.enabled = false;
        activityTimeStar_fifth.enabled = false;

        //シーン開始時に攻撃の星を非表示
        attackStar_second.enabled = false;
        attackStar_third.enabled = false;
        attackStar_fourth.enabled = false;
        attackStar_fifth.enabled = false;

        //シーン開始時に連射速度の星を非表示
        rapidfireStar_second.enabled = false;
        rapidfireStar_third.enabled = false;
        rapidfireStar_fourth.enabled = false;
        rapidfireStar_fifth.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //十字キー縦の入力
        float dph = Input.GetAxis("D_Pad_H");

        //上矢印キーを押したときSelectnumberを減らす
        if (Input.GetKeyDown(KeyCode.UpArrow)|| dph>0)
        {
            selectnumber--;
        }

        //下矢印キーを押したときSelectnumberを増やす
        if (Input.GetKeyDown(KeyCode.DownArrow)|| dph<0)
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

        //親愛度選択中
        if (selectnumber == 0)
        {
            intimacyImage.color = Color.yellow;
            hpImage.color = Color.gray;
            activityTimeImage.color = Color.gray;
            attackImage.color = Color.gray;
            rapidfireImage.color = Color.gray;
            sortieImage.color = Color.gray;

            //親愛度レベル5以下の時だけ強化可能
            if (GameController.Instance.intimacylevel < 4)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    GameController.Instance.intimacylevel++;
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

            //Hpレベル5以下の時だけ強化可能
            if (GameController.Instance.hplevel < 4)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    GameController.Instance.hplevel++;
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

            //活動時間レベル5以下の時だけ強化可能
            if (GameController.Instance.activityTimelevel < 4)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    GameController.Instance.activityTimelevel++;
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

            //活動時間レベル5以下の時だけ強化可能
            if ( GameController.Instance.attacklevel< 4)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    GameController.Instance.attacklevel++;
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

            //連射速度レベル5以下の時だけ強化可能
            if (GameController.Instance.rapidfirelevel < 4)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    GameController.Instance.rapidfirelevel++;
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

        //親愛度レベル2
        if (GameController.Instance.intimacylevel >= 1)
        {
            //星を表示
            intimacyStar_second.enabled = true;

            

            //親愛度レベル3
            if (GameController.Instance.intimacylevel >= 2)
            {
                //星を表示
                intimacyStar_third.enabled = true;

                //親愛度レベル4
                if (GameController.Instance.intimacylevel >= 3)
                {
                    //星を表示
                    intimacyStar_fourth.enabled = true;

                    //親愛度レベル5
                    if (GameController.Instance.intimacylevel >= 4)
                    {
                        //星を表示
                        intimacyStar_fifth.enabled = true;
                    }
                }
            }
        }

        //Hpレベル2
        if (GameController.Instance.hplevel >= 1)
        {
            //星を表示
            hpStar_second.enabled = true;

            //Hpレベル3
            if (GameController.Instance.hplevel >= 2)
            {
                //星を表示
                hpStar_third.enabled = true;

                //Hpレベル4
                if (GameController.Instance.hplevel >= 3)
                {
                    //星を表示
                    hpStar_fourth.enabled = true;

                    //Hpレベル5
                    if (GameController.Instance.hplevel >= 4)
                    {
                        //星を表示
                        hpSatr_fifth.enabled = true;
                    }
                }
            }
        }

        //活動時間レベル2
        if (GameController.Instance.activityTimelevel >= 1)
        {
            //星を表示
            activityTimeStar_second.enabled = true;

            //活動時間レベル3
            if (GameController.Instance.activityTimelevel >= 2)
            {
                //星を表示
                activityTimeStar_third.enabled = true;

                //活動時間レベル4
                if (GameController.Instance.activityTimelevel >= 3)
                {
                    //星を表示
                    activityTimeStar_fourth.enabled = true;

                    //活動時間レベル5
                    if (GameController.Instance.activityTimelevel >= 4)
                    {
                        //星を表示
                        activityTimeStar_fifth.enabled = true;
                    }
                }
            }
        }

        //攻撃レベル2
        if (GameController.Instance.attacklevel >= 1)
        {
            //星を表示
            attackStar_second.enabled = true;

            //攻撃レベル3
            if (GameController.Instance.attacklevel >= 2)
            {
                //星を表示
                attackStar_third.enabled = true;

                //攻撃レベル4
                if (GameController.Instance.attacklevel >= 3)
                {
                    //星を表示
                    attackStar_fourth.enabled = true;

                    //攻撃レベル5
                    if (GameController.Instance.attacklevel >= 4)
                    {
                        //星を表示
                        attackStar_fifth.enabled = true;
                    }
                }
            }
        }

        //連射速度レベル2
        if (GameController.Instance.rapidfirelevel >= 1)
        {
            //星を表示
            rapidfireStar_second.enabled = true;

            //連射速度レベル3
            if (GameController.Instance.rapidfirelevel >= 2)
            {
                //星の表示
                rapidfireStar_third.enabled = true;

                //連射速度レベル4
                if (GameController.Instance.rapidfirelevel >= 3)
                {
                    //星の表示
                    rapidfireStar_fourth.enabled = true;

                    //連射速度レベル5
                    if (GameController.Instance.rapidfirelevel >= 4)
                    {
                        //星の表示
                        rapidfireStar_fifth.enabled = true;
                    }
                }
            }
        }
    }
}

