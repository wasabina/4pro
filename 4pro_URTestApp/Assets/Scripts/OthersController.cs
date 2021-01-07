using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OthersController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void homeButtonClicked()//End->Homeのみ
    {
        UR_A.setisFinished();
        UR_B.setisFinished();
        UR_C.setisFinished();
        UR_D.setisFinished();
        string s = PlayerPrefs.GetString("data2", "") + "--------\n";
        PlayerPrefs.SetString("data2", s);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Home");
    }
}
