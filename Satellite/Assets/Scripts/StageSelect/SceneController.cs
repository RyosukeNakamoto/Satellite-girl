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

        //ステージの画像
        public Image[] stage1;
        public Image[] stage2;
        public Image[] stage3;

        public GameObject[] stageCircle;

        //選んだステージのテキスト
        public Text[] stageImageText;

        //音
        AudioSource audioSource;
        public AudioClip[] sound;

        //どこを選択中か数値で管理
        int selectNumber = 0;
        int stageHalf = 0;

        bool keyInput = false;
        bool stageChangeOff = false;
        bool xInput = false;

        [SerializeField] GameObject fadeOut;

        IEnumerator FadeOut()
        {
            stageChangeOff = false;
            fadeOut.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("CharacterSelect");
        }

        // Start is called before the first frame update
        void Start()
        {
            //音コンポーネントの取得
            audioSource = GetComponent<AudioSource>();

            //シーン開始時に選択中のステージテキストを非表示
            for (int i = 0; i < 3; i++)
            {
                stageImageText[i].enabled = false;
            }


        }

        // Update is called once per frame
        void Update()
        {
            //十字キーの横の入力
            float dpv = Input.GetAxis("D_Pad_V");

            //スティックキーの横の入力
            float x = Input.GetAxis("Horizontal");

            if (dpv == 0)
            {
                keyInput = false;
            }

            //スティックキーの連続入力制御判定
            if (x == 0)
            {
                //スティックキーの横入力をできるように
                xInput = false;
            }

            if (stageChangeOff == false && keyInput == false && xInput == false)
            {
                //右矢印キーを押したときSelectNumberを増やす
                if (Input.GetKeyDown(KeyCode.RightArrow) || dpv > 0 || x > 0)
                {
                    selectNumber++;

                    keyInput = true;
                    xInput = true;

                    //カーソル移動したとき音再生
                    audioSource.PlayOneShot(sound[0]);
                }
                //左矢印キーを押したときSelectNumberを減らす
                if (Input.GetKeyDown(KeyCode.LeftArrow) || dpv < 0 || x < 0)
                {
                    selectNumber--;

                    keyInput = true;
                    xInput = true;

                    //カーソル移動したとき音再生
                    audioSource.PlayOneShot(sound[0]);
                }
                //SelectNumberが2を越えた時0に戻す処理
                if (selectNumber > 2)
                {
                    selectNumber = 0;
                }
                //SelectNumberが0を下回った時2にする処理
                if (selectNumber < 0)
                {
                    selectNumber = 2;
                }
               
            }

            //Stage1を選択状態
            if (selectNumber == 0)
            {
                //ステージ選択イメージの切り替え
                stage1[0].enabled = false;
                stage1[1].enabled = true;
                stage1[2].enabled = true;

                //選択中に円の画像を回転
                stage1[2].transform.Rotate(0, 0, 3);

                //ステージ選択表示をステージ1に切り替え
                stageImageText[0].enabled = true;

                //エンターキーを押したときキャラクター選択画面に遷移
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //決定時の音再生
                    audioSource.PlayOneShot(sound[1]);

                    //ゲームコントローラーにステージ1を選んだ情報を渡す
                    GameController.Instance.stage = 0;

                    stageChangeOff = true;

                    //一秒後にシーン遷移
                    //Invoke("MoveScene", 2.f);
                    StartCoroutine(FadeOut());
                }
            }
            //Stage1を非選択状態
            else
            {
                stage1[0].enabled = true;
                stage1[1].enabled = false;
                stage1[2].enabled = false;

                //ステージ選択表示を非表示
                stageImageText[0].enabled = false;
            }
            //Stage2を選択状態
            if (selectNumber == 1)
            {
                stage2[0].enabled = false;
                stage2[1].enabled = true;
                stage2[2].enabled = true;

                //選択中に円の画像を回転
                stage2[2].transform.Rotate(0, 0, 3);

                //ステージ選択表示をステージ2に切り替え
                stageImageText[1].enabled = true;

                //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //決定時の音再生
                    audioSource.PlayOneShot(sound[1]);

                    //ゲームコントローラーにステージ2を選んだ情報を渡す
                    GameController.Instance.stage = 1;

                    stageChangeOff = true;

                    //一秒後にシーン遷移
                    //Invoke("MoveScene", 2.0f);
                    StartCoroutine(FadeOut());
                }
            }
            //Stage2を選択状態
            else
            {
                stage2[0].enabled = true;
                stage2[1].enabled = false;
                stage2[2].enabled = false;

                //ステージ選択表示を非表示
                stageImageText[1].enabled = false;
            }
            //Stage3を選択状態
            if (selectNumber == 2)
            {
                stage3[0].enabled = false;
                stage3[1].enabled = true;
                stage3[2].enabled = true;

                //選択中に円の画像を回転
                stage3[2].transform.Rotate(0, 0, 3);

                //ステージ選択表示をステージ3に切り替え
                stageImageText[2].enabled = true;

                //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //決定時の音再生
                    audioSource.PlayOneShot(sound[1]);

                    //ゲームコントローラーにステージ3を選んだ情報を渡す
                    GameController.Instance.stage = 2;

                    stageChangeOff = true;

                    //一秒後にシーン遷移
                    //Invoke("MoveScene", 2.0f);
                    StartCoroutine(FadeOut());
                }
            }
            //Stage3を非選択状態
            else
            {
                stage3[0].enabled = true;
                stage3[1].enabled = false;
                stage3[2].enabled = false;

                //ステージ選択表示を非表示
                stageImageText[2].enabled = false;
            }
            /*
            //Stage4を選択状態
            if (selectNumber == 3)
            {
                stage4[0].enabled = false;
                stage4[1].enabled = true;

                //ステージ選択表示をステージ3に切り替え
                stageImageText[3].enabled = true;

                //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //決定時の音再生
                    audioSource.PlayOneShot(sound[1]);

                    //ゲームコントローラーにステージ4を選んだ情報を渡す
                    GameController.Instance.stage = 3;

                    stageChangeOff = true;

                    //一秒後にシーン遷移
                    Invoke("MoveScene", 0.5f);
                }
            }

            //Stage4を非選択状態
            else
            {
                stage4[0].enabled = true;
                stage4[1].enabled = false;

                //ステージ選択表示を非表示
                stageImageText[3].enabled = false;
            }
            //Stage5を選択状態
            if (selectNumber == 4)
            {
                stage5[0].enabled = false;
                stage5[1].enabled = true;

                //ステージ選択表示をステージ5に切り替え
                stageImageText[4].enabled = true;

                //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //決定時の音再生
                    audioSource.PlayOneShot(sound[1]);

                    //ゲームコントローラーにステージ5を選んだ情報を渡す
                    GameController.Instance.stage = 4;

                    stageChangeOff = true;

                    //一秒後にシーン遷移
                    Invoke("MoveScene", 0.5f);
                }
            }
            //Stage5を非選択状態
            else
            {
                stage5[0].enabled = true;
                stage5[1].enabled = false;

                //ステージ選択表示を非表示
                stageImageText[4].enabled = false;
            }
            //Stage6を選択状態
            if (selectNumber == 5)
            {
                stage6[0].enabled = false;
                stage6[1].enabled = true;

                //ステージ選択表示をステージ6に切り替え
                stageImageText[5].enabled = true;

                //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //決定時の音再生
                    audioSource.PlayOneShot(sound[1]);

                    //ゲームコントローラーにステージ6を選んだ情報を渡す
                    GameController.Instance.stage = 5;

                    stageChangeOff = true;

                    //一秒後にシーン遷移
                    Invoke("MoveScene", 0.5f);
                }
            }
            //Stage6を非選択状態
            else
            {
                stage6[0].enabled = true;
                stage6[1].enabled = false;

                //ステージ選択表示を非表示
                stageImageText[5].enabled = false;
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

                //ステージ選択表示をステージ7に切り替え
                stageImageText[6].enabled = true;

                //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //決定時の音再生
                    audioSource.PlayOneShot(sound[1]);

                    //ゲームコントローラーにステージ7を選んだ情報を渡す
                    GameController.Instance.stage = 6;

                    stageChangeOff = true;

                    //一秒後にシーン遷移
                    Invoke("MoveScene", 0.5f);
                }
            }
            //Stage7を非選択状態
            else
            {
                stage7[0].enabled = true;
                stage7[1].enabled = false;

                //ステージ選択表示を非表示
                stageImageText[6].enabled = false;
            }
            //Stage8を選択状態
            if (selectNumber == 1)
            {
                stage8[0].enabled = false;
                stage8[1].enabled = true;

                //ステージ選択表示をステージ8に切り替え
                stageImageText[7].enabled = true;

                //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //決定時の音再生
                    audioSource.PlayOneShot(sound[1]);

                    //ゲームコントローラーにステージ8を選んだ情報を渡す
                    GameController.Instance.stage = 7;

                    stageChangeOff = true;

                    //一秒後にシーン遷移
                    Invoke("MoveScene", 0.5f);
                }
            }
            //Stage8を非選択状態
            else
            {
                stage8[0].enabled = true;
                stage8[1].enabled = false;

                //ステージ選択表示を非表示
                stageImageText[7].enabled = false;
            }
            //Stage9を選択状態
            if (selectNumber == 2)
            {
                stage9[0].enabled = false;
                stage9[1].enabled = true;

                //ステージ選択表示をステージ9に切り替え
                stageImageText[8].enabled = true;

                //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //決定時の音再生
                    audioSource.PlayOneShot(sound[1]);

                    //ゲームコントローラーにステージ9を選んだ情報を渡す
                    GameController.Instance.stage = 8;

                    stageChangeOff = true;

                    //一秒後にシーン遷移
                    Invoke("MoveScene", 0.5f);
                }
            }
            //Stage9を非選択状態
            else
            {
                stage9[0].enabled = true;
                stage9[1].enabled = false;

                //ステージ選択表示をステージ9に切り替え
                stageImageText[8].enabled = false;
            }

            //Stage10を選択状態
            if (selectNumber == 3)
            {
                stage10[0].enabled = false;
                stage10[1].enabled = true;

                //ステージ選択表示をステージ10に切り替え
                stageImageText[9].enabled = true;

                //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //決定時の音再生
                    audioSource.PlayOneShot(sound[1]);

                    //ゲームコントローラーにステージ10を選んだ情報を渡す
                    GameController.Instance.stage = 9;

                    stageChangeOff = true;

                    //一秒後にシーン遷移
                    Invoke("MoveScene", 0.5f);
                }
            }
            //Stage10を非選択状態
            else
            {
                stage10[0].enabled = true;
                stage10[1].enabled = false;

                //ステージ選択表示を非表示
                stageImageText[9].enabled = false;
            }
            //Stage11を選択状態
            if (selectNumber == 4)
            {
                stage11[0].enabled = false;
                stage11[1].enabled = true;

                //ステージ選択表示をステージ11に切り替え
                stageImageText[10].enabled = true;

                //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //決定時の音再生
                    audioSource.PlayOneShot(sound[1]);

                    //ゲームコントローラーにステージ11を選んだ情報を渡す
                    GameController.Instance.stage = 10;

                    stageChangeOff = true;

                    //一秒後にシーン遷移
                    Invoke("MoveScene", 0.5f);
                }
            }
            //Stage11を非選択状態
            else
            {
                stage11[0].enabled = true;
                stage11[1].enabled = false;

                //ステージ選択表示を非表示
                stageImageText[10].enabled = false;
            }
            //Stage12を選択状態
            if (selectNumber == 5)
            {
                stage12[0].enabled = false;
                stage12[1].enabled = true;

                //ステージ選択表示をステージ12に切り替え
                stageImageText[11].enabled = true;

                //エンターキーを押したときキャラクター選択画面に遷移
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //決定時の音再生
                    audioSource.PlayOneShot(sound[1]);

                    //ゲームコントローラーにステージ12を選んだ情報を渡す
                    GameController.Instance.stage = 11;

                    stageChangeOff = true;

                    //一秒後にシーン遷移
                    Invoke("MoveScene", 0.5f);
                }
            }
            //Stage12を非選択状態
            else
            {
                stage12[0].enabled = true;
                stage12[1].enabled = false;

                //ステージ選択表示を非表示
                stageImageText[11].enabled = false;
            }
        }
        */

        }

        //シーンの遷移
        public void MoveScene()
        {
            stageChangeOff = false;
            fadeOut.SetActive(true);
            SceneManager.LoadScene("CharacterSelect");
        }

    }
}
