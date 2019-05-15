using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidiamMeteorite : Meteorite
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Bullet")
        {
            hp -= GameController.Instance.Attack;
        }
    }
}
