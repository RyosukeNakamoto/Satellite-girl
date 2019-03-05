using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Satellite.StageSelect
{
    public class SceneController : MonoBehaviour
    {
        public GameObject stage1;
        public GameObject stage2;
        public GameObject stage3;
        public GameObject stage4;
        public GameObject stage5;
        public GameObject stage6;
        public GameObject back;

        //どこを選択中か数値で管理
        int selectnumber = 0;
        int selectsecondnumber = 0;

        // Start is called before the first frame update
        void Start()
        {
            //シーン開始時に選択中の表示の非表示
            stage1.SetActive(false);
            stage2.SetActive(false);
            stage3.SetActive(false);
            stage4.SetActive(false);
            stage5.SetActive(false);
            stage6.SetActive(false);
            back.SetActive(false);
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
                    stage1.SetActive(true);
                    stage2.SetActive(false);
                    stage3.SetActive(false);
                    stage4.SetActive(false);
                    stage5.SetActive(false);
                    stage6.SetActive(false);
                    back.SetActive(false);

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                //Stage2を選択状態
                if (selectnumber == 1)
                {
                    stage1.SetActive(false);
                    stage2.SetActive(true);
                    stage3.SetActive(false);
                    stage4.SetActive(false);
                    stage5.SetActive(false);
                    stage6.SetActive(false);
                    back.SetActive(false);
                }
                //Stage3を選択状態
                if (selectnumber == 2)
                {
                    stage1.SetActive(false);
                    stage2.SetActive(false);
                    stage3.SetActive(true);
                    stage4.SetActive(false);
                    stage5.SetActive(false);
                    stage6.SetActive(false);
                    back.SetActive(false);
                }
            }
            //2段目を選択状態
            if (selectsecondnumber == 1)
            {
                //Stage4を選択状態
                if (selectnumber == 0)
                {
                    stage1.SetActive(false);
                    stage2.SetActive(false);
                    stage3.SetActive(false);
                    stage4.SetActive(true);
                    stage5.SetActive(false);
                    stage6.SetActive(false);
                    back.SetActive(false);
                }
                //Stage5を選択状態
                if (selectnumber == 1)
                {
                    stage1.SetActive(false);
                    stage2.SetActive(false);
                    stage3.SetActive(false);
                    stage4.SetActive(false);
                    stage5.SetActive(true);
                    stage6.SetActive(false);
                    back.SetActive(false);
                }
                //Stage6を選択状態
                if (selectnumber == 2)
                {
                    stage1.SetActive(false);
                    stage2.SetActive(false);
                    stage3.SetActive(false);
                    stage4.SetActive(false);
                    stage5.SetActive(false);
                    stage6.SetActive(true);
                    back.SetActive(false);
                }
            }

            //Returnを選択状態
            if (selectsecondnumber == 2)
            {
                stage1.SetActive(false);
                stage2.SetActive(false);
                stage3.SetActive(false);
                stage4.SetActive(false);
                stage5.SetActive(false);
                stage6.SetActive(false);
                back.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene("Home");
                }
            }
        }
    }
}