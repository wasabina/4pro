using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Video;

public class UR_A : MonoBehaviour
{
    private int fingerNum = 0;
    public GameObject bm; //ButtonManager
    private int requiredFingerNum;
    public Text text_touchedNum;
    public GameObject panel_start;
    public GameObject panel_finish;
    public GameObject panel_setting;
    public Button button_setting;
    public VideoPlayer rI_video;

    private bool settingFlag;
    private bool timeFlag;
    private float timeLimit; //[s]
    private float currentTime; // 残り時間タイマー[s]
    private int minutes, seconds;
    private Sprite s_setting, s_back;
    private RawImage rawimage;

    // Start is called before the first frame update
    void Start()
    {
        settingFlag = false;
        timeFlag = false;
        currentTime = timeLimit;
        requiredFingerNum = 3;
        panel_start.SetActive(true);
        panel_finish.SetActive(false);
        panel_setting.SetActive(false);
        text_touchedNum.text = "0個のボタンに触れています";
        s_setting = Resources.Load<Sprite>("icon_settings");
        s_back = Resources.Load<Sprite>("icon_back");
        rawimage = rI_video.GetComponents<RawImage>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        fingerNum = bm.GetComponent<ButtonManager>().NumOfTouchButtons;
        text_touchedNum.text = fingerNum + "個のボタンに触れています";

        if (fingerNum >= requiredFingerNum)
        {
            rawimage.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
            Play();
        }
        else
        {
            rawimage.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);
        }

        if (currentTime <= 0.0f)
        {
            
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
        //timeFlag = true;
    }

    public void NextButtonClicked()
    {
        string s = PlayerPrefs.GetString("data", "") + string.Format(SceneManager.GetActiveScene().name + ":{0:000}s", timeLimit - (minutes * 60 + seconds)) + " ";
        PlayerPrefs.SetString("data", s);
        PlayerPrefs.Save();
        SceneManager.LoadScene("URTest1");
    }

    public void Play()
    {
        if (!rI_video.isPlaying)
        {
            rI_video.Play();
        }
    }

    public void Pause()
    {
        if (rI_video.isPlaying)
        {
            rI_video.Pause();
        }
    }

    public void Stop()
    {
        rI_video.Stop();
    }
}
