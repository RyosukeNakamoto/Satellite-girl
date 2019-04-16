using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController Instance
    {
        get { return instance; }
    }

    private static GameController instance = null;

    //それぞれのパラメーターのレベル
    public int intimacyLevel = 0;
    public int[] intimacyTable = new int[6] { 100, 95, 90, 85, 80, 75 };
    public int Intimacy
    {
        get { return intimacyTable[intimacyLevel]; }
    }
    // HPステータスレベル
    public int hpLevel = 0;
    // レベルテーブル
    public int[] hpTable = new int[6] { 9, 12, 15, 18, 21, 24 };
    // ステータスとレベルを連結
    public int HitPoint
    {
        // 戻り値で判別
        get { return hpTable[hpLevel]; }
    }

    // 活動時間ステータスレベル
    public int activityTimeLevel = 0;
    // レベルテーブル
    public int[] activityTimeTable = new int[6] { 30, 35, 40, 45, 50, 55 };
    // ステータスとレベルを連結
    public int ActivityTime
    {
        // 戻り値で判別
        get { return activityTimeTable[activityTimeLevel]; }
    }

    // 攻撃力ステータスレベル
    public int attackLevel = 0;
    // レベルテーブル
    public int[] attackTable = new int[6] { 3, 5, 7, 9, 11, 13 };
    // ステータスとレベルを連結
    public int Attack
    {
        // 戻り値で判別
        get { return attackTable[attackLevel]; }
    }
    // 弾を撃つ間隔レベル
    public int rapidfireLevel = 0;
    // レベルテーブル
    public float[] rapidfireTable = new float[6] { 0.48f, 0.46f, 0.44f, 0.42f, 0.40f, 0.3f };
    // ステータスとレベルを連結
    public float Rapidfire
    {
        get { return rapidfireTable[rapidfireLevel]; }
    }
    // public int sortieLevel = 0;
    public int score = 0;






    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
