using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSelection : MonoBehaviour
{
    public int defaultBase;
    public GameObject[] bases;

    private int active;

    public bool isEuro;
    public bool isTall;
    public bool isLong;
    public bool isShort;
    public bool isSmall;
    public bool isBlack;
    public bool canFitSix;

    // Start is called before the first frame update
    void Start()
    {
        active = defaultBase;

        Display();
    }

    public void Display()
    {
        for(int i = 0; i < bases.Length; i++)
        {
            bases[i].SetActive(false);
        }

        SetBaseProperties();

        bases[active].SetActive(true);
    }

    public void Select(int selection)
    {
        active = selection;

        Display();
    }

    public void SetBaseProperties()
    {
        // Checks if base has Euroband
        if(active <= 1)
        {
            isEuro = true;
        }
        else
        {
            isEuro = false;
        }

        // Checks if base is tall
        if(active == 1)
        {
            isTall = true;
        }
        else
        {
            isTall = false;
        }

        // Checks if base is short
        if(active == 3 || active == 6)
        {
            isShort = true;
        }
        else
        {
            isShort = false;
        }

        // Checks if base is small
        if(active == 4 || active == 7)
        {
            isSmall = true;
        }
        else
        {
            isSmall = false;
        }

        // Checks if base is long
        if(isTall == true || isShort == true || isSmall == true)
        {
            isLong = false;
        }
        else
        {
            isLong = true;
        }

        // Checks if base is black
        if(active >= 5)
        {
            isBlack = true;
        }
        else
        {
            isBlack = false;
        }

        // Checks if base can accomodate 6 characters
        if(isShort != true)
        {
            canFitSix = true;
        }
        else
        {
            canFitSix = false;
        }

        /*
        Debug.Log("Base has Euroband: " + isEuro);
        Debug.Log("Base is tall: " + isTall);
        Debug.Log("Base is short: " + isShort);
        Debug.Log("Base is small: " + isSmall);
        Debug.Log("Base is black: " + isBlack);
        Debug.Log("Can accomodate 6 characters: " + canFitSix);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
