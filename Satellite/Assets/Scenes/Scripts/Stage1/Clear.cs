using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
    // サウンドを指定
    public AudioClip[] sound;
    // サウンドの変数
    AudioSource audioSource;

    public Image[] selectImage;

    int selectNumber = 0;

    bool dphInput = false;

    // Start is called before the first frame update
    void Start()
    {
        // オーディオのコンポーネント
        audioSource = GetComponent<AudioSource>();

        for(int i = 0; i < 3; i++)
        {
            selectImage[i].color = Color.gray;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームを止める
        Time.timeScale = 0.0f;
        Scene loadscene = SceneManager.GetActiveScene();

        //十字キー縦の入力
        float dph = Input.GetAxis("D_Pad_H");

        if (dph == 0)
        {
            dphInput = false;
        }

        if (dphInput == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || dph > 0)
            {
                selectNumber--;
                dphInput = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || dph < 0)
            {
                selectNumber++;
                dphInput = true;
            }
        }

        if (selectNumber > 3)
        {
            selectNumber = 1;
        }
        if (selectNumber < 1)
        {
            selectNumber = 3;
        }

        //もう一回選択中
        if (selectNumber == 1)
        {
            //選択中画像の色を白に
            selectImage[0].color = Color.white;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("CharacterSelect");
            }
        }
        else
        {
            selectImage[0].color = Color.gray;
        }

        //次選択中
        if (selectNumber == 2)
        {
            //選択中画像の色を白に
            selectImage[1].color = Color.white;

            //エンターキーを押したときの処理
            if (Input.GetKeyDown(KeyCode.Return))
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
                    case 3:
                        GameController.Instance.stage = 4;
                        break;
                    case 4:
                        GameController.Instance.stage = 5;
                        break;
                    case 5:
                        GameController.Instance.stage = 6;
                        break;
                    case 6:
                        GameController.Instance.stage = 7;
                        break;
                    case 7:
                        GameController.Instance.stage = 8;
                        break;
                    case 8:
                        GameController.Instance.stage = 9;
                        break;
                    case 9:
                        GameController.Instance.stage = 10;
                        break;
                    case 10:
                        GameController.Instance.stage = 11;
                        break;
                    case 11:
                        GameController.Instance.stage = 12;
                        break;
                }

                //キャラクター選択画面に遷移
                SceneManager.LoadScene("CharacterSelect");
            }
        }
        else
        {
            selectImage[1].color = Color.gray;
        }

        //マップ選択中
        if (selectNumber == 3)
        {
            //選択中画像の色を白に
            selectImage[2].color = Color.white;

            //エンターキーでステージセレクト画面に遷移
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("StageSelect");
            }
        }
        else
        {
            selectImage[2].color = Color.gray;
        }

        /*
        if (this)
        {
            //クリア表示後に、エンターキーでステージ選択画面に遷移
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("StageSelect");
                // ゲームの時間を戻す
                Time.timeScale = 1.0f;
            }

            //クリア表示後に、スペースキーでもう一回
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(loadscene.name);
                // ゲームの時間を戻す
                Time.timeScale = 1.0f;
            }
        }
        */
    }
}
