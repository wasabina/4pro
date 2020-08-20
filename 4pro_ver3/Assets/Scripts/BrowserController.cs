using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserController : MonoBehaviour
{
    private int fingerNum = 0;
    public GameObject bm; //ButtonManager

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        fingerNum = bm.GetComponent<ButtonManager>().NumOfTouchButtons;
        if (fingerNum > 5)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
