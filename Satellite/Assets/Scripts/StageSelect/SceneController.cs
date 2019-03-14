using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Satellite.StageSelect
{
    public class SceneController : MonoBehaviour
    {
        public Image stage1;
        public Image stage2;
        public Image stage3;
        public Image stage4;
        public Image stage5;
        public Image stage6;
        public Image back;

        //どこを選択中か数値で管理
        int selectnumber = 0;
        int selectsecondnumber = 0;

        // Start is called before the first frame update
        void Start()
        {
            //シーン開始時に選択中の表示の非表示
            stage1.color = Color.gray;
            stage2.color = Color.gray;
            stage3.color = Color.gray;
            stage4.color = Color.gray;
            stage5.color = Color.gray;
            stage6.color = Color.gray;
            back.color = Color.gray;
        }

        // Update is called once per frame
        void Update()
        {
            //右矢印キーを押したときSelectnumberを増やす
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                selectnumber++;
            }
            //左矢印キーを押したときSelectnumberを減らす
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                selectnumber--;
            }
            //Selectnumberが2を越えた時0に戻す処理
            if (selectnumber > 2)
            {
                selectnumber = 0;
            }
            //Selectnumberが0を下回った時2にする処理
            if (selectnumber < 0)
            {
                selectnumber = 2;
            }
            //下矢印キーを押したときSelectsecondnumberを増やす処理
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selectsecondnumber++;
            }
            //上矢印キーを押したときSelectsecondnumberを減らす処理
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selectsecondnumber--;
            }
            //Selectsecondnumberが2を越えた時0に戻す処理
            if (selectsecondnumber > 2)
            {
                selectsecondnumber = 0;
            }
            //Selectsecondnumberが0を下回った時2にする処理
            if (selectsecondnumber < 0)
            {
                selectsecondnumber = 2;
            }

            //1段目を選択状態
            if (selectsecondnumber == 0)
            {
                //Stage1を選択状態
                if (selectnumber == 0)
                {
                    stage1.color = Color.yellow;
                    stage2.color = Color.gray;
                    stage3.color = Color.gray;
                    stage4.color = Color.gray;
                    stage5.color = Color.gray;
                    stage6.color = Color.gray;
                    back.color = Color.gray;

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                //Stage2を選択状態
                if (selectnumber == 1)
                {
                    stage1.color = Color.gray;
                    stage2.color = Color.yellow;
                    stage3.color = Color.gray;
                    stage4.color = Color.gray;
                    stage5.color = Color.gray;
                    stage6.color = Color.gray;
                    back.color = Color.gray;
                }
                //Stage3を選択状態
                if (selectnumber == 2)
                {
                    stage1.color = Color.gray;
                    stage2.color = Color.gray;
                    stage3.color = Color.yellow;
                    stage4.color = Color.gray;
                    stage5.color = Color.gray;
                    stage6.color = Color.gray;
                    back.color = Color.gray;
                }
            }
            //2段目を選択状態
            if (selectsecondnumber == 1)
            {
                //Stage4を選択状態
                if (selectnumber == 0)
                {
                    stage1.color = Color.gray;
                    stage2.color = Color.gray;
                    stage3.color = Color.gray;
                    stage4.color = Color.yellow;
                    stage5.color = Color.gray;
                    stage6.color = Color.gray;
                    back.color = Color.gray;
                }
                //Stage5を選択状態
                if (selectnumber == 1)
                {
                    stage1.color = Color.gray;
                    stage2.color = Color.gray;
                    stage3.color = Color.gray;
                    stage4.color = Color.gray;
                    stage5.color = Color.yellow;
                    stage6.color = Color.gray;
                    back.color = Color.gray;
                }
                //Stage6を選択状態
                if (selectnumber == 2)
                {
                    stage1.color = Color.gray;
                    stage2.color = Color.gray;
                    stage3.color = Color.gray;
                    stage4.color = Color.gray;
                    stage5.color = Color.gray;
                    stage6.color = Color.yellow;
                    back.color = Color.gray;
                }
            }

            //タイトルを選択状態
            if (selectsecondnumber == 2)
            {
                stage1.color = Color.gray;
                stage2.color = Color.gray;
                stage3.color = Color.gray;
                stage4.color = Color.gray;
                stage5.color = Color.gray;
                stage6.color = Color.gray;
                back.color = Color.yellow;

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene("Title");
                }
            }
        }
    }
}