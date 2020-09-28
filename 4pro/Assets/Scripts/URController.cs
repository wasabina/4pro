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
    GameObject[] buttons = new GameObject[14];
    private int requiredFingerNum = 0;
    private int startButtonNum = 0;
    public GameObject webView;
    public Text text_buttonNum;
    public Text text_touchedNum;
    public Text text_time;
    private int waitSec;
    private int hour;
    private int minute;
    private float seconds;
    private float oldSeconds;//前のUpdateの時の秒数
    private bool counter_flag = false;//時間計測フラグ
    private bool content_flag = true;

    // Start is called before the first frame update
    void Start()
    {
        webView.GetComponent<UniWebView>().enabled = false;

        hour = 0;
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;

        waitSec = 3;

        switch (PlayerPrefs.GetInt("buttonLayout", 0))
        {
            case 0:
                requiredFingerNum = 6;
                startButtonNum = 0;
                break;

            case 1:
                requiredFingerNum = 5;
                startButtonNum = 6;
                break;

            case 2:
                requiredFingerNum = 3;
                startButtonNum = 11;
                break;

            default:
                requiredFingerNum = 6;
                break;
        }

        text_touchedNum.text = "0個のボタンに触れています";
        text_buttonNum.text = requiredFingerNum.ToString() + "個のボタン全てを同時にタッチし続ける";
        text_time.text = "連続コンテンツ利用時間：" + hour.ToString("00") + "時間" + minute.ToString("00") + "分" + ((int)seconds).ToString("00") + "秒";

        //表示するボタンはGUI上で配置しておいた
        for (var i = 0; i < buttons.Length; i++)
        {
            if (i < startButtonNum + requiredFingerNum && i >= startButtonNum)
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

        if (content_flag == true)
        {
            StartCoroutine("showContent");
        }


        //-----時間-------------------

        if (counter_flag == true)
        {
            seconds += Time.deltaTime;
        }

        if (seconds >= 60f)
        {
            minute++;
            seconds -= 60;
        }
        if (minute >= 60)
        {
            hour++;
            minute -= 60;
        }
        if ((int)seconds != (int)oldSeconds)//値が変わった時だけテキストUIを更新
        {
            text_time.text = "連続コンテンツ利用時間：" + hour.ToString("00") + "時間" + minute.ToString("00") + "分" + ((int)seconds).ToString("00") + "秒";
        }
        oldSeconds = seconds;
        //------------------------------
    }
    IEnumerator showContent()
    {
        if (fingerNum >= requiredFingerNum)
        {
            content_flag = false;
            webView.GetComponent<UniWebView>().enabled = true;
            counter_flag = true;
            yield return new WaitForSeconds(waitSec);
            content_flag = true;
        }
        else
        {
            //content_flag = true;
            webView.GetComponent<UniWebView>().enabled = false;
            counter_flag = false;
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
