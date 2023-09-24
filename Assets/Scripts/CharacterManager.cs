using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    "Character Controller"? Controls individual characters. 
*/
public class CharacterManager : MonoBehaviour
{
    public bool isFirstDigit; // Cannot be 0 or disposed of.
    public GameObject[] characters;

    private int value;
    private int minValue;
    private int maxValue;

    
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        DisplayCharacter();
    }

    public void IncreaseValue()
    {
        value++;

        if(value >= maxValue)
        {
            value = minValue;
        }

        DisplayCharacter();
    }

    public void DecreaseValue()
    {
        value--;

        if(value < minValue)
        {
            value = maxValue - 1;
        }

        DisplayCharacter();
    }

    public void DisplayCharacter()
    {
        //Debug.Log("This is being displayed: " + value);

        for(int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }

        characters[value].SetActive(true);
    }

    public void Initialize()
    {
        if(isFirstDigit == true)
        {
            minValue = 1;

            //disposable = false;
        }
        else
        {
            minValue = 0;
        }

        value = minValue;

        maxValue = characters.Length;

        /*
        if(isFirstLetter == false)
        {
            disposable = false;
        }
        */
    }

    public void Dispose()
    {
        Debug.Log("In the bin.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
