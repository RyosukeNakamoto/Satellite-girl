using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0.0f;

        Scene loadscene = SceneManager.GetActiveScene();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(loadscene.name);
        }
    }
}
