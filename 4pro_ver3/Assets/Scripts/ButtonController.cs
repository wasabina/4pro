using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Image button;
    private bool isTouched = false;

    public bool IsTouched //プロパティ
    {
        get { return this.isTouched; }
    }


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Image>();
        button.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onTouchAct()
    {
        isTouched = true;
        button.color = Color.blue;
    }

    public void onTouchExit()
    {
        isTouched = false;
        button.color = Color.red;
    }
}
