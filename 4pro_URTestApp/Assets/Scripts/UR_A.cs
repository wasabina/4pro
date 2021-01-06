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
    public Text Text_time;
    public Text Text_visibleTime;
    public Text Text_invisibleTime;
    public GameObject pos;

    private bool settingFlag;
    private bool timeFlag;
    private float time = 0.0f; //[s]
    private float visibleTime = 0.0f; //[s]
    private float invisibleTime = 0.0f; //[s]
    private string failedTime = "手が離れた時刻： ";
    private Sprite s_setting, s_back;
    private RawImage rawimage;
    private bool postponementFlag;//猶予フラグ
    private bool playable;
    private string state = "";//今の見えてる/見えてない
    private string old_state = "";//1フレーム前の見えてる/見えてない

    private static bool isFinished;

    // Start is called before the first frame update
    void Start()
    {
        settingFlag = false;
        timeFlag = false;
        requiredFingerNum = 3;
        panel_start.SetActive(true);
        panel_finish.SetActive(false);
        panel_setting.SetActive(false);
        text_touchedNum.text = "0個のボタンに触れています";
        s_setting = Resources.Load<Sprite>("icon_settings");
        s_back = Resources.Load<Sprite>("icon_back");
        rawimage = rI_video.GetComponents<RawImage>()[0];
        postponementFlag = true;
        playable = true;
        isFinished = false;
        
        if (HomeController.getIsLeftHanded())
        {
            pos.transform.localPosition = new Vector3(-520f, 0.0f, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        fingerNum = bm.GetComponent<ButtonManager>().NumOfTouchButtons;
        text_touchedNum.text = fingerNum + "個のボタンに触れています";

        if (fingerNum >= requiredFingerNum)
        {
            rawimage.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
            if(playable)
            {
                Play();
                playable = false;
            }
            if(!timeFlag) timeFlag = true;
            if(timeFlag)
            {
                state = "visible";
                old_state = "visiblse";
                visibleTime += Time.deltaTime;
                Text_visibleTime.GetComponent<Text>().text = visibleTime.ToString("F2");
                postponementFlag = true;
            }
        }
        else
        {
            if(timeFlag)
            {   
                state = "invisible";
                if(state != old_state)
                {
                    failedTime = failedTime + time.ToString("F2") + ", ";
                }
                old_state = "invisible";

                if(postponementFlag)
                {
                    StartCoroutine("postponement");
                    //猶予中は見えてるのでvisibleTimeに加算
                    visibleTime += Time.deltaTime;
                    Text_visibleTime.GetComponent<Text>().text = visibleTime.ToString("F2");
                }
                else
                {
                    rawimage.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);
                    invisibleTime += Time.deltaTime;
                    Text_invisibleTime.GetComponent<Text>().text = invisibleTime.ToString("F2");
                }
            }
        }

        if(timeFlag)
        {
            time += Time.deltaTime;
            Text_time.GetComponent<Text>().text = time.ToString("F2");
        }

        if(time > 10 && !playable)
        {
            if(!rI_video.isPlaying)
            {
                timeFlag = false;
                panel_finish.SetActive(true);
                isFinished = true;
            }
        }

    }

    IEnumerator postponement()//指が離れてから2秒の猶予をつける
    {
        yield return new WaitForSeconds(2);
        postponementFlag = false;
    }

    public static bool AisFinished()
    {
        return isFinished;
    }

    public static void setAisFinished()
    {
        isFinished = false;
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
    }

    public void NextButtonClicked()
    {
        string s = PlayerPrefs.GetString("data2", "") + string.Format(SceneManager.GetActiveScene().name + " -> 見えていた時間:{0:000.00}s, 見えていなかった時間:{1:000.00}s, タッチが離れた時刻:{2} ", new String[] {visibleTime.ToString(), invisibleTime.ToString(), failedTime});
        PlayerPrefs.SetString("data2", s);
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
