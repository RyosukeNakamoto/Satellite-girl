using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
    // サウンドを指定
    public AudioClip[] sound;
    public AudioClip[] voice;
    // サウンドの変数
    AudioSource audioSource;

    //選択中の画像
    public Image[] selectedImage;
    //選択を数値で管理
    int selectNumber = 0;

    //十字キー縦の入力判定
    bool dphInput = false;
    bool yInput = false;

    float count;

    //連打でのシーン遷移制御
    bool inputControl=false;

    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.scoreText = 0;
        GameController.Instance.hpGet = 1;
        GameController.Instance.buffGaugeValue = 0;

        // オーディオのコンポーネント
        audioSource = GetComponent<AudioSource>();

        //ボイスの再生
        //audioSource.PlayOneShot(voice[Random.Range(0, 3)]);

        //シーン開始時に選択画像の色の変更
        for (int i = 0; i < 2; i++)
        {
            selectedImage[i].color = Color.gray;
        }

        count = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームを止める
        Time.timeScale = 0.0f;
        Scene loadscene = SceneManager.GetActiveScene();

        count += Time.unscaledDeltaTime;
        if (count > 1.5f)
        {
            inputControl = true;
        }

        //十字キー縦の入力
        float dph = Input.GetAxis("D_Pad_H");
        //スティックキーの縦の入力
        float y = Input.GetAxis("Vertical");

        //十字キーの連続入力制御判定
        if (dph == 0)
        {
            dphInput = false;
        }
        //スティックキーの連続入力制御判定
        if (y == 0)
        {
            //スティックキーの縦入力をできるように
            yInput = false;
        }

        //連続入力できないように判定
        if (dphInput == false && yInput == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || dph > 0 || y > 0)
            {
                selectNumber--;


                //音の再生
                audioSource.PlayOneShot(sound[0]);

                //連続入力の制御
                dphInput = true;
                yInput = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || dph < 0 || y < 0)
            {
                selectNumber++;

                //音の再生
                audioSource.PlayOneShot(sound[0]);

                //連続入力の制御
                dphInput = true;
                yInput = true;
            }
        }

        if (selectNumber > 2)
        {
            selectNumber = 0;
        }
        if (selectNumber < 0)
        {
            selectNumber = 2;
        }

        //もう一回選択中
        if (selectNumber == 0)
        {
            //選択中画像の色を白に
            selectedImage[0].color = Color.white;

            if (inputControl == true)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    SceneManager.LoadScene("CharacterSelect");

                    //音の再生
                    audioSource.PlayOneShot(sound[1]);

                    inputControl = false;

                    // ゲームの時間を戻す
                    Time.timeScale = 1.0f;
                }
            }
        }
        else
        {
            selectedImage[0].color = Color.gray;
        }

        //次選択中
        if (selectNumber == 1)
        {
            //選択中画像の色を白に
            selectedImage[1].color = Color.white;

            if (inputControl == true)
            {
                //エンターキーを押したときの処理
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //現在のステージによって、次で向かうステージを指定
                    switch (GameController.Instance.stage)
                    {
                        case 0:
                            GameController.Instance.stage = 1;
                            break;
                        case 1:
                            GameController.Instance.stage = 2;
                            break;
                        case 2:
                            GameController.Instance.stage = 3;
                            break;
                    }

                    //音の再生
                    audioSource.PlayOneShot(sound[1]);

                    //キャラクター選択画面に遷移
                    SceneManager.LoadScene("CharacterSelect");

                    inputControl = false;

                    // ゲームの時間を戻す
                    Time.timeScale = 1.0f;
                }
            }
        }
        else
        {
            selectedImage[1].color = Color.gray;
        }

        //マップ選択中
        if (selectNumber == 2)
        {
            //選択中画像の色を白に
            selectedImage[2].color = Color.white;

            if (inputControl == true)
            {
                //エンターキーでステージセレクト画面に遷移
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    SceneManager.LoadScene("StageSelect");

                    //音の再生
                    audioSource.PlayOneShot(sound[1]);

                    inputControl = false;

                    // ゲームの時間を戻す
                    Time.timeScale = 1.0f;
                }
            }
        }
        else
        {
            selectedImage[2].color = Color.gray;
        }
    }
}
