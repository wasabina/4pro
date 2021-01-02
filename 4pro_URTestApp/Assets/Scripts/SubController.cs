using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SubController : MonoBehaviour
{
    private int fingerNum = 0;
    public GameObject bm; //ButtonManager
    private int requiredFingerNum;
    public Text text_touchedNum;
    public GameObject text_judge;


    // Start is called before the first frame update
    void Start()
    {
        requiredFingerNum = 10;
        text_touchedNum.text = "0個のボタンに触れています";
        text_judge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        fingerNum = bm.GetComponent<ButtonManager>().NumOfTouchButtons;
        text_touchedNum.text = fingerNum + "個のボタンに触れています";

        if (fingerNum >= requiredFingerNum)
        {
            text_judge.SetActive(true);
        }
    }

    public void backButtonClicked()
    {
        SceneManager.LoadScene("Home");
    }
}