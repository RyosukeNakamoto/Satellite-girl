using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Satellite.CharacterSelect
{
    public class SceneController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //エンターキーを押したときにステージ1へ遷移(プロト）
            if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown("joystick button 1"))
            {
                SceneManager.LoadScene("Stage1");
            }
            //スペースキーを押したときステージセレクト画面に遷移
            if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown("joystick button 0"))
            {
                SceneManager.LoadScene("StageSelect");
            }
        }
    }
}