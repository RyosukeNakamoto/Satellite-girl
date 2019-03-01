using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // 倒した敵の数
    int score = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //タイトル画面でエンターキーを押したときのシーン遷移
        if (SceneManager.GetActiveScene().name == "Title")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Home");
            }
        }

        //ホーム画面でキーを押したときの処理
        if (SceneManager.GetActiveScene().name == "Home")
        {
            //エンターキーを押すとステージセレクト画面へシーン遷移
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Stageselect");
            }
            //スペースキーを押したときタイトルへシーン遷移
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Title");
            }
        }

        //ステージセレクト画面でキーを押したときの処理
        if(SceneManager.GetActiveScene().name=="Stageselect")
        {
            //スペースキーを押したときホーム画面へ遷移
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Home");
            }
        }
    }
}

