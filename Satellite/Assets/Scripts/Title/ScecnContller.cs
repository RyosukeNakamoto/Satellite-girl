using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Satellite.Title
{
    public class ScecnContller : MonoBehaviour
    {
        // フェードアウトオブジェクト
        [SerializeField] GameObject fadeOut;
        // 動画のオブジェクト
        //[SerializeField] GameObject videoPlayer;
        // キャンバスオブジェクト
       // [SerializeField] GameObject canvas;

        // ゲームorムービー
       // bool gameOrMovie = true;       // true…　false…
        // 経過時間
        float elapsedTime;
        // 画面がムービーに変わるまでの時間
        float movieTime = 30.0f;
        // 時間のリセット
       // float timeReset = 0.0f;
        string video="Video";

        // Start is called before the first frame update
        void Start()
        {
            //videoPlayer.SetActive(false);
            //canvas.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
            if (elapsedTime >= movieTime)
            {               
                StartCoroutine(MovieChange());
            }

            //if (Input.GetKey(KeyCode.Return))
            //{                
            //    StartCoroutine(GameChange());
            //}

            // ゲーム画面の時に動作する
           
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    //UnityEngine.Application.
                    Quit();
                }
                //タイトル画面でいずれかのキーを押したときのシーン遷移
                else if (Input.anyKeyDown)
                {
                    StartCoroutine(Order());
                }
            
        }

        IEnumerator Order()
        {
            fadeOut.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("StageSelect");
        }

        // ムービーを流します(の画面に移動)
        IEnumerator MovieChange()
        {
            fadeOut.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene(video);
            //videoPlayer.SetActive(true);
            //yield return new WaitForSeconds(0.2f);
            //canvas.SetActive(false);
            //yield return new WaitForSeconds(0.3f);
            //fadeOut.SetActive(false);
            //     gameOrMovie = false;
        }
        // ゲームに切り替えます
        //IEnumerator GameChange()
        //{
        //    fadeOut.SetActive(true);
        //    yield return new WaitForSeconds(0.3f);
        //    canvas.SetActive(true);
        //    videoPlayer.SetActive(false);
        //    yield return new WaitForSeconds(0.7f);
        //    fadeOut.SetActive(false);
        //    //gameOrMovie = true;
        //    elapsedTime = timeReset;

        //}


        void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
        }
    }
}