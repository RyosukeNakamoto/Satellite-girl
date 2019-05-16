using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    //弾の移動スピード
    // public int speed = 30; 

    Rigidbody2D rigidbody;

    // 着弾エフェクト
    [SerializeField]
    private GameObject landing;

    //武器のスプライト
    SpriteRenderer bulletsprite;

    // バフ発動
    public static bool buffTrigger = false;
    private void Awake()
    {
       
    }
    private void OnEnable()
    {

    }
    private void Reset()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        // 弾の威力設定
        damage = GameController.Instance.Attack;
        Debug.Log(damage);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameController.Instance.Attack);
        Vector3 pos = transform.position;
        pos += transform.right * speed * Time.deltaTime;
        transform.position = pos;

        if (buffTrigger)
        {
            damage += 3;
            Debug.Log(damage);
            buffTrigger = false;
        }
        if (!Player.buffSet)
        {
            damage = GameController.Instance.Attack;
            Debug.Log(damage);            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(landing, transform.position, landing.transform.rotation);
        Destroy(gameObject);
    }  
}
