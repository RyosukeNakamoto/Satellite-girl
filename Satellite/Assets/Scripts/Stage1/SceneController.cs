using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Satellite.Stage1
{
    public class SceneController : MonoBehaviour
    {
        // デブリオブジェクトを指定
        public GameObject debri;

        // 消滅したデブリのカウント
        public int debriCount;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            foreach (Transform debri in gameObject.transform)
            {
                Destroy(debri.gameObject);
                debriCount++;
                if (debriCount == 3)
                {
                    Debug.Log("a");
                }
            }


        }
    }
}