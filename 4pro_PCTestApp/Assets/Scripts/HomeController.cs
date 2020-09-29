using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class HomeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startButtonClicked()
    {
        SceneManager.LoadScene("PCTest1");
    }

    public void homeButtonClicked()
    {
        SceneManager.LoadScene("Home");
    }
}
