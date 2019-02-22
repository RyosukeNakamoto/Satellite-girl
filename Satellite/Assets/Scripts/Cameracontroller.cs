using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{

    public GameObject player;

    public float Speed = 0;

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x + 5, 0, -10);

        rigidbody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Speed, 0, 0);

        rigidbody.velocity = new Vector2(Speed, rigidbody.velocity.y);
    }
}
