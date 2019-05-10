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

    //* セレステルステータス
    // 親密度ステータスレベル
    public int intimacyLevel = 0;
    // レベルテーブル
    public float[] intimacyTable = new float[6] { 100, 95, 90, 85, 80, 75 };
    // ステータスとレブルを連結
    public float Intimacy
    {
        // 戻り値で判別
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

    public int[] Hp
    {
        get { return hpTable; }
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
    public float[] rapidfireTable = new float[6] { 0.3f, 0.46f, 0.44f, 0.42f, 0.40f, 0.2f };
    // ステータスとレベルを連結
    public float Rapidfire
    {
        get { return rapidfireTable[rapidfireLevel]; }
    }
    //*
    // public int sortieLevel = 0;
    public int score = 0;
    public int scoreText = 0;
    public float HpGet = 1;
    
    // ステージの管理
    public int stage = 0;

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
