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
    Color color1, color2;
    private float size;

    public bool IsTouched //プロパティ
    {
        get { return this.isTouched; }
    }


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Image>();
        ColorUtility.TryParseHtmlString("#DBDBDB", out color1);
        ColorUtility.TryParseHtmlString("#AAEEFF", out color2);
        button.color = color1;
        size = PlayerPrefs.GetFloat("buttonSize", 1.0f);
        button.transform.localScale = new Vector3(size, size, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (size != PlayerPrefs.GetFloat("buttonSize", 1.0f))
        {
            size = PlayerPrefs.GetFloat("buttonSize", 1.0f);
            button.transform.localScale = new Vector3(size, size, 1.0f);
        }

    }

    public void onTouchAct()
    {
        isTouched = true;
        button.color = color2;
    }

    public void onTouchExit()
    {
        isTouched = false;
        button.color = color1;
    }
}
