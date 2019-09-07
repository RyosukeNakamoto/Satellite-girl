using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // エネミーのHP
    public int Hp = 0;
    // メインカメラを指定
    public const string cameraTagName = "MainCamera";
    // 表示確認(最初はfalse)
    public bool isRendered = false;
    // 攻撃開始までの時間
    public float enemytime = 1.0f;
    // 時間処理計算
    public float timer;
    // 一回だけ弾を撃つための変数
    public bool Attack = false;
    // 弾を指定
    public GameObject enemyBullet;
    // アイテムオブジェクトを指定
    public GameObject itemObj;
    // エフェクトのオブジェクトを指定
    public GameObject effectObject;
    // カメラの変数
    public Camera camera;
    // 
    public Player playerSc;
    // アニメーション
    public Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
