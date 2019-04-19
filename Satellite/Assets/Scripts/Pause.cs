using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject pauseImage;
    // サウンドを指定
    public AudioClip[] sound;
    // サウンドの変数
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // オーディオのコンポーネント
        audioSource = GetComponent<AudioSource>();
        pauseImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 9"))
        {
            // サウンドの再生
            audioSource.PlayOneShot(sound[0]);
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
            if (Input.GetKeyDown(KeyCode.Backspace)||Input.GetKeyDown("joystick button 0"))
            {
                SceneManager.LoadScene("CharacterSelect");
            }
        }
    }
}