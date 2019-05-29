using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("親密度", GameController.Instance.intimacyLevel);
        PlayerPrefs.GetInt("HP", GameController.Instance.hpLevel);
        PlayerPrefs.GetInt("活動時間", GameController.Instance.activityTimeLevel);
        PlayerPrefs.GetInt("攻撃力", GameController.Instance.attackLevel);
        PlayerPrefs.GetInt("射出間隔", GameController.Instance.rapidfireLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
