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

    private Color activeColor;
    
    // Start is called before the first frame update
    void Start()
    {
        SetColor();
    }

    public void SetColor()
    {
        CheckBaseColor();

        GetComponent<Image>().color = activeColor;
    }

    public void CheckBaseColor()
    {
        if(plate.isBlack == true)
        {
            activeColor = Color.white;
        }
        else
        {
            activeColor = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetColor();
    }
}
