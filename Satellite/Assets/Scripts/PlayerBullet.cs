﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    //弾の移動スピード
    // public int speed = 30; 

    Rigidbody2D rigidbody;

    
    //武器のスプライト
    SpriteRenderer bulletsprite;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        // 弾の威力設定
        damage = GameController.Instance.Attack;        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameController.Instance.Attack);
        Vector3 pos = transform.position;
        pos += transform.right * speed * Time.deltaTime;
        transform.position = pos;

        ////弾の移動
        //rigidbody.velocity = transform.right.normalized * speed;

              
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }  
}
