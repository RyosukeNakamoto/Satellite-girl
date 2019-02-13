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
