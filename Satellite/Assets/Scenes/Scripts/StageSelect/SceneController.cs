using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Satellite.StageSelect
{

    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        Color selectedColor = Color.white;


        public Image[] stage1;
        public Image[] stage2;
        public Image[] stage3;
        public Image[] stage4;
        public Image[] stage5;
        public Image[] stage6;

        AudioSource audioSource;
        public AudioClip[] sound;

        //曲再生の判定
        bool isAudioStart = false; 
        //どこを選択中か数値で管理
        int selectnumber = 0;
        int selectsecondnumber = 0;

        // Start is called before the first frame update
        void Start()
        {
            //音コンポーネントの取得
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            //十字キーの横の入力
            float dpv = Input.GetAxis("D_Pad_V");

            //右矢印キーを押したときSelectnumberを増やす
            if (Input.GetKeyDown(KeyCode.RightArrow)||dpv>0)
            {
                selectnumber++;
                //カーソル移動したとき音再生
                audioSource.PlayOneShot(sound[0]);
            }
            //左矢印キーを押したときSelectnumberを減らす
            if (Input.GetKeyDown(KeyCode.LeftArrow)||dpv<0)
            {
                selectnumber--;
                //カーソル移動したとき音再生
                audioSource.PlayOneShot(sound[0]);
            }
            //Selectnumberが5を越えた時0に戻す処理
            if (selectnumber > 5)
            {
                selectnumber = 0;
            }
            //Selectnumberが0を下回った時5にする処理
            if (selectnumber < 0)
            {
                selectnumber = 5;
            }

            //Stage1を選択状態
            if (selectnumber == 0)
            {
                stage1[0].enabled = false;
                stage1[1].enabled = true;

                //エンターキーを押したときキャラクター選択画面に遷移(プロト)
                if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown("joystick button 1"))
                {
                    //決定時の音再生
                    audioSource.PlayOneShot(sound[1]);

                    isAudioStart = true;

                    if (!audioSource.isPlaying && isAudioStart)
                    {
                        SceneManager.LoadScene("CharacterSelect");
                    }
                    //ホーム画面に遷移
                    SceneManager.LoadScene("CharacterSelect");
                }
            }
            else
            {
                stage1[0].enabled = true;
                stage1[1].enabled = false;
            }
            //Stage2を選択状態
            if (selectnumber == 1)
            {
                stage2[0].enabled = false;
                stage2[1].enabled = true;
            }
            else
            {
                stage2[0].enabled = true;
                stage2[1].enabled = false;
            }
            //Stage3を選択状態
            if (selectnumber == 2)
            {
                stage3[0].enabled = false;
                stage3[1].enabled = true;
            }
            else
            {
                stage3[0].enabled = true;
                stage3[1].enabled = false;
            }

            //Stage4を選択状態
            if (selectnumber == 3)
            {
                stage4[0].enabled = false;
                stage4[1].enabled = true;
            }
            else
            {
                stage4[0].enabled = true;
                stage4[1].enabled = false;
            }
            //Stage5を選択状態
            if (selectnumber == 4)
            {
                stage5[0].enabled = false;
                stage5[1].enabled = true;
            }
            else
            {
                stage5[0].enabled = true;
                stage5[1].enabled = false;
            }
            //Stage6を選択状態
            if (selectnumber == 5)
            {
                stage6[0].enabled = false;
                stage6[1].enabled = true;
            }
            else
            {
                stage6[0].enabled = true;
                stage6[1].enabled = false;
            }
            }

        }
    }
