using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PCSetting : MonoBehaviour
{
    public Slider buttonSize;


    // Start is called before the first frame update
    void Start()
    {
        buttonSize.value = PlayerPrefs.GetFloat("buttonSize", 1.0f);

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
        SceneManager.LoadScene("PCMode");
    }

    public void SaveButtonSize()
    {
        PlayerPrefs.SetFloat("buttonSize", buttonSize.value);
        PlayerPrefs.Save();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("buttonSize");
        //PlayerPrefs.DeleteAll();

        buttonSize.value = PlayerPrefs.GetFloat("buttonSize", 1.0f);

        SaveButtonSize();
    }

}
