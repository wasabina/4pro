using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentsController : MonoBehaviour
{
    private int fingerNum = 0;
    public GameObject bm; //ButtonManager
    [SerializeField]
    private int requiredFingerNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<UniWebView>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        fingerNum = bm.GetComponent<ButtonManager>().NumOfTouchButtons;
        if (fingerNum >= requiredFingerNum)
        {
            this.gameObject.GetComponent<UniWebView>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<UniWebView>().enabled = false;
        }
    }
}
