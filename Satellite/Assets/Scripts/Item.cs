using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    GameObject acquisitionEffect;
    [SerializeField]
    int point;
    // ポジションを左へ流す速さ
    [SerializeField]
    float speed = 0;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        // ポジションを左へ流す
        transform.position = new Vector3(transform.position.x - speed, transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.tag == "Player")
        {
            Vector3 position = transform.position;
            position.x -= 1;
            Instantiate(acquisitionEffect, position, acquisitionEffect.transform.rotation);
            Destroy(gameObject);
        }
    }
}
