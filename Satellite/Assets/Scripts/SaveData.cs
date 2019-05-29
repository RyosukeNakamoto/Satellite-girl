using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("親密度", GameController.Instance.intimacyLevel);
        PlayerPrefs.SetInt("HP", GameController.Instance.hpLevel);
        PlayerPrefs.SetInt("活動時間", GameController.Instance.activityTimeLevel);
        PlayerPrefs.SetInt("攻撃力", GameController.Instance.attackLevel);
        PlayerPrefs.SetInt("射出間隔", GameController.Instance.rapidfireLevel);

        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
