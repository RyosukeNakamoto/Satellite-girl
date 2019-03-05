using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomController : MonoBehaviour
{
    //どこを選択中か数値で管理
    public int selectnumber = 0;

    //「性格」オブジェクトのアウトライン
    public Outline personality;
    //「武器」オブジェクトのアウトライン
    public Outline weapon;
    //「防具」オブジェクトのアウトライン
    public Outline armor;
    //「戻る」オブジェクトのアウトライン
    public Outline back;


    // Start is called before the first frame update
    void Start()
    {
        //シーン開始時にすべてのアウトラインを非表示
        personality.enabled = false;
        weapon.enabled = false;
        armor.enabled = false;
        back.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //上矢印キーを押したときSelectnumberを減らす
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectnumber--;
        }

        //下矢印キーを押したときSelectnumberを増やす
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectnumber++;
        }

        //selectnumberが5になったとき、selectnumberを0にする
        if (selectnumber == 4)
        {
            selectnumber = 0;
        }
        //selectnumberが-1になったとき、selectnumberを4にする
        if (selectnumber == -1)
        {
            selectnumber = 3;
        }

        //「性格」を選択状態
        if (selectnumber == 0)
        {
            personality.enabled = true;
            weapon.enabled = false;
            armor.enabled = false;
            back.enabled = false;
        }

        //「武器」を選択状態
        if (selectnumber == 1)
        {
            personality.enabled = false;
            weapon.enabled = true;
            armor.enabled = false;
            back.enabled = false;
        }

        //「防具」を選択状態
        if (selectnumber == 2)
        {
            personality.enabled = false;
            weapon.enabled = false;
            armor.enabled = true;
            back.enabled = false;
        }

        //「戻る」を選択状態
        if (selectnumber == 3)
        {
            personality.enabled = false;
            weapon.enabled = false;
            armor.enabled = false;
            back.enabled = true;

            //エンターキーを押したとき「ホーム」へ遷移
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Home");
            }
        }
    }
}
