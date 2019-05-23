using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    // 画像を指定
    [SerializeField]
    Sprite hpBar1;      // ステータス0
    [SerializeField]
    Sprite hpBar2;      // ステータス1
    [SerializeField]
    Sprite hpBar3;      // ステータス2
    [SerializeField]
    Sprite hpBar4;      // ステータス3
    [SerializeField]
    Sprite hpBar5;      // ステータス4
    [SerializeField]
    Sprite hpBar6;      // ステータス5
    //int[] a = { 9, 12, 15, 18, 21, 24 };
    //// 
    //CustomController customController;
    //// GameControllerのステータスを取得
    //GameController[] gameController;

    // Start is called before the first frame update
    void Start()
    {
        //customController = GetComponent<CustomController>();
        //gameController = GetComponent<GameController[]>();
        //if ()
        //{

        //}
        //if (customController.ununsettledHp == 1)
        //{
        //    Debug.Log("kita");
        //    GetComponent<Image>().sprite = hpBar6;
        //    GetComponent<Image>().SetNativeSize();
        //}
        //if ( GameController.Instance.hpTable ==(GameController.Instance.hpTable))
        //{
        //    Debug.Log("kita");
        switch (GameController.Instance.hpLevel)
        {
            case 0:
                GetComponent<Image>().sprite = hpBar6;
                GetComponent<Image>().SetNativeSize();
                Debug.Log("kita");
                break;
            case 1:
                GetComponent<Image>().sprite = hpBar5;
                GetComponent<Image>().SetNativeSize();
                break;
            case 2:
                GetComponent<Image>().sprite = hpBar4;
                GetComponent<Image>().SetNativeSize();
                break;
            case 3:
                GetComponent<Image>().sprite = hpBar3;
                GetComponent<Image>().SetNativeSize();
                break;
            case 4:
                GetComponent<Image>().sprite = hpBar2;
                GetComponent<Image>().SetNativeSize();
                break;
            case 5:
                GetComponent<Image>().sprite = hpBar1;
                GetComponent<Image>().SetNativeSize();
                break;
        }

        //}
        //Debug.Log(a);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
