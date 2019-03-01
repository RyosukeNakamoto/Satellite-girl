using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector2 speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos += speed * Time.deltaTime;
        transform.position = pos;
    }

    // カメラの範囲外に出た際に呼び出されます。
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
