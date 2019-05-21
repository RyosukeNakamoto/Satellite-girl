using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frame : MonoBehaviour
{
  Image image = null;
    // Start is called before the first frame update
    void Start()
    {
        image.GetComponent<Image>().color = new Color(0,0,0,0.6f);
        Debug.Log(transform.childCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
