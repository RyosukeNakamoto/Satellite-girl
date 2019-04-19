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


        public Image stage1;
        public Image stage2;
        public Image stage3;
        public Image stage4;
        public Image stage5;
        public Image stage6;
        public Image back;

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
            //シーン開始時に選択中の表示の非表示
            stage1.color = Color.gray;
            stage2.color = Color.gray;
            stage3.color = Color.gray;
            stage4.color = Color.gray;
            stage5.color = Color.gray;
            stage6.color = Color.gray;
            back.color = Color.gray;

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
                stage1.color = selectedColor;
                stage2.color = Color.gray;
                stage3.color = Color.gray;
                stage4.color = Color.gray;
                stage5.color = Color.gray;
                stage6.color = Color.gray;
                back.color = Color.gray;

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
            //Stage2を選択状態
            if (selectnumber == 1)
            {
                stage1.color = Color.gray;
                stage2.color = selectedColor;
                stage3.color = Color.gray;
                stage4.color = Color.gray;
                stage5.color = Color.gray;
                stage6.color = Color.gray;
                back.color = Color.gray;
            }
            //Stage3を選択状態
            if (selectnumber == 2)
            {
                stage1.color = Color.gray;
                stage2.color = Color.gray;
                stage3.color = selectedColor;
                stage4.color = Color.gray;
                stage5.color = Color.gray;
                stage6.color = Color.gray;
                back.color = Color.gray;
            }

            //Stage4を選択状態
            if (selectnumber == 3)
            {
                stage1.color = Color.gray;
                stage2.color = Color.gray;
                stage3.color = Color.gray;
                stage4.color = selectedColor;
                stage5.color = Color.gray;
                stage6.color = Color.gray;
                back.color = Color.gray;
            }
            //Stage5を選択状態
            if (selectnumber == 4)
            {
                stage1.color = Color.gray;
                stage2.color = Color.gray;
                stage3.color = Color.gray;
                stage4.color = Color.gray;
                stage5.color = selectedColor;
                stage6.color = Color.gray;
                back.color = Color.gray;
            }
            //Stage6を選択状態
            if (selectnumber == 5)
            {
                stage1.color = Color.gray;
                stage2.color = Color.gray;
                stage3.color = Color.gray;
                stage4.color = Color.gray;
                stage5.color = Color.gray;
                stage6.color = selectedColor;
                back.color = Color.gray;
            }
            }

        }
    }
