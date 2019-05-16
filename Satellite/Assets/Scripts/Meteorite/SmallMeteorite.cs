using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMeteorite : Meteorite
{
    // Start is called before the first frame update
    void Start()
    {
        // メインカメラを取得
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // カメラの範囲から再度外れたらfalse
        isRendered = false;
        // カメラより左なら消滅
        if (!isRendered)
        {
            if (camera.transform.position.x - 14 >= gameObject.transform.position.x)
            {
                Destroy(gameObject);
            }
        }
    }

     // 当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Bullet")
        {
            hp -= GameController.Instance.Attack;
        }
    }
    // カメラの表示範囲に入ったら動作します
    private void OnWillRenderObject()
    {
        // カメラに表示されたときtrue
        if (Camera.current.tag == cameraTagName)
        {
            isRendered = true;
        }
    }
}
