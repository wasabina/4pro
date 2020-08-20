using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Message : MonoBehaviour
{
    private Text message;
    private int fingerNum = 0;

    public GameObject bm; //ButtonManager

    // Start is called before the first frame update
    void Start()
    {
        message = GetComponent<Text>();
        message.text = "0個のボタンに触れています";
    }

    // Update is called once per frames
    void Update()
    {
        fingerNum = bm.GetComponent<ButtonManager>().NumOfTouchButtons;
        message.text = fingerNum + "個のボタンに触れています";
    }
}
