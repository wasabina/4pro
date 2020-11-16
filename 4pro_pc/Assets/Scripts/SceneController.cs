using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (Application.isEditor)
        {
            Debug.Log("<color=red>エディタで実行中.</color>");
        }
        else
        {
            Debug.Log("<color=aqua>実機で実行中.</color>");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SettingButtonClicked()
    {
        SceneManager.LoadScene("SettingScene");
    }
}
