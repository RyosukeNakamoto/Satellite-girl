using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Satellite.Stage1
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private FadeLayer fadeLayer;
        [SerializeField] private AudioClip audioClip;
        AudioSource clear;
        //IEnumerator FadeInIEnumerator()
        //{
        //    yield return fadeLayer.FadeInEnumerator(2.0f);
        //    yield return fadeLayer.FadeOutEnumerator(Color.yellow, 2.0f);
        //}

        //IEnumerator FadeOutIEnumerator()
        //{
        //    yield return fadeLayer.FadeOutEnumerator(Color.yellow,2.0f);
        //}
        //private void Awake()
        //{
        //    //fadeLayer.ForceColor(Color.black);
        //}
        //private void Start()
        //{
        //    StartCoroutine(FadeInIEnumerator());
        //}


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}