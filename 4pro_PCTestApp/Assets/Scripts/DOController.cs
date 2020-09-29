using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DOController : MonoBehaviour
{

    public Text text_data;

    // Start is called before the first frame update
    void Start()
    {
        text_data.text = PlayerPrefs.GetString("data", "");
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
        PlayerPrefs.DeleteAll();
        text_data.text = PlayerPrefs.GetString("data", "");
    }
}
