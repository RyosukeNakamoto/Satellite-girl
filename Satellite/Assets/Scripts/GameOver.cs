using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // サウンドを指定
    public AudioClip[] sound;
    // サウンドの変数
    AudioSource audioSource;
    //選択画像を指定
    public Image[] selectImage;
    //選択を数値で管理
    int selectNumber = 0;

    float count;

    bool selectedYesSound = false;
    bool selectedNoSound = false;

    //連打でのシーン遷移制御
    bool inputControl = false;

    // Start is called before the first frame update
    void Start()
    {
        // オーディオのコンポーネント
        audioSource = GetComponent<AudioSource>();

        selectImage[0].color = Color.gray;
        selectImage[1].color = Color.gray;

        GameController.Instance.scoreText = 0;
        GameController.Instance.HpGet = 1;

        count=0;
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームを止める
        Time.timeScale = 0.0f;

        //連打でのシーン遷移制御を解除
        count += Time.unscaledDeltaTime;
        if (count > 3)
        {
            inputControl = true;
        }

        //十字キー縦の入力
        float dph = Input.GetAxis("D_Pad_H");
        //スティックキー縦の入力
        float y= Input.GetAxis("Vertical");

        //上下で選択処理
        if (Input.GetKeyDown(KeyCode.UpArrow) || dph > 0 || y > 0)
        {
            selectNumber = 0;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || dph < 0 || y < 0)
        {
            selectNumber = 1;
        }

        //やり直す選択中
        if (selectNumber == 0)
        {
            selectImage[0].color = Color.white;

            //「いいえ」選択音連続再生されないように設定
            selectedNoSound = false;

            //音の連続再生制御判定
            if (selectedYesSound == false)
            {
                //音の再生
                audioSource.PlayOneShot(sound[0]);
            }
            //音の連続再生されないように設定
            selectedYesSound = true;


            if (inputControl == true)
            {
                //エンターキーでキャラクター選択画面に遷移
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //音の再生
                    audioSource.PlayOneShot(sound[1]);

                    SceneManager.LoadScene("CharacterSelect");
                    // ゲームの時間を戻す
                    Time.timeScale = 1.0f;
                }
            }
        }
        else
        {
            selectImage[0].color = Color.gray;
        }

        //マップ選択に戻る選択中
        if (selectNumber == 1)
        {
            selectImage[1].color = Color.white;

            //「はい」選択音連続再生されないように設定
            selectedYesSound = false;
            //音の連続再生制御判定
            if (selectedNoSound == false)
            {
                //音の再生
                audioSource.PlayOneShot(sound[0]);
            }
            //音の連続再生されないように設定
            selectedNoSound = true;

            if (inputControl == true)
            {
                //エンターキーでステージセレクト画面に遷移
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    //音の再生
                    audioSource.PlayOneShot(sound[1]);

                    SceneManager.LoadScene("Stageselect");
                    // ゲームの時間を戻す
                    Time.timeScale = 1.0f;
                }
            }
        }
        else
        {
            selectImage[1].color = Color.gray;
        }
    }
}
