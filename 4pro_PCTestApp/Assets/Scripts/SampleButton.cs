using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{
    private Image button;
    public Slider buttonSize;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Image>();
        float size = buttonSize.value;
        button.transform.localScale = new Vector3(size, size, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float size = buttonSize.value;
        button.transform.localScale = new Vector3(size, size, 1.0f);
    }
}
