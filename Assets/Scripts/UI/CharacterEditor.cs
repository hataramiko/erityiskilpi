using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterEditor : UIComponent
{
    [Header("Characters")]
    [Tooltip("GameObjects for each individual character.")]
    public GameObject letterA;
    public GameObject letterB;
    public GameObject letterC;
    public GameObject digit1;
    public GameObject digit2;
    public GameObject digit3;

    // Letters
    const string LETTER_A_BUTTON_UP = "chars-letter1__up";
    const string LETTER_A_BUTTON_DOWN = "chars-letter1__down";
    const string LETTER_A_BUTTON_ADD = "chars-letter1__add";
    const string LETTER_A_BUTTON_REMOVE = "chars-letter1__remove";
    const string LETTER_B_BUTTON_UP = "chars-letter2__up";
    const string LETTER_B_BUTTON_DOWN = "chars-letter2__down";
    const string LETTER_C_BUTTON_UP = "chars-letter3__up";
    const string LETTER_C_BUTTON_DOWN = "chars-letter3__down";

    // Digits
    const string DIGIT_1_BUTTON_UP = "chars-digit1__up";
    const string DIGIT_1_BUTTON_DOWN = "chars-digit1__down";
    const string DIGIT_2_BUTTON_UP = "chars-digit2__up";
    const string DIGIT_2_BUTTON_DOWN = "chars-digit2__down";
    const string DIGIT_2_BUTTON_ADD = "chars-digit2__add";
    const string DIGIT_2_BUTTON_REMOVE = "chars-digit2__remove";
    const string DIGIT_3_BUTTON_UP = "chars-digit3__up";
    const string DIGIT_3_BUTTON_DOWN = "chars-digit3__down";
    const string DIGIT_3_BUTTON_ADD = "chars-digit3__add";
    const string DIGIT_3_BUTTON_REMOVE = "chars-digit3__remove";

    // Toolbar
    const string SWITCH_MODE_BUTTON = "characters-button-switch-mode";

    Button _letterAUp;
    Button _letterADown;
    Button _letterAAdd;
    Button _letterARemove;
    Button _letterBUp;
    Button _letterBDown;
    Button _letterCUp;
    Button _letterCDown;

    Button _digit1Up;
    Button _digit1Down;
    Button _digit2Up;
    Button _digit2Down;
    Button _digit2Add;
    Button _digit2Remove;
    Button _digit3Up;
    Button _digit3Down;
    Button _digit3Add;
    Button _digit3Remove;

    Button _switchModeButton;

    CharacterManager _letterAManager;
    CharacterManager _letterBManager;
    CharacterManager _letterCManager;
    CharacterManager _digit1Manager;
    CharacterManager _digit2Manager;
    CharacterManager _digit3Manager;

    protected override void Awake()
    {
        base.Awake();

        GetCharacterManagers();
        DisableAddRemoveButtons();
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        _letterAUp = _root.Q<Button>(LETTER_A_BUTTON_UP);
        _letterADown = _root.Q<Button>(LETTER_A_BUTTON_DOWN);
        _letterAAdd = _root.Q<Button>(LETTER_A_BUTTON_ADD);
        _letterARemove = _root.Q<Button>(LETTER_A_BUTTON_REMOVE);
        _letterBUp = _root.Q<Button>(LETTER_B_BUTTON_UP);
        _letterBDown = _root.Q<Button>(LETTER_B_BUTTON_DOWN);
        _letterCUp = _root.Q<Button>(LETTER_C_BUTTON_UP);
        _letterCDown = _root.Q<Button>(LETTER_C_BUTTON_DOWN);

        _digit1Up = _root.Q<Button>(DIGIT_1_BUTTON_UP);
        _digit1Down = _root.Q<Button>(DIGIT_1_BUTTON_DOWN);
        _digit2Up = _root.Q<Button>(DIGIT_2_BUTTON_UP);
        _digit2Down = _root.Q<Button>(DIGIT_2_BUTTON_DOWN);
        _digit2Add = _root.Q<Button>(DIGIT_2_BUTTON_ADD);
        _digit2Remove = _root.Q<Button>(DIGIT_2_BUTTON_REMOVE);
        _digit3Up = _root.Q<Button>(DIGIT_3_BUTTON_UP);
        _digit3Down = _root.Q<Button>(DIGIT_3_BUTTON_DOWN);
        _digit3Add = _root.Q<Button>(DIGIT_3_BUTTON_ADD);
        _digit3Remove = _root.Q<Button>(DIGIT_3_BUTTON_REMOVE);

        _switchModeButton = _root.Q<Button>(SWITCH_MODE_BUTTON);
    }

    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();
        
        _letterAUp?.RegisterCallback<ClickEvent>(IncreaseLetterA);
        _letterADown?.RegisterCallback<ClickEvent>(DecreaseLetterA);
        _letterAAdd?.RegisterCallback<ClickEvent>(EnableLetterA);
        _letterARemove?.RegisterCallback<ClickEvent>(DisableLetterA);
        _letterBUp?.RegisterCallback<ClickEvent>(IncreaseLetterB);
        _letterBDown?.RegisterCallback<ClickEvent>(DecreaseLetterB);
        _letterCUp?.RegisterCallback<ClickEvent>(IncreaseLetterC);
        _letterCDown?.RegisterCallback<ClickEvent>(DecreaseLetterC);

        _digit1Up?.RegisterCallback<ClickEvent>(IncreaseDigit1);
        _digit1Down?.RegisterCallback<ClickEvent>(DecreaseDigit1);
        _digit2Up?.RegisterCallback<ClickEvent>(IncreaseDigit2);
        _digit2Down?.RegisterCallback<ClickEvent>(DecreaseDigit2);
        _digit2Add?.RegisterCallback<ClickEvent>(EnableDigit2);
        _digit2Remove?.RegisterCallback<ClickEvent>(DisableDigit2);
        _digit3Up?.RegisterCallback<ClickEvent>(IncreaseDigit3);
        _digit3Down?.RegisterCallback<ClickEvent>(DecreaseDigit3);
        _digit3Add?.RegisterCallback<ClickEvent>(EnableDigit3);
        _digit3Remove?.RegisterCallback<ClickEvent>(DisableDigit3);

        _switchModeButton?.RegisterCallback<ClickEvent>(SwitchEditorMode);
    }

    void EnableAddRemoveButtons()
    {
        CheckButtons();
    }

    public void CheckButtons()
    {
        // Checks if LetterA is active or not, and displays the correct button
        if(letterA.activeSelf != true) // .BC-
        {
            _letterAUp.SetEnabled(false);
            _letterADown.SetEnabled(false);

            _letterARemove.style.display = DisplayStyle.None;
            _letterAAdd.style.display = DisplayStyle.Flex;
        }
        else // ABC-
        {
            _letterAUp.SetEnabled(true);
            _letterADown.SetEnabled(true);

            _letterAAdd.style.display = DisplayStyle.None;
            _letterARemove.style.display = DisplayStyle.Flex;
        }

        // Checks which Digits are active, and displays buttons accordingly
        if(digit2.activeSelf != true && digit3.activeSelf != true) // -1..
        {
            _digit2Up.SetEnabled(false);
            _digit2Down.SetEnabled(false);
            _digit3Up.SetEnabled(false);
            _digit3Down.SetEnabled(false);

            _digit3Add.style.display = DisplayStyle.None;
            _digit3Remove.style.display = DisplayStyle.None;
            _digit2Remove.style.display = DisplayStyle.None;

            _digit2Add.style.display = DisplayStyle.Flex;
        }
        else if(digit2.activeSelf != false && digit3.activeSelf != true) // -12.
        {
            _digit3Up.SetEnabled(false);
            _digit3Down.SetEnabled(false);

            _digit2Up.SetEnabled(true);
            _digit2Down.SetEnabled(true);

            _digit2Add.style.display = DisplayStyle.None;
            _digit3Remove.style.display = DisplayStyle.None;

            _digit2Remove.style.display = DisplayStyle.Flex;
            _digit3Add.style.display = DisplayStyle.Flex;
        }
        else // -123
        {
            _digit2Up.SetEnabled(true);
            _digit2Down.SetEnabled(true);
            _digit3Up.SetEnabled(true);
            _digit3Down.SetEnabled(true);

            _digit2Add.style.display = DisplayStyle.None;
            _digit2Remove.style.display = DisplayStyle.None;
            _digit3Add.style.display = DisplayStyle.None;

            _digit3Remove.style.display = DisplayStyle.Flex;
        }
    }

    void DisableAddRemoveButtons()
    {
        _letterAAdd.style.display = DisplayStyle.None;
        _letterARemove.style.display = DisplayStyle.None;
        _digit2Add.style.display = DisplayStyle.None;
        _digit2Remove.style.display = DisplayStyle.None;
        _digit3Add.style.display = DisplayStyle.None;
        _digit3Remove.style.display = DisplayStyle.None;
    }

    void IncreaseCharacter(char character)
    {
        if(character == 'A')
        {
            _letterAManager.IncreaseValue();
        }
        else if(character == 'B')
        {
            _letterBManager.IncreaseValue();
        }
        else if(character == 'C')
        {
            _letterCManager.IncreaseValue();
        }
        else if(character == '1')
        {
            _digit1Manager.IncreaseValue();
        }
        else if(character == '2')
        {
            _digit2Manager.IncreaseValue();
        }
        else if(character == '3')
        {
            _digit3Manager.IncreaseValue();
        }
        else
        {
            Debug.LogWarning("Cannot increase character value. Character equals " + character);
        }
    }

    void DecreaseCharacter(char character)
    {
        if(character == 'A')
        {
            _letterAManager.DecreaseValue();
        }
        else if(character == 'B')
        {
            _letterBManager.DecreaseValue();
        }
        else if(character == 'C')
        {
            _letterCManager.DecreaseValue();
        }
        else if(character == '1')
        {
            _digit1Manager.DecreaseValue();
        }
        else if(character == '2')
        {
            _digit2Manager.DecreaseValue();
        }
        else if(character == '3')
        {
            _digit3Manager.DecreaseValue();
        }
        else
        {
            Debug.LogWarning("Cannot decrease character value. Character equals " + character);
        }
    }

    void EnableCharacter(char character)
    {
        if(character == 'A')
        {
            letterA.SetActive(true);
        }
        else if(character == '2')
        {
            digit2.SetActive(true);
        }
        else if(character == '3')
        {
            digit3.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Cannot enable character. Character equals " + character);
        }

        // Tänne PlateManager.flip tms
    }

    void DisableCharacter(char character)
    {
        if(character == 'A')
        {
            letterA.SetActive(false);
        }
        else if(character == '2')
        {
            digit2.SetActive(false);
        }
        else if(character == '3')
        {
            digit3.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Cannot enable character. Character equals " + character);
        }
    }

    void IncreaseLetterA(ClickEvent evt)
    {
        IncreaseCharacter('A');
    }

    void DecreaseLetterA(ClickEvent evt)
    {
        DecreaseCharacter('A');
    }

    void IncreaseLetterB(ClickEvent evt)
    {
        IncreaseCharacter('B');
    }

    void DecreaseLetterB(ClickEvent evt)
    {
        DecreaseCharacter('B');
    }

    void IncreaseLetterC(ClickEvent evt)
    {
        IncreaseCharacter('C');
    }

    void DecreaseLetterC(ClickEvent evt)
    {
        DecreaseCharacter('C');
    }

    void IncreaseDigit1(ClickEvent evt)
    {
        IncreaseCharacter('1');
    }

    void DecreaseDigit1(ClickEvent evt)
    {
        DecreaseCharacter('1');
    }

    void IncreaseDigit2(ClickEvent evt)
    {
        IncreaseCharacter('2');
    }

    void DecreaseDigit2(ClickEvent evt)
    {
        DecreaseCharacter('2');
    }

    void IncreaseDigit3(ClickEvent evt)
    {
        IncreaseCharacter('3');
    }

    void DecreaseDigit3(ClickEvent evt)
    {
        DecreaseCharacter('3');
    }

    void SwitchEditorMode(ClickEvent evt)
    {
        if(letterA.activeSelf == true && _letterARemove.style.display == DisplayStyle.None ||
            letterA.activeSelf == false && _letterAAdd.style.display == DisplayStyle.None)
        {
            EnableAddRemoveButtons();
        }
        else
        {
            DisableAddRemoveButtons();
        }
    }

    void EnableLetterA(ClickEvent evt)
    {
        EnableCharacter('A');
        CheckButtons();
    }

    void DisableLetterA(ClickEvent evt)
    {
        DisableCharacter('A');
        CheckButtons();
    }

    void EnableDigit2(ClickEvent evt)
    {
        EnableCharacter('2');
        CheckButtons();
    }

    void DisableDigit2(ClickEvent evt)
    {
        DisableCharacter('2');
        CheckButtons();
    }

    void EnableDigit3(ClickEvent evt)
    {
        EnableCharacter('3');
        CheckButtons();
    }

    void DisableDigit3(ClickEvent evt)
    {
        DisableCharacter('3');
        CheckButtons();
    }

    void GetCharacterManagers()
    {
        _letterAManager = letterA.GetComponent<CharacterManager>();
        _letterBManager = letterB.GetComponent<CharacterManager>();
        _letterCManager = letterC.GetComponent<CharacterManager>();
        _digit1Manager = digit1.GetComponent<CharacterManager>();
        _digit2Manager = digit2.GetComponent<CharacterManager>();
        _digit3Manager = digit3.GetComponent<CharacterManager>();
    }
}
