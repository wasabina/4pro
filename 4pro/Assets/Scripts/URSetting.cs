using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class URSetting : MonoBehaviour
{
    public Slider buttonSize;
    public Dropdown buttonLayout;

    // Start is called before the first frame update
    void Start()
    {
        buttonSize.value = PlayerPrefs.GetFloat("buttonSize", 1.0f);
        buttonLayout.value = PlayerPrefs.GetInt("buttonSize", 0);

        SaveButtonSize();
        SaveButtonLayout();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackButtonClicked()
    {
        PlayerPrefs.Save();
        Debug.Log("save");
        SceneManager.LoadScene("URMode");
    }

    public void SaveButtonSize()
    {
        PlayerPrefs.SetFloat("buttonSize", buttonSize.value);
    }

    public void SaveButtonLayout()
    {
        PlayerPrefs.SetInt("buttonLayout", buttonLayout.value);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("buttonSize");
        PlayerPrefs.DeleteKey("buttonLayout");

        buttonSize.value = PlayerPrefs.GetFloat("buttonSize", 1.0f);
        buttonLayout.value = PlayerPrefs.GetInt("buttonSize", 0);

        SaveButtonSize();
        SaveButtonLayout();
    }
}
