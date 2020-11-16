using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ParentalController : MonoBehaviour //UniWebViewに直接貼らないと動かない
{
    private int fingerNum = 0;
    public GameObject bm; //ButtonManager
    [SerializeField]
    private int requiredFingerNum = 10;
    private float availableTime;
    public Text text_availableTime;
    public Text text_buttonNum;
    public Text text_touchedNum;
    public GameObject webView;


    // Start is called before the first frame update
    void Start()
    {
        webView.GetComponent<UniWebView>().enabled = false;

        float h = 0f;
        float m = 0f;
        float s = 0f;
        float.TryParse(PlayerPrefs.GetString("InputField_h", "0"), out h);
        float.TryParse(PlayerPrefs.GetString("InputField_m", "0"), out m);
        float.TryParse(PlayerPrefs.GetString("InputField_s", "0"), out s);

        availableTime = h * 3600f + m * 60f + s;

        text_availableTime.text = "利用可能時間：" + h.ToString() + "時間 " + m.ToString() + "分 " + s.ToString() + "秒";

        requiredFingerNum = PlayerPrefs.GetInt("requiredButtonNum", 9) + 1;

        text_buttonNum.text = requiredFingerNum.ToString() + "個のボタン全てを同時にタッチでスタート";

        text_touchedNum.text = "0個のボタンに触れています";
    }

    // Update is called once per frame
    void Update()
    {
        fingerNum = bm.GetComponent<ButtonManager>().NumOfTouchButtons;

        text_touchedNum.text = fingerNum + "個のボタンに触れています";

        if (fingerNum >= requiredFingerNum)
        {
            if (!webView.GetComponent<UniWebView>()) webView.AddComponent<UniWebView>();
            webView.GetComponent<UniWebView>().enabled = true;
            StartCoroutine("WaitAvailableTime");
        }
    }

    IEnumerator WaitAvailableTime()
    {
        yield return new WaitForSeconds(availableTime);
        //遅らせたい処理
        webView.GetComponent<UniWebView>().enabled = false;
    }

    public void SettingButtonClicked()
    {
        SceneManager.LoadScene("SettingScene");
    }
}
