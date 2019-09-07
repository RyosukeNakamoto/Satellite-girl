using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // ポジションを左へ流す速さ
    [SerializeField] float speed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ポジションを左へ流す
        transform.position = new Vector3(transform.position.x - speed, transform.position.y);
    }
}
