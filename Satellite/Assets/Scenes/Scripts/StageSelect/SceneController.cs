using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Satellite.StageSelect
{

    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        Color selectedColor = Color.white;


        public Image[] stage1;
        public Image[] stage2;
        public Image[] stage3;
        public Image[] stage4;
        public Image[] stage5;
        public Image[] stage6;
        public Image[] stage7;
        public Image[] stage8;
        public Image[] stage9;
        public Image[] stage10;
        public Image[] stage11;
        public Image[] stage12;

        public Canvas[] stage;

        AudioSource audioSource;
        public AudioClip[] sound;

        //曲再生の判定
        bool isAudioStart = false; 
        //どこを選択中か数値で管理
        int selectNumber = 0;
        int stageHalf = 0;

        // Start is called before the first frame update
        void Start()
        {
            //音コンポーネントの取得
            audioSource = GetComponent<AudioSource>();

            stage[0].enabled = true;
            stage[1].enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            //十字キーの横の入力
            float dpv = Input.GetAxis("D_Pad_V");

            //右矢印キーを押したときSelectNumberを増やす
            if (Input.GetKeyDown(KeyCode.RightArrow) || dpv > 0)
            {
                selectNumber++;
                //カーソル移動したとき音再生
                audioSource.PlayOneShot(sound[0]);
            }
            //左矢印キーを押したときSelectNumberを減らす
            if (Input.GetKeyDown(KeyCode.LeftArrow) || dpv < 0)
            {
                selectNumber--;
                //カーソル移動したとき音再生
                audioSource.PlayOneShot(sound[0]);
            }
            //SelectNumberが5を越えた時0に戻す処理
            if (selectNumber > 5)
            {
                selectNumber = 0;
            }
            //SelectNumberが0を下回った時5にする処理
            if (selectNumber < 0)
            {
                selectNumber = 5;
            }
            //ステージの前半後半を切替
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                if (stageHalf == 0)
                {
                    stageHalf = 1;

                    audioSource.PlayOneShot(sound[0]);

                    stage[0].enabled = false;
                    stage[1].enabled = true;
                }
                else
                {
                    stageHalf = 0;

                    audioSource.PlayOneShot(sound[0]);

                    stage[0].enabled = true;
                    stage[1].enabled = false;
                }
            }

            //ステージ前半選択画面
            if (stageHalf == 0)
            {
                //Stage1を選択状態
                if (selectNumber == 0)
                {
                    stage1[0].enabled = false;
                    stage1[1].enabled = true;

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //決定時の音再生
                        audioSource.PlayOneShot(sound[1]);

                        GameController.Instance.stage = 0;

                        //キャラクター選択画面に遷移
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                else
                {
                    stage1[0].enabled = true;
                    stage1[1].enabled = false;
                }
                //Stage2を選択状態
                if (selectNumber == 1)
                {
                    stage2[0].enabled = false;
                    stage2[1].enabled = true;

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //決定時の音再生
                        audioSource.PlayOneShot(sound[1]);

                        GameController.Instance.stage = 1;

                        //キャラクター選択画面に遷移
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                else
                {
                    stage2[0].enabled = true;
                    stage2[1].enabled = false;
                }
                //Stage3を選択状態
                if (selectNumber == 2)
                {
                    stage3[0].enabled = false;
                    stage3[1].enabled = true;

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //決定時の音再生
                        audioSource.PlayOneShot(sound[1]);

                        GameController.Instance.stage = 2;

                        //キャラクター選択画面に遷移
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                else
                {
                    stage3[0].enabled = true;
                    stage3[1].enabled = false;
                }

                //Stage4を選択状態
                if (selectNumber == 3)
                {
                    stage4[0].enabled = false;
                    stage4[1].enabled = true;

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //決定時の音再生
                        audioSource.PlayOneShot(sound[1]);

                        GameController.Instance.stage = 3;

                        //キャラクター選択画面に遷移
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                else
                {
                    stage4[0].enabled = true;
                    stage4[1].enabled = false;
                }
                //Stage5を選択状態
                if (selectNumber == 4)
                {
                    stage5[0].enabled = false;
                    stage5[1].enabled = true;

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //決定時の音再生
                        audioSource.PlayOneShot(sound[1]);

                        GameController.Instance.stage = 4;

                        //キャラクター選択画面に遷移
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                else
                {
                    stage5[0].enabled = true;
                    stage5[1].enabled = false;
                }
                //Stage6を選択状態
                if (selectNumber == 5)
                {
                    stage6[0].enabled = false;
                    stage6[1].enabled = true;

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //決定時の音再生
                        audioSource.PlayOneShot(sound[1]);

                        GameController.Instance.stage = 5;

                        //キャラクター選択画面に遷移
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                else
                {
                    stage6[0].enabled = true;
                    stage6[1].enabled = false;
                }
            }

            //ステージ後半選択画面
            if (stageHalf == 1)
            {
                //Stage7を選択状態
                if (selectNumber == 0)
                {
                    stage7[0].enabled = false;
                    stage7[1].enabled = true;

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //決定時の音再生
                        audioSource.PlayOneShot(sound[1]);

                        GameController.Instance.stage = 6;

                        //キャラクター選択画面に遷移
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                else
                {
                    stage7[0].enabled = true;
                    stage7[1].enabled = false;
                }
                //Stage8を選択状態
                if (selectNumber == 1)
                {
                    stage8[0].enabled = false;
                    stage8[1].enabled = true;

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //決定時の音再生
                        audioSource.PlayOneShot(sound[1]);

                        GameController.Instance.stage = 7;

                        //キャラクター選択画面に遷移
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                else
                {
                    stage8[0].enabled = true;
                    stage8[1].enabled = false;
                }
                //Stage9を選択状態
                if (selectNumber == 2)
                {
                    stage9[0].enabled = false;
                    stage9[1].enabled = true;

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //決定時の音再生
                        audioSource.PlayOneShot(sound[1]);

                        GameController.Instance.stage = 8;

                        //キャラクター選択画面に遷移
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                else
                {
                    stage9[0].enabled = true;
                    stage9[1].enabled = false;
                }

                //Stage10を選択状態
                if (selectNumber == 3)
                {
                    stage10[0].enabled = false;
                    stage10[1].enabled = true;

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //決定時の音再生
                        audioSource.PlayOneShot(sound[1]);

                        GameController.Instance.stage = 9;

                        //キャラクター選択画面に遷移
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                else
                {
                    stage10[0].enabled = true;
                    stage10[1].enabled = false;
                }
                //Stage11を選択状態
                if (selectNumber == 4)
                {
                    stage11[0].enabled = false;
                    stage11[1].enabled = true;

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //決定時の音再生
                        audioSource.PlayOneShot(sound[1]);

                        GameController.Instance.stage = 10;

                        //キャラクター選択画面に遷移
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                else
                {
                    stage11[0].enabled = true;
                    stage11[1].enabled = false;
                }
                //Stage12を選択状態
                if (selectNumber == 5)
                {
                    stage12[0].enabled = false;
                    stage12[1].enabled = true;

                    //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //決定時の音再生
                        audioSource.PlayOneShot(sound[1]);

                        GameController.Instance.stage = 11;

                        //キャラクター選択画面に遷移
                        SceneManager.LoadScene("CharacterSelect");
                    }
                }
                else
                {
                    stage12[0].enabled = true;
                    stage12[1].enabled = false;
                }
            }
        }

        }
    }
