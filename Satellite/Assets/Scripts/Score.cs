using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoretext;

    public  Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {       
        scoretext.text = "score:0";
    }

    // Update is called once per frame
    void Update()
    {
        text();
    }

    // 
    void text()
    {
   //     scoretext.text = "score:{0}" + debriCountscore.ToString();
    }
}
