using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    Button Button1, Button2, Button3, Button4, Button5, Button6;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.isEditor)
        {
            Debug.Log("<color=red>エディタで実行中.</color>");
        }
        else
        {
            Debug.Log("<color=aqua>実機で実行中.</color>");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //ButtonコンポーネントOnClickリスト追加用(Buttonコンポーネントが必要)
    public void Button1Clicked()
    {
        Debug.Log("<color=aqua>Button1 Clicked.</color>");
    }

    public void Button2Clicked()
    {
        Debug.Log("<color=aqua>Button2 Clicked.</color>");
    }

    public void Button3Clicked()
    {
        Debug.Log("<color=aqua>Button3 Clicked.</color>");
    }

    public void Button4Clicked()
    {
        Debug.Log("<color=aqua>Button4 Clicked.</color>");
    }

    public void Button5Clicked()
    {
        Debug.Log("<color=aqua>Button5 Clicked.</color>");
    }

    public void Button6Clicked()
    {
        Debug.Log("<color=aqua>Button6 Clicked.</color>");
    }


}
