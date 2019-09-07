using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // ポジションを左へ流す速さ
    [SerializeField] float speed = 0;

    // 背景の枚数
    float spriteCount = 4f;
    // 背景が回り込み
    float rightOffset = 1.55f;
    float leftOffset = -1f;

    Transform bgTfm;
    SpriteRenderer mySpriteRndr;
    float width;

    void Start()
    {
        bgTfm = transform;
        mySpriteRndr = GetComponent<SpriteRenderer>();
        width = mySpriteRndr.bounds.size.x;
    }


    void Update()
    {
        // ポジションを左へ流す
        transform.position = new Vector3(transform.position.x - speed, transform.position.y);
        // 座標変換
        Vector3 myViewport = Camera.main.WorldToViewportPoint(bgTfm.position);

        // 背景の回り込み(カメラがX軸プラス方向に移動時)
        if (myViewport.x < leftOffset)
        {
            bgTfm.position += Vector3.right * (width * spriteCount);
        }
        // 背景の回り込み(カメラがX軸マイナス方向に移動時)
        else if (myViewport.x > rightOffset)
        {
            bgTfm.position -= Vector3.right * (width * spriteCount);
        }
    }
}
