using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/*
    Handles UI Toolkit based UI interactions
*/
[RequireComponent(typeof(UIDocument))]
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

    //
    [SerializeField] NavigationBar NavBar;

    UIDocument m_UIDocument;
    public UIDocument UIDocument => m_UIDocument;
    //

    const int defaultMode = 0;
    int activeMode;
    const int editModeValue = 1;
    const int editModeCount = 2;
    int activeEditMode;

    // UI Buttons
    Button navBarFirst;
    Button navBarSecond;
    Button navBarThird;

    Button letterAIncrease;
    Button letterADecrease;
    Button letterBIncrease;
    Button letterBDecrease;
    Button letterCIncrease;
    Button letterCDecrease;
    Button digit1Increase;
    Button digit1Decrease;
    Button digit2Increase;
    Button digit2Decrease;
    Button digit3Increase;
    Button digit3Decrease;

    Button letterADisable;
    Button letterAEnable;
    Button digit2Disable;
    Button digit2Enable;
    Button digit3Disable;
    Button digit3Enable;

    void OnEnable()
    {
        m_UIDocument = GetComponent<UIDocument>();
    }

    // Start is called before the first frame update
    void Start() // private void OnEnable???
    {
        //activeMode = defaultMode;
        //SetMode();

        var root = GetComponent<UIDocument>().rootVisualElement; // var == VisualElement???

        //baseSelectButton = root.Q<Button>("ButtonBaseSelect");

        navBarFirst = root.Q<Button>("nav-bar-button1");
        navBarSecond = root.Q<Button>("nav-bar-button2");
        //Button navBarThird = root.Q<Button>("nav-bar-button3");

        letterAIncrease = root.Q<Button>("chars-letter1__up");
        letterADecrease = root.Q<Button>("chars-letter1__down");
        letterBIncrease = root.Q<Button>("chars-letter2__up");
        letterBDecrease = root.Q<Button>("chars-letter2__down");
        letterCIncrease = root.Q<Button>("chars-letter3__up");
        letterCDecrease = root.Q<Button>("chars-letter3__down");
        digit1Increase = root.Q<Button>("chars-digit1__up");
        digit1Decrease = root.Q<Button>("chars-digit1__down");
        digit2Increase = root.Q<Button>("chars-digit2__up");
        digit2Decrease = root.Q<Button>("chars-digit2__down");
        digit3Increase = root.Q<Button>("chars-digit3__up");
        digit3Decrease = root.Q<Button>("chars-digit3__down");

        letterADisable = root.Q<Button>("chars-letter1__remove");
        letterAEnable = root.Q<Button>("chars-letter1__add");
        digit2Disable = root.Q<Button>("chars-digit2__remove");
        digit2Enable = root.Q<Button>("chars-digit2__add");
        digit3Disable = root.Q<Button>("chars-digit3__remove");
        digit3Enable = root.Q<Button>("chars-digit3__add");

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

        // Vihree nappi piiloon alussa testing testing
        letterAEnable.style.display = DisplayStyle.None;
        digit3Enable.style.display = DisplayStyle.None;
        digit2Enable.style.display = DisplayStyle.None;
        // ja punanen (digit2)
        digit2Disable.style.display = DisplayStyle.None;
        // ja loput punaset
        letterADisable.style.display = DisplayStyle.None;
        digit3Disable.style.display = DisplayStyle.None;

        Initialize();
    }

    public void Initialize()
    {
        activeEditMode = 1;
    }

    public void SwitchEditMode()
    {
        if(activeEditMode == 2)
        {
            EnterCharCountMode();
        }
        else
        {
            ExitCharCountMode();
        }
    }

    public void EnterCharCountMode()
    {
        /*
        letterAEnable.style.display = DisplayStyle.None;
        digit3Enable.style.display = DisplayStyle.None;
        digit2Enable.style.display = DisplayStyle.None;

        digit2Disable.style.display = DisplayStyle.None;
        letterADisable.style.display = DisplayStyle.None;
        digit3Disable.style.display = DisplayStyle.None;

        letterAEnable.style.display = DisplayStyle.Flex;
        digit3Enable.style.display = DisplayStyle.Flex;
        digit2Enable.style.display = DisplayStyle.Flex;

        digit2Disable.style.display = DisplayStyle.Flex;
        letterADisable.style.display = DisplayStyle.Flex;
        digit3Disable.style.display = DisplayStyle.Flex;
        */

        if(plate.letterA == true)
        {
            letterADisable.style.display = DisplayStyle.Flex;
            //plate.letterA.SetActive(false);
        }

        if(plate.digit3 == true)
        {
            digit3Disable.style.display = DisplayStyle.Flex;
        }

        if(plate.digit2 == true && plate.digit3 != true)
        {
            digit2Disable.style.display = DisplayStyle.Flex;
        }
    }

    public void ExitCharCountMode()
    {
        letterAEnable.style.display = DisplayStyle.None;
        digit3Enable.style.display = DisplayStyle.None;
        digit2Enable.style.display = DisplayStyle.None;

        digit2Disable.style.display = DisplayStyle.None;
        letterADisable.style.display = DisplayStyle.None;
        digit3Disable.style.display = DisplayStyle.None;
    }


    public void DisableLetterA()
    {
        plate.letterA.SetActive(false);

        // Sets up/down buttons un-interactable
        letterAIncrease.SetEnabled(false);
        letterADecrease.SetEnabled(false);

        letterAEnable.style.display = DisplayStyle.Flex; // Displays the green Enable button
        letterADisable.style.display = DisplayStyle.None; // Hides the red Disable button
    }

    public void EnableLetterA()
    {
        plate.letterA.SetActive(true);

        // Recovers interaction in up/down buttons
        letterAIncrease.SetEnabled(true);
        letterADecrease.SetEnabled(true);

        letterADisable.style.display = DisplayStyle.Flex; // Displays the red Disable button
        letterAEnable.style.display = DisplayStyle.None; // Hides the green Enable button
    }

    public void DisableDigit2()
    {
        plate.digit2.SetActive(false);

        // Sets up/down buttons un-interactable
        digit2Increase.SetEnabled(false);
        digit2Decrease.SetEnabled(false);

        digit2Enable.style.display = DisplayStyle.Flex; // Displays the green Enable button
        digit2Disable.style.display = DisplayStyle.None; // Hides the red Disable button

        // Hides the green Enable button for the third digit
        digit3Enable.style.display = DisplayStyle.None;
    }

    public void EnableDigit2()
    {
        plate.digit2.SetActive(true);

        // Recovers interaction in up/down buttons
        digit2Increase.SetEnabled(true);
        digit2Decrease.SetEnabled(true);

        digit2Disable.style.display = DisplayStyle.Flex; // Displays the red Disable button
        digit2Enable.style.display = DisplayStyle.None; // Hides the green Enable button

        // Displays the green Enable button for the third digit
        digit3Enable.style.display = DisplayStyle.Flex;
    }

    public void DisableDigit3()
    {
        plate.digit3.SetActive(false);

        // Sets up/down buttons un-interactable
        digit3Increase.SetEnabled(false);
        digit3Decrease.SetEnabled(false);

        digit3Enable.style.display = DisplayStyle.Flex; // Displays the green Enable button
        digit3Disable.style.display = DisplayStyle.None; // Hides the red Disable button

        // Displays the green Enable button for the second digit
        digit2Disable.style.display = DisplayStyle.Flex;
    }

    public void EnableDigit3()
    {
        plate.digit3.SetActive(true);

        // Recovers interaction in up/down buttons
        digit3Increase.SetEnabled(true);
        digit3Decrease.SetEnabled(true);

        digit3Disable.style.display = DisplayStyle.Flex; // Displays the red Disable button
        digit3Enable.style.display = DisplayStyle.None; // Hides the green Enable button

        // Hides the red Disable button for the second digit
        digit2Disable.style.display = DisplayStyle.None;
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

        if(activeEditMode == defaultMode)
        {
            activeEditMode = editModeValue;
        }
        else if(activeEditMode == editModeValue)
        {
            activeEditMode = editModeCount;
        }
        else if(activeEditMode == editModeCount)
        {
            activeEditMode = editModeValue;
        }

        SwitchEditMode();
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

    /*
    void Update()
    {
        if(plate.digit3 != true && activeEditMode == 2)
        {
            digit3Disable.style.display = DisplayStyle.None;
            digit3Enable.style.display = DisplayStyle.Flex;
        }
    }*/
}
