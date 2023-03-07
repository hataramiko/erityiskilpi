using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateManager : MonoBehaviour
{
    [Header("Preferences")]
    public int defaultBase;
    /*
    public bool notUsingA;
    public bool notUsing2;
    public bool notUsing3;
    */

    [Space(10)]
    public GameObject[] bases;

    [Header("Base Variables")]
    public bool isEuro;
    public bool isTall;
    public bool isLong;
    public bool isSmall;
    public bool isShort;
    public bool isBlack;

    [Header("Plate Components")]
    public GameObject contents;
    // Parent Objects + Hyphen
    public GameObject letters;
    public GameObject digits;
    public GameObject hyphen;
    // Child Objects, i.e. individual letters and digits
    public GameObject letterA;
    public GameObject letterB;
    public GameObject letterC;
    public GameObject digit1;
    public GameObject digit2;
    public GameObject digit3;

    [Header("Position Values")]
    public Vector2 defaultPosition;
    public Vector3 defaultScale;
    public Vector2 euroOffset;
    public Vector3 smallScale;
    public Vector2 positionRight1;
    public Vector2 positionRight2;
    public Vector2 positionLeft1;

    [Header("Position Values, (isTall == true)")]
    public Vector2 lettersDefaultPosition;
    public Vector2 digitsDefaultPosition;
    public Vector2 lettersPosition0;
    public Vector2 lettersPosition1;
    public Vector2 digitsPosition0;
    public Vector2 digitsPosition1;
    public Vector2 digitsPosition2;

    //RectTransform contents;
    int activeBase;
    private bool flip;

    // Start is called before the first frame update
    void Start()
    {
        activeBase = defaultBase;
        DisplayBase();
    }

    public void DisplayBase()
    {
        for(int i = 0; i < bases.Length; i++)
        {
            bases[i].SetActive(false);
        }

        bases[activeBase].SetActive(true);

        // Checks active base and sets variables accordingly
        CheckBase();
        // Checks 
        Transform();
    }

    public void CheckBase()
    {
        // Checks for Euroband
        if(activeBase <= 1)
        {
            isEuro = true;
        }
        else
        {
            isEuro = false;
        }

        // Checks if base is tall
        if(activeBase == 1)
        {
            isTall = true;
        }
        else
        {
            isTall = false;
        }

        // Checks if base is small
        if(activeBase == 3 || activeBase == 6)
        {
            isSmall = true;
        }
        else
        {
            isSmall = false;
        }

        // Checks if base is short
        if(activeBase == 4 || activeBase == 7)
        {
            isShort = true;
        }
        else
        {
            isShort = false;
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
        if(activeBase >= 5)
        {
            isBlack = true;
        }
        else
        {
            isBlack = false;
        }
    }

    // Checks the type of plate before applying transformation
    public void Transform()
    {
        if(isTall == true)
        {
            hyphen.SetActive(false);

            // Sets default values to Parent before applying transformation to Children to avoid unwanted offset
            contents.GetComponent<RectTransform>().localPosition = defaultPosition;
            contents.GetComponent<RectTransform>().localScale = defaultScale;

            AlignVertical();
        }
        else
        {
            hyphen.SetActive(true);

            // Sets Children to default position to avoid unwanted stacking
            letters.GetComponent<RectTransform>().localPosition = lettersDefaultPosition;
            digits.GetComponent<RectTransform>().localPosition = digitsDefaultPosition;

            AlignHorizontal();
        }
    }

    // Positions Contents based on active characters and base
    public void AlignHorizontal()
    {
        Vector2 position;

        if(isShort == true && letterA.activeSelf == true && digit3.activeSelf == true)
        {
            digit3.SetActive(false);

            if(digit3.activeSelf != true && flip == true)
            {
                letterA.SetActive(false);
                digit3.SetActive(true);
                flip = false;
            }
        }

        // Centers Contents relative to Base based on active characters
        if(letterA.activeSelf == false && digit2.activeSelf != true) // BC-1
        {
            position = positionRight1;
        }
        else if(letterA.activeSelf == false && digit3.activeSelf != true) // BC-12
        {
            position = defaultPosition;
        }
        else if(letterA.activeSelf == false) // BC-123
        {
            position = positionLeft1;
        }
        else if(digit2.activeSelf != true) // ABC-1
        {
            position = positionRight2;
        }
        else if(digit3.activeSelf != true) // ABC-12
        {
            position = positionRight1;
        }
        else // ABC-123
        {
            position = defaultPosition;
        }

        // 
        if(isSmall == true)
        {
            contents.GetComponent<RectTransform>().localScale = smallScale;

            position = position * smallScale;
        }
        else
        {
            contents.GetComponent<RectTransform>().localScale = defaultScale;
        }

        // Adds offset to position if Base is 
        if(isEuro == true && isTall != true)
        {
            position = position + euroOffset;
        }

        contents.GetComponent<RectTransform>().localPosition = position;
    }

    // Positions Letters above Digits and adjusts horizontal position based on active characters
    public void AlignVertical()
    {
        // Sets position of Letters
        if(letterA.activeSelf == false) // BC
        {
            letters.GetComponent<RectTransform>().localPosition = lettersPosition1;
        }
        else // ABC
        {
            letters.GetComponent<RectTransform>().localPosition = lettersPosition0;
        }

        // Sets position of Digits
        if(digit2.activeSelf != true) // 1
        {
            digits.GetComponent<RectTransform>().localPosition = digitsPosition2;
        }
        else if(digit3.activeSelf != true) // 12
        {
            digits.GetComponent<RectTransform>().localPosition = digitsPosition1;
        }
        else // 123
        {
            digits.GetComponent<RectTransform>().localPosition = digitsPosition0;
        }
    }

    public void SelectBase(int n)
    {
        activeBase = n;
        DisplayBase();
    }

    public void BaseArrayIncrease()
    {
        activeBase++;

        if(activeBase >= bases.Length)
        {
            activeBase = 0;
        }

        Debug.Log("Current value in 'bases' array: " + activeBase);
        DisplayBase();
    }

    public void SwitchEnds()
    {
        flip = true;
    }

    // Update is called once per frame
    void Update()
    {
        Transform();
    }
}
