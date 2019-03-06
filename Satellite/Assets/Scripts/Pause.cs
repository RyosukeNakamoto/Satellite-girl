using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject pauseImage;

    // Start is called before the first frame update
    void Start()
    {
        pauseImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.0f;
                pauseImage.SetActive(true);


            }
            else if (Time.timeScale == 0.0f)
            {
                Time.timeScale = 1.0f;
                pauseImage.SetActive(false);

            }
        }

        if (Time.timeScale == 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                SceneManager.LoadScene("Home");

            }
        }
    }
}