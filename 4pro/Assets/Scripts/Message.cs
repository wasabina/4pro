using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Message : MonoBehaviour
{
    private Text message;
    private int fingerNum = 0;

    public GameObject bm;

    //GameObject button;
    //public ButtonController script;

    // Start is called before the first frame update
    void Start()
    {
        message = GetComponent<Text>();
        message.text = "0個のボタンが押されています";

        //button = GameObject.Find("Button1");
        //script = button.GetComponent<ButtonController>();
        //bool isTouched = false;
    }

    // Update is called once per frames
    void Update()
    {
        fingerNum = bm.GetComponent<ButtonManager>().NumOfTouchButtons;
        message.text = fingerNum + "個のボタンが押されています";

        /*
        //isTouched = script.IsTouched;
        bool t = script.IsTouched;
        //var touchCount = Input.touchCount;
        var b = new ArrayList();
        b.Add(GetComponent("Button1"));
        b.Add(GetComponent("Button2"));
        b.Add(GetComponent("Button3"));
        b.Add(GetComponent("Button4"));
        b.Add(GetComponent("Button5"));
        b.Add(GetComponent("Button6"));
        b.Add(GetComponent("Button7"));
        b.Add(GetComponent("Button8"));
        b.Add(GetComponent("Button9"));
        b.Add(GetComponent("Button10"));
        //fingerNum = script.fingerNum;
        foreach (var a in b)
        {
            //if (a.t) fingerNum++;
        }
        message.text = fingerNum + "個のボタンが押されています";
        */
    }
}
