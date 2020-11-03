using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonControllerT : MonoBehaviour
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
        GetComponentInChildren<Text>().text = "";
        ColorUtility.TryParseHtmlString("#DBDBDB", out color1);
        ColorUtility.TryParseHtmlString("#AAEEFF", out color2);
        button.color = color1;
        //size = PlayerPrefs.GetFloat("buttonSize", 1.0f);
        //テストアプリではサイズ固定
        var sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "PCTest4" || sceneName == "PCTest5")
        {
            size = 2.0f;
        }
        else
        {
            size = 1.2f;
        }
        button.transform.localScale = new Vector3(size * 1.3f, size * 0.75f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        /* テストアプリでは変更不可
        if (size != PlayerPrefs.GetFloat("buttonSize", 1.0f))
        {
            size = PlayerPrefs.GetFloat("buttonSize", 1.0f);
            button.transform.localScale = new Vector3(size * 1.3f, size * 0.75f, 1.0f);
        }*/

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
