using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{

    //ボスのHP設定
    public float hp=100f;
    public float maxhp=100;

    //ボスのHPスライダー
    public Slider hpslider;

    public GameObject clearImage;

    public Transform target;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        // ボスのMAXHPスライダー
        hpslider.maxValue = maxhp;
        // ボスのHPスライダー
        hpslider.value = hp;

        clearImage.SetActive(false);
        hpslider.enabled = false;        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.x = target.position.x+offset;
        transform.position = pos;

        //ボスの体力が0になったときに、自分を消去
        if (hp <= 0)
        {
            Destroy(gameObject);

            clearImage.SetActive(true);
            // sceneをまたいで保存
            GameController.Instance.score += Player.score;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= GameController.Instance.Attack;
            hpslider.value -= GameController.Instance.Attack;
        }
    }
}
