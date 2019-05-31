﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Satellite.Title
{
    public class ScecnContller : MonoBehaviour
    {
        [SerializeField] GameObject fadeOut;

        // Update is called once per frame
        void Update()
        {
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