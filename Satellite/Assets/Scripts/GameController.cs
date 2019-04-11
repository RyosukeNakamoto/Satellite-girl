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
    public int intimacylevel = 0;
    public int hplevel = 0;
    public int activityTimelevel = 0;
    public int attacklevel = 0;
    public int rapidfirelevel = 0;
    public int sortielevel = 0;
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
