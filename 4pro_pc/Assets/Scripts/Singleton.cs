using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Singleton : MonoBehaviour
{

    private static Singleton instance = null;
    public static Singleton Instance
    {
        get { return Singleton.instance; }
    }



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}