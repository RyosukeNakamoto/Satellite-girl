using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenecontroller : MonoBehaviour
{
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
    }

    //タイトル画面でボタンを押したときホーム画面に遷移
    public void OnClickTitle()
    {
        SceneManager.LoadScene("Home");
    }

    //ホーム画面でボタンを押したときにステージセレクト画面に遷移
    public void OnClickHome()
    {
        SceneManager.LoadScene("Stageselect");
    }

    //ホーム画面でボタンを押したときにタイトル画面に遷移
    public void OnClickTitlereturn()
    {
        SceneManager.LoadScene("Title");
    }

    //ステージセレクト画面でボタンを押したときホーム画面に遷移
    public void OnClickHomereturn()
    {
        SceneManager.LoadScene("Home");
    }
}
