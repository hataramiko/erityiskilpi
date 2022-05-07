using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    //public bool disposable;
    public bool isLetter;
    public bool isFirstDigit;

    private int minValue;
    private int maxValue;
    private int characterValue;
    private char charToDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        if(isLetter == true)
        {
            maxValue = 28;
        }
        else
        {
            maxValue = 9;
        }

        if(isFirstDigit == true)
        {
            minValue = 1;
        }
        else
        {
            minValue = 0;
        }

        characterValue = minValue;

        Debug.Log("Start value: " + characterValue);
    }

    public void increaseValue()
    {
        characterValue++;

        if(characterValue > maxValue)
        {
            characterValue = minValue;
        }

        Debug.Log("Value increased: " + characterValue);
    }

    public void decreaseValue()
    {
        characterValue--;

        if(characterValue < minValue)
        {
            characterValue = maxValue;
        }

        Debug.Log("Value decreased: " + characterValue);
    }

    public void displayValue()
    {
        /* 
        koodin pätkä joka muuttaa int arvon joko muotoon char tai string,
        tämä tekstiarvo sitten TMPro sylkee näkyvään muotoon.
        */
    }

    // Ideana että muuttaa numeroarvon kirjaimeksi
    public void digitToLetter()
    {
        Debug.Log("This is a letter.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
        0  = A
        1  = B
        2  = C
        3  = D
        4  = E
        5  = F
        6  = G
        7  = H
        8  = I
        9  = J
        10 = K
        11 = L
        12 = M
        13 = N
        14 = O
        15 = P
        16 = Q
        17 = R
        18 = S
        19 = T
        20 = U
        21 = V
        22 = W
        23 = X
        24 = Y
        25 = Z
        26 = Å
        27 = Ä
        28 = Ö
    */
}
