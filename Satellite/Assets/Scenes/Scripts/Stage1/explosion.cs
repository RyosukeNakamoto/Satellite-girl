using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    // 爆発のサイズ指定
    public float transSize;

    // エフェクトの表示タイム
    public float timer;
    // 表示中の時間
    private float effectTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        // コライダーのサイズをオブジェクトに合わせます
        // オブジェクトのサイズを取得します
        Vector2 objectSize = gameObject.GetComponent<RectTransform>().sizeDelta;
        // コライダーを取得します
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        // オブジェクトにコライダーを合わせます
        collider.radius = objectSize.magnitude / 2.8f;
        
    }

    // Update is called once per frame
    void Update()
    {
        // 簡易的に爆発のサイズを大きくします
        gameObject.transform.localScale += new Vector3(transSize, transSize);

        // 消滅までのタイム
        timer += Time.deltaTime;

        if (effectTime <= timer)
        {
            Destroy(gameObject);
        }

    }
}
