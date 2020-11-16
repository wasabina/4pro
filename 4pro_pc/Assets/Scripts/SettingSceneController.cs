using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SettingSceneController : MonoBehaviour
{
    public InputField InputField_h, InputField_m, InputField_s;
    public Dropdown buttonNum;
    public Slider buttonSize;


    // Start is called before the first frame update
    void Start()
    {
        InputField_h.text = PlayerPrefs.GetString("InputField_h", "0");
        InputField_m.text = PlayerPrefs.GetString("InputField_m", "30");
        InputField_s.text = PlayerPrefs.GetString("InputField_s", "0");
        buttonNum.value = PlayerPrefs.GetInt("requiredButtonNum", 9);
        buttonSize.value = PlayerPrefs.GetFloat("buttonSize", 1.0f);

        SaveAvailableTime();
        SaveButtonNum();
        SaveButtonSize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackButtonClicked()
    {
        PlayerPrefs.Save();
        Debug.Log("save");
        SceneManager.LoadScene("SampleScene");
    }

    public void SaveAvailableTime()
    {
        PlayerPrefs.SetString("InputField_h", InputField_h.text);
        PlayerPrefs.SetString("InputField_m", InputField_m.text);
        PlayerPrefs.SetString("InputField_s", InputField_s.text);
        //PlayerPrefs.Save();
    }

    public void SaveButtonNum()
    {
        PlayerPrefs.SetInt("requiredButtonNum", buttonNum.value);
        //PlayerPrefs.Save();
    }

    public void SaveButtonSize()
    {
        PlayerPrefs.SetFloat("buttonSize", buttonSize.value);
        //PlayerPrefs.Save();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        InputField_h.text = PlayerPrefs.GetString("InputField_h", "0");
        InputField_m.text = PlayerPrefs.GetString("InputField_m", "30");
        InputField_s.text = PlayerPrefs.GetString("InputField_s", "0");
        buttonNum.value = PlayerPrefs.GetInt("requiredButtonNum", 9);
        buttonSize.value = PlayerPrefs.GetFloat("buttonSize", 1.0f);

        SaveAvailableTime();
        SaveButtonNum();
        SaveButtonSize();
    }

}
