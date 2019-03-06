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

    //「機械的な女の子」を選択してるかを判定
    public static bool mechanical = false;
    //「活発な女の子」を選択しているかを判定
    public static bool lively = false;
    //「清楚な女の子」を選択しているかを判定
    public static bool neat = false;
    //「ツンデレな女の子」を選択しているか判定
    public static bool tsundere = false;

    public Image mechanicalSprite;
    public Image livelySprite;
    public Image neatSprite;
    public Image tsundereSprite;



    // Start is called before the first frame update
    void Start()
    {
        //シーン開始時にすべてのアウトラインを非表示
        backoutline.enabled = false;
        mechanicalgirloutline.enabled = false;
        livelygirloutline.enabled = false;
        neatgirloutline.enabled = false;
        tsunderegirloutline.enabled = false;

        mechanicalSprite.color = Color.gray;
        livelySprite.color = Color.gray;
        neatSprite.color = Color.gray;
        tsundereSprite.color = Color.gray;

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

            //エンターキーを押して「機械的な女の子」に決定
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //「機械的な女の子」以外をfalseに
                mechanical = true;
                lively = false;
                neat = false;
                tsundere = false;
            }

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

            //エンターキーで「活発な女の子」に決定
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //「活発な女の子」以外をfalseni
                mechanical = false;
                lively = true;
                neat = false;
                tsundere = false;
            }
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

            //エンターキーで「清楚な女の子」に決定
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //「清楚な女の子」以外をfalse
                mechanical = false;
                lively = false;
                neat = true;
                tsundere = false;
            }
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
            
            //エンターキーで「ツンデレな女の子」に決定
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //「ツンデレな女の子」以外をfalseに
                mechanical = false;
                lively = false;
                neat = false;
                tsundere = true;
            }
        }

        if (mechanical == true)
        {
            mechanicalSprite.color = Color.yellow;
            livelySprite.color = Color.gray;
            neatSprite.color = Color.gray;
            tsundereSprite.color = Color.gray;
        }

        if (lively == true)
        {
            mechanicalSprite.color = Color.gray;
            livelySprite.color = Color.yellow;
            neatSprite.color = Color.gray;
            tsundereSprite.color = Color.gray;
        }

        if (neat == true)
        {
            mechanicalSprite.color = Color.gray;
            livelySprite.color = Color.gray;
            neatSprite.color = Color.yellow;
            tsundereSprite.color = Color.gray;
        }

        if (tsundere == true)
        {
            mechanicalSprite.color = Color.gray;
            livelySprite.color = Color.gray;
            neatSprite.color = Color.gray;
            tsundereSprite.color = Color.yellow;
        }
    }
}
