using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class URController : MonoBehaviour
{
    public Button button_end;
    private bool endFlag;
    private Sprite s_end, s_back;
    public GameObject panel_end;
    public Text text_alert;
    public Text text_hand;
    public Text checkA;
    public Text checkB;
    public Text checkC;
    public Text checkD;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("buttonSize");
        endFlag = false;
        panel_end.SetActive(false);
        s_end = Resources.Load<Sprite>("icon_end");
        s_back = Resources.Load<Sprite>("icon_back");
        text_alert.text = "";
        if (HomeController.getIsLeftHanded() == false)
        {
            text_hand.text = "利き手：　右";
        }
        else
        {
            text_hand.text = "利き手：　左";
        }

        if(UR_A.AisFinished())
        {
            checkA.text = "済";
            checkA.color = new Color(187.0f/255.0f, 136.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
        public void startButtonClicked()
        {
            if (iF_name.text == "")
            {
                text_alert.text = "お名前を入力してください";
            }
            else
            {
                string s = PlayerPrefs.GetString("data2", "") + "\n" + TodayNow.Year.ToString() + "/" + TodayNow.Month.ToString() + "/" + TodayNow.Day.ToString() + " " + DateTime.Now.ToLongTimeString() + "\n" + "NAME: " + iF_name.text + "\n";
                PlayerPrefs.SetString("data2", s);
                PlayerPrefs.Save();
                SceneManager.LoadScene("URTest1");
            }
        }*/


    public void endOptionButtonClicked()
    {
        if (endFlag == false)
        {
            var image = button_end.GetComponent<Image>();
            image.sprite = s_back;
            panel_end.SetActive(true);
            endFlag = true;
        }
        else
        {
            var image = button_end.GetComponent<Image>();
            image.sprite = s_end;
            panel_end.SetActive(false);
            endFlag = false;
        }
    }

    public void endClicked()
    {
        string s = PlayerPrefs.GetString("data2", "") + "----中断----" + "\n";
        PlayerPrefs.SetString("data2", s);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Home");
    }

    public void nextClicked()
    {
        if (!true)
        {
            text_alert.text = "未実施のパターンがあります";
        }
        else
        {
            SceneManager.LoadScene("End");
        }
    }

    public void A()
    {
        SceneManager.LoadScene("A");
    }
}
