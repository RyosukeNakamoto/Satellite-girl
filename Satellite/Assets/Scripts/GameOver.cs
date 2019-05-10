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

    // Start is called before the first frame update
    void Start()
    {
        // オーディオのコンポーネント
        audioSource = GetComponent<AudioSource>();

        selectImage[0].color = Color.gray;
        selectImage[1].color = Color.gray;

        GameController.Instance.scoreText = 0;
        GameController.Instance.HpGet = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームを止める
        Time.timeScale = 0.0f;

        //Scene loadscene = SceneManager.GetActiveScene();

        //十字キー縦の入力
        float dph = Input.GetAxis("D_Pad_H");

        
        if (Input.GetKeyDown(KeyCode.UpArrow)|| dph > 0)
        {
            selectNumber = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)|| dph < 0)
        {
            selectNumber = 2;
        }
        //やり直す選択中
        if (selectNumber == 1)
        {
            selectImage[0].color = Color.white;
            //エンターキーでキャラクター選択画面に遷移
            if (Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown("joystick button 1"))
            {
                SceneManager.LoadScene("CharacterSelect");
                // ゲームの時間を戻す
                Time.timeScale = 1.0f;
            }
        }
        else
        {
            selectImage[0].color = Color.gray;
        }

        //マップ選択に戻る選択中
        if (selectNumber == 2)
        {
            selectImage[1].color = Color.white;
            //エンターキーでステージセレクト画面に遷移
            if (Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown("joystick button 1"))
            {
                SceneManager.LoadScene("Stageselect");
                // ゲームの時間を戻す
                Time.timeScale = 1.0f;
            }
        }
        else
        {
            selectImage[1].color = Color.gray;
        }
    }
}
