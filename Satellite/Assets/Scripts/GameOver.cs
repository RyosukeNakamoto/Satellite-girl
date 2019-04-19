using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // サウンドを指定
    public AudioClip[] sound;
    // サウンドの変数
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // オーディオのコンポーネント
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0.0f;

        //Scene loadscene = SceneManager.GetActiveScene();

        //ゲームオーバー後、エンターキーでタイトルに戻る
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
