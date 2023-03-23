using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/*
    Handles UI Toolkit based UI interactions
*/
public class UIManager : MonoBehaviour
{
    public PlateManager plate;
    
    [Header("Characters")]
    public CharacterManager letterA;
    public CharacterManager letterB;
    public CharacterManager letterC;
    public CharacterManager digit1;
    public CharacterManager digit2;
    public CharacterManager digit3;
    
    [Space(15)]
    public GameObject[] modes;

    //int defaultMode = 0;
    int activeMode;

    // Start is called before the first frame update
    void Start() // private void OnEnable???
    {
        //activeMode = defaultMode;
        //SetMode();

        var root = GetComponent<UIDocument>().rootVisualElement; // var == VisualElement???

        //baseSelectButton = root.Q<Button>("ButtonBaseSelect");

        Button navBarFirst = root.Q<Button>("nav-bar-button1");
        Button navBarSecond = root.Q<Button>("nav-bar-button2");
        //Button navBarThird = root.Q<Button>("nav-bar-button3");

        Button letterAIncrease = root.Q<Button>("chars-letter1__up");
        Button letterADecrease = root.Q<Button>("chars-letter1__down");
        Button letterBIncrease = root.Q<Button>("chars-letter2__up");
        Button letterBDecrease = root.Q<Button>("chars-letter2__down");
        Button letterCIncrease = root.Q<Button>("chars-letter3__up");
        Button letterCDecrease = root.Q<Button>("chars-letter3__down");
        Button digit1Increase = root.Q<Button>("chars-digit1__up");
        Button digit1Decrease = root.Q<Button>("chars-digit1__down");
        Button digit2Increase = root.Q<Button>("chars-digit2__up");
        Button digit2Decrease = root.Q<Button>("chars-digit2__down");
        Button digit3Increase = root.Q<Button>("chars-digit3__up");
        Button digit3Decrease = root.Q<Button>("chars-digit3__down");

        Button letterADisable= root.Q<Button>("chars-letter1__remove");
        Button letterAEnable = root.Q<Button>("chars-letter1__add");
        Button digit2Disable= root.Q<Button>("chars-digit2__remove");
        Button digit2Enable = root.Q<Button>("chars-digit2__add");
        Button digit3Disable= root.Q<Button>("chars-digit3__remove");
        Button digit3Enable = root.Q<Button>("chars-digit3__add");

        navBarFirst.clicked += () => EnterEditMode();
        navBarSecond.clicked += () => EnterBaseSelect();
        //navBarThird.clicked += () => BaseSelectClick();

        letterAIncrease.clicked += () => letterA.IncreaseValue();
        letterADecrease.clicked += () => letterA.DecreaseValue();
        letterBIncrease.clicked += () => letterB.IncreaseValue();
        letterBDecrease.clicked += () => letterB.DecreaseValue();
        letterCIncrease.clicked += () => letterC.IncreaseValue();
        letterCDecrease.clicked += () => letterC.DecreaseValue();
        digit1Increase.clicked += () => digit1.IncreaseValue();
        digit1Decrease.clicked += () => digit1.DecreaseValue();
        digit2Increase.clicked += () => digit2.IncreaseValue();
        digit2Decrease.clicked += () => digit2.DecreaseValue();
        digit3Increase.clicked += () => digit3.IncreaseValue();
        digit3Decrease.clicked += () => digit3.DecreaseValue();

        letterADisable.clicked += () => DisableLetterA();
        letterAEnable.clicked += () => EnableLetterA();
        digit2Disable.clicked += () => DisableDigit2();
        digit2Enable.clicked += () => EnableDigit2();
        digit3Disable.clicked += () => DisableDigit3();
        digit3Enable.clicked += () =>  EnableDigit3();
    }

    public void DisableLetterA()
    {
        plate.letterA.SetActive(false);
    }

    public void EnableLetterA()
    {
        plate.letterA.SetActive(true);
    }

    public void DisableDigit2()
    {
        plate.digit2.SetActive(false);
    }

    public void EnableDigit2()
    {
        plate.digit2.SetActive(true);
    }

    public void DisableDigit3()
    {
        plate.digit3.SetActive(false);
    }

    public void EnableDigit3()
    {
        plate.digit3.SetActive(true);
    }

    public void SetMode()
    {
        //
        for(int i = 0; i < modes.Length; i++)
        {
            modes[i].SetActive(false);
        }

        modes[activeMode].SetActive(true);
        //

        if(activeMode == 1)
        {

        }

        Debug.Log("Current mode: " + activeMode);
    }

    public void EnterEditMode()
    {
        Debug.Log("MERKIT");
    }

    public void EnterBaseSelect()
    {
        Debug.Log("POHJAT");

        plate.BaseArrayIncrease(); // Changes base by increasing array value by 1
    }

    public void ArrayValueClick()
    {
        activeMode = 0;

        SetMode();
    }

    public void AddRemoveClick()
    {
        activeMode = 1;

        SetMode();
    }

    public void BaseSelectClick()
    {
        activeMode = 2;

        SetMode();
        plate.BaseArrayIncrease(); // Changes base by increasing array value by 1
    }
}
