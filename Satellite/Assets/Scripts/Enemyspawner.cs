using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 20; i++)
        {
            var position = transform.position;
            position.x += i * 3.0f;
            position.y = Random.Range(-4.0f, 4.0f);
            Instantiate(enemy, position, enemy.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
