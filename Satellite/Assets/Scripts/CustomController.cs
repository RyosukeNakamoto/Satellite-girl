using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomController : MonoBehaviour
{
    //どこを選択中か数値で管理
    public int selectnumber = 0;

    //「性格」のアウトライン
    public Outline personality;
    //「武器」のアウトライン
    public Outline weapon;
    //「防具」のアウトライン
    public Outline armor;
    //「戻る」のアウトライン
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

        //selectnumberが4になったとき、selectnumberを0にする
        if (selectnumber == 4)
        {
            selectnumber = 0;
        }
        //selectnumberが-1になったとき、selectnumberを3にする
        if (selectnumber == -1)
        {
            selectnumber = 3;
        }

        //「性格」を選択状態
        if (selectnumber == 0)
        {
            //「性格」以外のアウトラインを非表示
            personality.enabled = true;
            weapon.enabled = false;
            armor.enabled = false;
            back.enabled = false;

            //エンターキーを押したとき「性格変更」へシーン遷移
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("CustomPersonality");
            }
        }

        //「武器」を選択状態
        if (selectnumber == 1)
        {
            //「武器」以外のアウトラインを非表示
            personality.enabled = false;
            weapon.enabled = true;
            armor.enabled = false;
            back.enabled = false;

            //エンターキーを押したとき「武器」へシーン遷移
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("CustomWeapon");
            }
        }

        //「防具」を選択状態
        if (selectnumber == 2)
        {
            //「防具」以外のアウトラインを非表示
            personality.enabled = false;
            weapon.enabled = false;
            armor.enabled = true;
            back.enabled = false;
        }

        //「戻る」を選択状態
        if (selectnumber == 3)
        {
            //「戻る」以外のアウトラインを非表示
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
