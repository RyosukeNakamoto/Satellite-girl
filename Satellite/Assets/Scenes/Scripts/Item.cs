using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    GameObject acquisitionEffect;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
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
