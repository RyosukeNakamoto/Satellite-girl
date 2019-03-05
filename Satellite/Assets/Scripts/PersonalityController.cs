using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PersonalityController : MonoBehaviour
{
    //どこを選択中か数値で管理
    public int selectnumber = 0;

    //「戻る」のアウトライン
    public Outline backoutline;
    //「機械的な女の子」のアウトライン
    public Outline mechanicalgirloutline;
    //「活発な女の子」のアウトライン
    public Outline livelygirloutline;
    //「清楚な女の子」のアウトライン
    public Outline neatgirloutline;
    //「ツンデレな女の子」のアウトライン
    public Outline tsunderegirloutline;

    public GameObject playerspriteobject;
    PlayerSprite playersprite;


    // Start is called before the first frame update
    void Start()
    {
        //シーン開始時にすべてのアウトラインを非表示
        backoutline.enabled = false;
        mechanicalgirloutline.enabled = false;
        livelygirloutline.enabled = false;
        neatgirloutline.enabled = false;
        tsunderegirloutline.enabled = false;

        playerspriteobject = GameObject.Find("PlayerSprite");
        playersprite = playerspriteobject.GetComponent<PlayerSprite>();
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
        if (selectnumber == 5)
        {
            selectnumber = 0;
        }
        //selectnumberが-1になったとき、selectnumberを4にする
        if (selectnumber == -1)
        {
            selectnumber = 4;
        }

        //「戻る」を選択状態
        if (selectnumber == 0)
        {
            //「戻る」以外のアウトラインを非表示
            backoutline.enabled = true;
            mechanicalgirloutline.enabled = false;
            livelygirloutline.enabled = false;
            neatgirloutline.enabled = false;
            tsunderegirloutline.enabled = false;

            //エンターキーを押したとき「カスタム」へシーン遷移
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Custom");
            }
        }

        //「機械的な女の子」を選択状態
        if (selectnumber == 1)
        {
            //「機械的な女の子」以外のアウトラインを非表示
            backoutline.enabled = false;
            mechanicalgirloutline.enabled = true;
            livelygirloutline.enabled = false;
            neatgirloutline.enabled = false;
            tsunderegirloutline.enabled = false;

            
        }

        //「活発な女の子」を選択状態
        if (selectnumber == 2)
        {
            //「活発な女の子」以外のアウトラインを非表示
            backoutline.enabled = false;
            mechanicalgirloutline.enabled = false;
            livelygirloutline.enabled = true;
            neatgirloutline.enabled = false;
            tsunderegirloutline.enabled = false;
        }

        //「清楚な女の子」を選択状態
        if (selectnumber == 3)
        {
            //「清楚な女の子」以外のアウトラインを非表示
            backoutline.enabled = false;
            mechanicalgirloutline.enabled = false;
            livelygirloutline.enabled = false;
            neatgirloutline.enabled = true;
            tsunderegirloutline.enabled = false;
        }

        //「ツンデレな女の子」を選択状態
        if (selectnumber == 4)
        {
            //「ツンデレな女の子」以外のアウトラインを非表示
            backoutline.enabled = false;
            mechanicalgirloutline.enabled = false;
            livelygirloutline.enabled = false;
            neatgirloutline.enabled = false;
            tsunderegirloutline.enabled = true;
        }
    }
}
