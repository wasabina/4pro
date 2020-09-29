using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class HomeController : MonoBehaviour
{
    DateTime TodayNow;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("buttonSize");
        TodayNow = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startButtonClicked()
    {
        string s = PlayerPrefs.GetString("data", "") + "\n" + TodayNow.Year.ToString() + "/" + TodayNow.Month.ToString() + "/" + TodayNow.Day.ToString() + " " + DateTime.Now.ToLongTimeString() + "\n";
        PlayerPrefs.SetString("data", s);
        PlayerPrefs.Save();
        SceneManager.LoadScene("PCTest1");
    }

    public void homeButtonClicked()
    {
        string s = PlayerPrefs.GetString("data", "") + "\n";
        PlayerPrefs.SetString("data", s);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Home");
    }

    public void developerOptionsButtonClicked()
    {
        SceneManager.LoadScene("Data");
    }
}
