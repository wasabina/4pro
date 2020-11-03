using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OthersController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void homeButtonClicked()//End->Homeのみ
    {
        string s = PlayerPrefs.GetString("data", "") + "\n";
        PlayerPrefs.SetString("data", s);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Home");
    }

    public void backButtonClicked()
    {
        SceneManager.LoadScene("Home");
    }
}
