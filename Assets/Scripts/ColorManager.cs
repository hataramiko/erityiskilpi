using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public BaseSelection _base;

    private Color activeColor;
    
    // Start is called before the first frame update
    void Start()
    {
        SetColor();
    }

    public void CheckBaseColor()
    {
        if(_base.isBlack == true)
        {
            activeColor = Color.white;
        }
        else
        {
            activeColor = Color.black;
        }
    }

    public void SetColor()
    {
        CheckBaseColor();

        GetComponent<Image>().color = activeColor;
    }

    // Update is called once per frame
    void Update()
    {
        SetColor();
    }
}
