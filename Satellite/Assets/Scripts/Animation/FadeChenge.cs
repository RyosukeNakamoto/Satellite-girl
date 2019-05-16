using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeChenge : MonoBehaviour
{
    // フェードチェンジアニメーション
    private Animator fadeChange;

    // Start is called before the first frame update
    void Start()
    {
        fadeChange = GetComponent<Animator>();
        if (EnemyGenerator.fadeChenge == true)
        {      
            StartCoroutine(enumerator());
        }
    }

    IEnumerator enumerator()
    {
        fadeChange.SetInteger("FadeChenge", 1);
        yield return new WaitForSeconds(5.0f);
        fadeChange.SetInteger("FadeChenge", 2);
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
