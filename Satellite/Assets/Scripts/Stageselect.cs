using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselect : MonoBehaviour
{

    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    public GameObject Stage4;
    public GameObject Stage5;
    public GameObject Stage6;
    public GameObject Return;

    //どこを選択中か数値で管理
    int Selectnumber = 0;
    int Selectsecondnumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        //シーン開始時に選択中の表示の非表示
        Stage1.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(false);
        Stage4.SetActive(false);
        Stage5.SetActive(false);
        Stage6.SetActive(false);
        Return.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //右矢印キーを押したときSelectnumberを増やす
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Selectnumber++;
        }
        //左矢印キーを押したときSelectnumberを減らす
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Selectnumber--;
        }
        //Selectnumberが2を越えた時0に戻す処理
        if (Selectnumber > 2)
        {
            Selectnumber = 0;
        }
        //Selectnumberが0を下回った時2にする処理
        if (Selectnumber < 0)
        {
            Selectnumber = 2;
        }
        //下矢印キーを押したときSelectsecondnumberを増やす処理
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Selectsecondnumber++;
        }
        //上矢印キーを押したときSelectsecondnumberを減らす処理
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Selectsecondnumber--;
        }
        //Selectsecondnumberが2を越えた時0に戻す処理
        if (Selectsecondnumber > 2)
        {
            Selectsecondnumber = 0;
        }
        //Selectsecondnumberが0を下回った時2にする処理
        if (Selectsecondnumber < 0)
        {
            Selectsecondnumber = 2;
        }

        //1段目を選択状態
        if (Selectsecondnumber == 0)
        {
            //Stage1を選択状態
            if (Selectnumber == 0)
            {
                Stage1.SetActive(true);
                Stage2.SetActive(false);
                Stage3.SetActive(false);
                Stage4.SetActive(false);
                Stage5.SetActive(false);
                Stage6.SetActive(false);
                Return.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene("Stage1");
                }
            }
            //Stage2を選択状態
            if (Selectnumber == 1)
            {
                Stage1.SetActive(false);
                Stage2.SetActive(true);
                Stage3.SetActive(false);
                Stage4.SetActive(false);
                Stage5.SetActive(false);
                Stage6.SetActive(false);
                Return.SetActive(false);
            }
            //Stage3を選択状態
            if (Selectnumber == 2)
            {
                Stage1.SetActive(false);
                Stage2.SetActive(false);
                Stage3.SetActive(true);
                Stage4.SetActive(false);
                Stage5.SetActive(false);
                Stage6.SetActive(false);
                Return.SetActive(false);
            }
        }
        //2段目を選択状態
        if (Selectsecondnumber == 1)
        {
            //Stage4を選択状態
            if (Selectnumber == 0)
            {
                Stage1.SetActive(false);
                Stage2.SetActive(false);
                Stage3.SetActive(false);
                Stage4.SetActive(true);
                Stage5.SetActive(false);
                Stage6.SetActive(false);
                Return.SetActive(false);
            }
            //Stage5を選択状態
            if (Selectnumber == 1)
            {
                Stage1.SetActive(false);
                Stage2.SetActive(false);
                Stage3.SetActive(false);
                Stage4.SetActive(false);
                Stage5.SetActive(true);
                Stage6.SetActive(false);
                Return.SetActive(false);
            }
            //Stage6を選択状態
            if (Selectnumber == 2)
            {
                Stage1.SetActive(false);
                Stage2.SetActive(false);
                Stage3.SetActive(false);
                Stage4.SetActive(false);
                Stage5.SetActive(false);
                Stage6.SetActive(true);
                Return.SetActive(false);
            }
        }

        //Returnを選択状態
        if (Selectsecondnumber == 2)
        {
            Stage1.SetActive(false);
            Stage2.SetActive(false);
            Stage3.SetActive(false);
            Stage4.SetActive(false);
            Stage5.SetActive(false);
            Stage6.SetActive(false);
            Return.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Home");
            }
        }
    }
}
