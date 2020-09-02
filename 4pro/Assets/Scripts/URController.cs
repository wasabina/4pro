using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class URController : MonoBehaviour
{
    private int fingerNum = 0;
    public GameObject bm; //ButtonManager
    [SerializeField]
    GameObject[] buttons = new GameObject[10];
    private int requiredFingerNum = 0;
    public GameObject webView;
    public Text text_buttonNum;
    public Text text_touchedNum;

    // Start is called before the first frame update
    void Start()
    {
        webView.GetComponent<UniWebView>().enabled = false;

        switch (PlayerPrefs.GetInt("buttonLayout", 0))
        {
            case 0:
                requiredFingerNum = 6;
                break;

            default:
                requiredFingerNum = 6;
                break;
        }

        text_touchedNum.text = "0個のボタンに触れています";
        text_buttonNum.text = requiredFingerNum.ToString() + "個のボタン全てを同時にタッチし続ける";

        for (var i = 0; i < buttons.Length; i++)
        {
            if (i < requiredFingerNum)
            {
                buttons[i].SetActive(true);
            }
            else
            {
                buttons[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        fingerNum = bm.GetComponent<ButtonManager>().NumOfTouchButtons;

        text_touchedNum.text = fingerNum + "個のボタンに触れています";

        if (fingerNum >= requiredFingerNum)
        {
            webView.GetComponent<UniWebView>().enabled = true;
        }
        else
        {
            webView.GetComponent<UniWebView>().enabled = false;
        }
    }

    public void SettingButtonClicked()
    {
        SceneManager.LoadScene("URSettings");
    }

    public void HomeButtonClicked()
    {
        SceneManager.LoadScene("Home");
    }
}
