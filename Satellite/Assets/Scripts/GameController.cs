using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // デブリオブジェクトを指定
    public GameObject debri;

    // 消滅したデブリのカウント
    public int debriCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Transform debri in gameObject.transform)
        {
            Destroy(debri.gameObject);
            debriCount++;
            if (debriCount == 3)
            {
                Debug.Log("a");
            }
        }


    }
}
