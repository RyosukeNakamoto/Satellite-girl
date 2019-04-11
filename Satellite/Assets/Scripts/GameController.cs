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
    public int hpLevel = 0;
    public int[] hpTable = new int[6] { 9, 12, 15, 18, 21, 24 };

    public int HitPoint
    {
        get { return hpTable[hpLevel]; }
    }

    public int activityTimeLevel = 0;
    public int[] activityTimeTable = new int[6] { 6, 7, 8, 9, 10, 11 };

    public int ActivityTime
    {
        get { return activityTimeTable[activityTimeLevel]; }
    }
    public int attackLevel = 0;
    public int[] attackTable = new int[6] { 3, 5, 7, 9, 11, 13 };

    public int Attack
    {
        get { return attackTable[attackLevel]; }
    }
    public int rapidfireLevel = 0;
    public int[] rapidfireTable = new int[6] { 7, 8, 9, 10, 11, 12 };
    public int Rapidfire
    {
        get { return rapidfireTable[rapidfireLevel]; }
    }
    public int sortieLevel = 0;
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
        Debug.Log(score);
    }
}
