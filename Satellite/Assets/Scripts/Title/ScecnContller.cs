using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Satellite.Title
{
    public class ScecnContller : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            //タイトル画面でいずれかのキーを押したときのシーン遷移
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Home");
            }
        }
    }
}