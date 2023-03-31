using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Changes color of characters according to the color of active base.
*/
public class ColorManager : MonoBehaviour
{
    public PlateManager plate;

    Color _activeColor;
    
    void Start()
    {
        SetColor();
    }

    public void SetColor()
    {
        CheckBaseColor();

        GetComponent<Image>().color = _activeColor;
    }

    public void CheckBaseColor()
    {
        if(plate.isBlack == true)
        {
            _activeColor = Color.white;
        }
        else
        {
            _activeColor = Color.black;
        }
    }

    void Update()
    {
        SetColor();
    }
}
