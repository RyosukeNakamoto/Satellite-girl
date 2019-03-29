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
            //十字キーの横の入力
            float dph = Input.GetAxis("D_Pad_V");

            //右矢印キーを押したときSelectnumberを増やす
            if (Input.GetKeyDown(KeyCode.RightArrow)||dph>0)
            {
                selectnumber++;
            }
            //左矢印キーを押したときSelectnumberを減らす
            if (Input.GetKeyDown(KeyCode.LeftArrow)||dph<0)
            {
                selectnumber--;
            }
            //Selectnumberが5を越えた時0に戻す処理
            if (selectnumber > 5)
            {
                selectnumber = 0;
            }
            //Selectnumberが0を下回った時5にする処理
            if (selectnumber < 0)
            {
                selectnumber = 5;
            }

            //Stage1を選択状態
            if (selectnumber == 0)
            {
                stage1.color = Color.white;
                stage2.color = Color.gray;
                stage3.color = Color.gray;
                stage4.color = Color.gray;
                stage5.color = Color.gray;
                stage6.color = Color.gray;
                back.color = Color.gray;

                //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown("joystick button 1"))
                {
                    SceneManager.LoadScene("CharacterSelect");
                }
            }
            //Stage2を選択状態
            if (selectnumber == 1)
            {
                stage1.color = Color.gray;
                stage2.color = Color.white;
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
                stage3.color = Color.white;
                stage4.color = Color.gray;
                stage5.color = Color.gray;
                stage6.color = Color.gray;
                back.color = Color.gray;
            }

            //Stage4を選択状態
            if (selectnumber == 3)
            {
                stage1.color = Color.gray;
                stage2.color = Color.gray;
                stage3.color = Color.gray;
                stage4.color = Color.white;
                stage5.color = Color.gray;
                stage6.color = Color.gray;
                back.color = Color.gray;
            }
            //Stage5を選択状態
            if (selectnumber == 4)
            {
                stage1.color = Color.gray;
                stage2.color = Color.gray;
                stage3.color = Color.gray;
                stage4.color = Color.gray;
                stage5.color = Color.white;
                stage6.color = Color.gray;
                back.color = Color.gray;
            }
            //Stage6を選択状態
            if (selectnumber == 5)
            {
                stage1.color = Color.gray;
                stage2.color = Color.gray;
                stage3.color = Color.gray;
                stage4.color = Color.gray;
                stage5.color = Color.gray;
                stage6.color = Color.white;
                back.color = Color.gray;
            }
            }

        }
    }
