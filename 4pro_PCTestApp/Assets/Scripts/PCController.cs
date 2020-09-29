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
    [SerializeField]
    private int requiredFingerNum = 10;
    public Text text_time;
    public Text text_touchedNum;
    public GameObject panel_start;
    public GameObject panel_finish;
    public GameObject panel_setting;
    public Text text_result;
    public Button button_setting;

    private bool settingFlag;
    private bool timeFlag;
    private float timeLimit = 300; //[s]
    private float currentTime; // 残り時間タイマー[s]
    private int minutes, seconds;
    private Sprite s_setting, s_back;


    // Start is called before the first frame update
    void Start()
    {
        settingFlag = false;
        timeFlag = false;
        currentTime = timeLimit;
        panel_start.SetActive(true);
        panel_finish.SetActive(false);
        panel_setting.SetActive(false);
        text_touchedNum.text = "0個のボタンに触れています";
        s_setting = Resources.Load<Sprite>("icon_settings");
        s_back = Resources.Load<Sprite>("icon_back");
    }

    // Update is called once per frame
    void Update()
    {
        fingerNum = bm.GetComponent<ButtonManager>().NumOfTouchButtons;
        text_touchedNum.text = fingerNum + "個のボタンに触れています";

        if (fingerNum >= requiredFingerNum || currentTime <= 0.0f)
        {
            timeFlag = false;
            text_result.text = "結果\n" + "\n" + string.Format("かかった時間：{0:000}秒", timeLimit - (minutes * 60 + seconds));
            panel_finish.SetActive(true);
        }

        //----------時間計測---------------
        if (timeFlag == true)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0.0f) // ゼロ秒以下にならないようにする
            {
                currentTime = 0.0f;
            }
            minutes = Mathf.FloorToInt(currentTime / 60F);
            seconds = Mathf.FloorToInt(currentTime - minutes * 60);
            text_time.text = string.Format("残り：{0:00}分{1:00}秒", minutes, seconds);
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
        timeFlag = true;
    }

    public void NextButtonClicked()
    {
        if (SceneManager.GetActiveScene().name == "PCTest5")
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
}
