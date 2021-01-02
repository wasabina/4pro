using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DOController : MonoBehaviour
{

    public Text text_data;
    public GameObject panel_reset;
    public InputField inputField;//pass入力
    private string password = "g17916im"; //初期化のパスワード

    // Start is called before the first frame update
    void Start()
    {
        panel_reset.SetActive(false);
        text_data.text = PlayerPrefs.GetString("data2", "");//PCのデータはdataへ
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void backButtonClicked()
    {
        SceneManager.LoadScene("Home");
    }

    public void resetButtonClicked()
    {
        panel_reset.SetActive(true);
    }

    public void inputText()
    {
        //Debug.Log(password);
        if (inputField.text == password)
        {
            PlayerPrefs.DeleteKey("data2");
            text_data.text = PlayerPrefs.GetString("data2", "");
            inputField.text = "";
            panel_reset.SetActive(false);
        }
        else
        {
            inputField.text = "";
            panel_reset.SetActive(false);
        }
    }
}
