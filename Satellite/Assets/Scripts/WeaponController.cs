using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WeaponController : MonoBehaviour
{
    //どこを選択中か数値で管理
    public int selectnumber = 0;

    //「戻る」のアウトライン
    public Outline back;
    //「ライフル」のアウトライン
    public Outline rifle;
    //「マシンガン」のアウトライン
    public Outline machinegun;
    //「バズーカ」のアウトライン
    public Outline bazooka;

    // Start is called before the first frame update
    void Start()
    {
        //シーン開始時にすべてのアウトラインを非表示
        back.enabled = false;
        rifle.enabled = false;
        machinegun.enabled = false;
        bazooka.enabled = false;
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

        //selectnumber4がになったとき、selectnumberを0にする
        if (selectnumber == 4)
        {
            selectnumber = 0;
        }
        //selectnumberが-1になったとき、selectnumberを3にする
        if (selectnumber == -1)
        {
            selectnumber = 3;
        }

        //「戻る」を選択中
        if (selectnumber == 0)
        {
            //「戻る」以外のアウトラインを非表示
            back.enabled = true;
            rifle.enabled = false;
            machinegun.enabled = false;
            bazooka.enabled = false;

            //エンターキーを押したとき「カスタム」へシーン遷移
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Custom");
            }
        }

        //「ライフル」を選択中
        if (selectnumber == 1)
        {
            //「ライフル」以外のアウトラインを非表示
            back.enabled = false;
            rifle.enabled = true;
            machinegun.enabled = false;
            bazooka.enabled = false;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Bullet.bulletstatus = 0;
            }
        }

        //「マシンガン」を選択中
        if (selectnumber == 2)
        {
            //「マシンガン」以外のアウトラインを非表示
            back.enabled = false;
            rifle.enabled = false;
            machinegun.enabled = true;
            bazooka.enabled = false;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Bullet.bulletstatus = 1;
            }
        }

        //「バズーカ」を選択中
        if (selectnumber == 3)
        {
            //「バズーカ」以外のアウトラインを非表示
            back.enabled = false;
            rifle.enabled = false;
            machinegun.enabled = false;
            bazooka.enabled = true;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Bullet.bulletstatus = 2;
            }
        }
    }
}
