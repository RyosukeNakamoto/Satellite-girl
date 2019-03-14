using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Scene loadscene = SceneManager.GetActiveScene();

        if (this)
        {
            //クリア表示後に、エンターキーでキャラクターセレクト画面に遷移
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("CharacterSelect");
            }

            //クリア表示後に、スペースキーでもう一回
            if (Input.GetKeyDown(KeyCode.Space))
            {

                SceneManager.LoadScene(loadscene.name);

            }
        }
    }
}
