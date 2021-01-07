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

        if(UR_A.getisFinished())
        {
            checkA.text = "済";
            checkA.color = new Color(187.0f/255.0f, 136.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f);
        }
        if(UR_B.getisFinished())
        {
            checkB.text = "済";
            checkB.color = new Color(187.0f/255.0f, 136.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f);
        }
        if(UR_C.getisFinished())
        {
            checkC.text = "済";
            checkC.color = new Color(187.0f/255.0f, 136.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f);
        }
        if(UR_D.getisFinished())
        {
            checkD.text = "済";
            checkD.color = new Color(187.0f/255.0f, 136.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

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
        if (UR_A.getisFinished() && UR_B.getisFinished() && UR_C.getisFinished() && UR_D.getisFinished())
        {
            SceneManager.LoadScene("End");
        }
        else
        {
            text_alert.text = "未実施のパターンがあります";
        }
    }

    public void A()
    {
        SceneManager.LoadScene("A");
    }

    public void B()
    {
        SceneManager.LoadScene("B");
    }

    public void C()
    {
        SceneManager.LoadScene("C");
    }

    public void D()
    {
        SceneManager.LoadScene("D");
    }
}
