using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    // 画像を指定
    [SerializeField]
    Sprite StaminaBar1;      // ステータス0
    [SerializeField]
    Sprite StaminaBar2;      // ステータス1
    [SerializeField]
    Sprite StaminaBar3;      // ステータス2
    [SerializeField]
    Sprite StaminaBar4;      // ステータス3
    [SerializeField]
    Sprite StaminaBar5;      // ステータス4
    [SerializeField]
    Sprite StaminaBar6;      // ステータス5

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = StaminaBar1;
        GetComponent<Image>().SetNativeSize();
        switch (GameController.Instance.activityTimeLevel)
        {
            case 0:
                GetComponent<Image>().sprite = StaminaBar6;
                GetComponent<Image>().SetNativeSize();
                break;
            case 1:
                GetComponent<Image>().sprite = StaminaBar5;
                GetComponent<Image>().SetNativeSize();
                break;
            case 2:
                GetComponent<Image>().sprite = StaminaBar4;
                GetComponent<Image>().SetNativeSize();
                break;
            case 3:
                GetComponent<Image>().sprite = StaminaBar3;
                GetComponent<Image>().SetNativeSize();
                break;
            case 4:
                GetComponent<Image>().sprite = StaminaBar2;
                GetComponent<Image>().SetNativeSize();
                break;
            case 5:
                GetComponent<Image>().sprite = StaminaBar1;
                GetComponent<Image>().SetNativeSize();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
