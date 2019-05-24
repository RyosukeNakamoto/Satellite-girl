using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public GameObject pauseImage;
    // サウンドを指定
    public AudioClip[] sound;
    // サウンドの変数
    AudioSource audioSource;

    //選択画像を指定
    public Image[] selectImage;
    //選択を数値で管理
    int selectNumber = 0;

    bool selectedRestartSound = false;
    bool selectedStageSelectSound = false;

    float count;

    //連打制御
    bool inputControl = false;

    // Start is called before the first frame update
    void Start()
    {
        // オーディオのコンポーネント
        audioSource = GetComponent<AudioSource>();
        pauseImage.SetActive(false);

        selectImage[0].color = Color.gray;
        selectImage[1].color = Color.gray;

        count=0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
        {
            // サウンドの再生
            audioSource.PlayOneShot(sound[0]);
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.0f;
                pauseImage.SetActive(true);
            }
            else if (Time.timeScale == 0.0f)
            {
                Time.timeScale = 1.0f;
                pauseImage.SetActive(false);
            }
        }

        if (pauseImage.activeSelf)
        {
            //連打でのシーン遷移制御を解除
            count += Time.unscaledDeltaTime;
            if (count > 1.5f)
            {
                inputControl = true;
            }

            //十字キー縦の入力
            float dph = Input.GetAxis("D_Pad_H");
            //スティックキー縦の入力
            float y = Input.GetAxis("Vertical");

            //上下で選択処理
            if (Input.GetKeyDown(KeyCode.UpArrow) || dph > 0 || y > 0)
            {
                selectNumber = 0;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || dph < 0 || y < 0)
            {
                selectNumber = 1;
            }

            //再開選択中
            if (selectNumber == 0)
            {
                selectImage[0].color = Color.white;

                //「マップ」選択音連続再生されないように設定
                selectedStageSelectSound = false;

                //音の連続再生制御判定
                if (selectedRestartSound == false)
                {
                    //音の再生
                    audioSource.PlayOneShot(sound[1]);
                }
                //音の連続再生されないように設定
                selectedRestartSound = true;


                if (inputControl == true)
                {
                    //再開
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //音の再生
                        audioSource.PlayOneShot(sound[2]);

                        pauseImage.SetActive(false);

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

                //再開選択音連続再生されないように設定
                selectedRestartSound = false;
                //音の連続再生制御判定
                if (selectedStageSelectSound == false)
                {
                    //音の再生
                    audioSource.PlayOneShot(sound[1]);
                }
                //音の連続再生されないように設定
                selectedStageSelectSound = true;

                if (inputControl == true)
                {
                    //エンターキーでステージセレクト画面に遷移
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                    {
                        //音の再生
                        audioSource.PlayOneShot(sound[2]);

                        pauseImage.SetActive(false);

                        SceneManager.LoadScene("Stageselect");
                        GameController.Instance.scoreText = 0;
                        GameController.Instance.hpGet = 1;
                        GameController.Instance.buffGaugeValue = 0;
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
}