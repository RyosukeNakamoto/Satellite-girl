using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakuhatuEffect : MonoBehaviour
{
    float time ;
    bool destroy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("AimShotFiveConsecutive");
        if (destroy)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator AimShotFiveConsecutive()
    {
        //0.5秒弾の間隔を空ける
        yield return new WaitForSeconds(1.5f);
        destroy = true;
    }
}
