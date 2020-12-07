using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PCController : MonoBehaviour //UniWebViewに直接貼らないと動かない
{
    private int fingerNum = 0;
    public GameObject bm; //ButtonManager
    private int requiredFingerNum;
    public Text text_time;
    public Text text_touchedNum;
    public GameObject panel_start;
    public GameObject panel_finish;
    public GameObject panel_setting;
    public Text text_result;
    public Button button_setting;
    public Button button_giveUp;
    public Button button_countStart;

    private bool settingFlag;
    private bool timeFlag;
    private float timeLimit; //[s]
    private float currentTime; // 残り時間タイマー[s]
    private int minutes, seconds;
    private Sprite s_setting, s_back;


    // Start is called before the first frame update
    void Start()
    {
        settingFlag = false;
        timeFlag = false;
        timeLimit = HomeController.getTimeLimit();
        currentTime = timeLimit;
        var sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "PCTest6")
        {
            requiredFingerNum = 5;
        }
        else
        {
            requiredFingerNum = 10;
        }
        panel_start.SetActive(true);
        panel_finish.SetActive(false);
        panel_setting.SetActive(false);
        button_giveUp.interactable = false;
        button_countStart.interactable = false;
        text_touchedNum.text = "0個のボタンに触れています";
        s_setting = Resources.Load<Sprite>("icon_settings");
        s_back = Resources.Load<Sprite>("icon_back");
    }

    // Update is called once per frame
    void Update()
    {
        fingerNum = bm.GetComponent<ButtonManager>().NumOfTouchButtons;
        text_touchedNum.text = fingerNum + "個のボタンに触れています";

        if (fingerNum >= requiredFingerNum && timeFlag == true/* || currentTime <= 0.0f*/)
        {
            timeFlag = false;
            text_result.text = "結果\n" + "\n" + string.Format("かかった時間：{0:000}秒", timeLimit - (minutes * 60 + seconds));
            panel_finish.SetActive(true);
            button_countStart.interactable = false;
        }

        if (currentTime <= 0.0f)
        {
            button_giveUp.interactable = true;
        }

        //----------時間計測---------------
        if (timeFlag == true)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0.0f) // ゼロ秒以下にならないようにする
            {
                minutes = Mathf.FloorToInt(currentTime / 60F);
                seconds = Mathf.FloorToInt(currentTime - minutes * 60);
                //text_time.text = string.Format("残り：{0:00}分{1:00}秒", minutes, seconds);
            }
            else
            {
                minutes = Mathf.FloorToInt(currentTime / 60F);
                seconds = Mathf.FloorToInt(currentTime - minutes * 60);
                text_time.text = string.Format("残り：{0:00}分{1:00}秒", minutes, seconds);
            }
        }
    }

    public void SettingButtonClicked()
    {
        if (settingFlag == false)
        {
            var image = button_setting.GetComponent<Image>();
            image.sprite = s_back;
            panel_setting.SetActive(true);
            settingFlag = true;
        }
        else
        {
            var image = button_setting.GetComponent<Image>();
            image.sprite = s_setting;
            panel_setting.SetActive(false);
            settingFlag = false;
        }
    }

    public void StartButtonClicked()
    {
        panel_start.SetActive(false);
        button_countStart.interactable = true;
        //timeFlag = true;
    }

    public void CountButtonClicked()
    {
        timeFlag = true;
    }

    public void NextButtonClicked()
    {
        if (SceneManager.GetActiveScene().name == "PCTest6")
        {
            string s = PlayerPrefs.GetString("data", "") + string.Format(SceneManager.GetActiveScene().name + ":{0:000}s", timeLimit - (minutes * 60 + seconds)) + " ";
            PlayerPrefs.SetString("data", s);
            PlayerPrefs.Save();
            SceneManager.LoadScene("End");
        }
        else
        {
            string s = PlayerPrefs.GetString("data", "") + string.Format(SceneManager.GetActiveScene().name + ":{0:000}s", timeLimit - (minutes * 60 + seconds)) + " ";
            PlayerPrefs.SetString("data", s);
            PlayerPrefs.Save();
            SceneManager.LoadScene("PCTest" + (SceneUtility.GetBuildIndexByScenePath(SceneManager.GetActiveScene().name) + 1).ToString());
        }
    }

    public void giveUp()
    {
        timeFlag = false;
        text_result.text = "結果\n" + "\n" + string.Format("かかった時間：{0:000}秒", timeLimit - (minutes * 60 + seconds));
        panel_finish.SetActive(true);
        button_countStart.interactable = false;
    }
}
