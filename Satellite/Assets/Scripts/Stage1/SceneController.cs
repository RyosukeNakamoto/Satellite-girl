using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Satellite.Stage1
{
    public class SceneController : MonoBehaviour
    {
        // デブリオブジェクトを指定
        public GameObject debri;

        // アイテムオブジェクトを指定
        //public GameObject itemObj;

        // 消滅したデブリのカウント
        public int debriDsCount;

        // 別スクリプトのpubric関数を呼び出す例
        //Enemy enemyScript;

        // Start is called before the first frame update
        void Start()
        {
            // 別スクリプトのpubric関数を呼び出す例
            //enemyScript = GetComponent<Enemy>();
        }

        // Update is called once per frame
        void Update()
        {

            //foreach (Transform debri in gameObject.transform)
            //{
            //    // デブリが死んだら
            //    Destroy(debri.gameObject);

            //    // 別スクリプトのpubric関数を呼び出す例
            //    // enemyScript.Death();

            //    // デブリカウントをプラス
            //    debriDsCount++;
            //    // 敵を3体倒したら
            //    if (debriDsCount == 3)
            //    {
            //        Debug.Log("a");
            //    }
            //}
        }
    }
}