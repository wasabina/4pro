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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void URButtonClicked()
    {
        SceneManager.LoadScene("URMode");
    }

    public void PCButtonClicked()
    {
        SceneManager.LoadScene("PCMode");
    }
}
