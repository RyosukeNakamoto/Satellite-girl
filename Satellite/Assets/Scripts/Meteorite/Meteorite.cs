using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    // 隕石のHP
    public int hp;
    // 隕石のダメージ
    public int damage;
    // メインカメラを指定
    public const string cameraTagName = "MainCamera";
    // カメラの変数
    public Camera camera;
    // 表示確認(最初はfalse)
    public bool isRendered = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
