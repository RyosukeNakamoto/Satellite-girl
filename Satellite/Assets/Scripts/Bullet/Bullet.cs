using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // カメラの範囲外に出た際に呼び出されます。
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
