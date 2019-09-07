using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScecnContller : MonoBehaviour
{
    // フェードアウト
    [SerializeField] GameObject fadeOut;
    // タイトルシーン変数
    string title = "Title";
    // xboxコントローラBボタン
    string bButton = "joystick button 0";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return)|| (Input.GetKey(bButton)))
        {
            StartCoroutine(GameSceneChange());
        }
    }
    IEnumerator GameSceneChange()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(title);
    }
}
