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
    [Tooltip("PlateManager script from the GameObject based Plate.")]
    public PlateManager plate;

    // UI Toolkit Sample -settiä
    [Tooltip("Only one of these can be active at a time.")]
    [Header("Modal interfaces")]
    [SerializeField] CharacterEditor _characterEditor;
    [SerializeField] BaseSelection _baseSelection;

    [Tooltip("These remain active unless disabled.")]
    [Header("Constant interfaces")]
    [SerializeField] NavigationBar _navigationBar;
    [SerializeField] OptionsTab _optionsTab; // Options burger-menu + buttons OR window

    [Tooltip("These block interfaces below, background acts as Back-button.")]
    [Header("Full-screen overlays")]
    [SerializeField] SettingsWindow _settings; // Either centered, or anchored to the left
    [SerializeField] PromptWindow _prompt; // Used for Save & Reset and such

    List<UIComponent> _allModalInterfaces = new List<UIComponent>();

    UIDocument _uiDocument;
    public UIDocument UIDocument => _uiDocument;

    const string EDIT_CHARACTERS_WINDOW = "edit-characters";
    const string EDIT_BASES_WINDOW = "edit-bases";

    VisualElement _characterEditorContent;
    VisualElement _baseSelectionContent;


    void OnEnable()
    {
        _uiDocument = GetComponent<UIDocument>();
        //SetupModalInterfaces();
        //ShowBaseSelection();
        //ShowCharacterEditor();

        var root = _uiDocument.rootVisualElement; // var == VisualElement???
        _characterEditorContent = root.Q<VisualElement>(EDIT_CHARACTERS_WINDOW);
        _baseSelectionContent = root.Q<VisualElement>(EDIT_BASES_WINDOW);
    }

    void SetupModalInterfaces()
    {
        if(_characterEditor != null)
        {
            _allModalInterfaces.Add(_characterEditor);

            //Debug.Log(_characterEditor + " ei oo null");
        }

        if(_baseSelection != null)
        {
            _allModalInterfaces.Add(_baseSelection);

            //Debug.Log(_baseSelection + " ei oo null");
        }
    }

    void DisplayModalInterface(UIComponent component)
    {
        foreach (UIComponent c in _allModalInterfaces)
        {
            if(c == component)
            {
                //Debug.Log(c + " on juttu. " + component + " on toinen juttu.");
                c?.ShowComponent();
                //Debug.Log(c + " on juttu. " + component + " on toinen juttu.");
            }
            else
            {
                c?.HideComponent();
            }
        }
    }

    public void ShowCharacterEditor()
    {
        DisplayModalInterface(_characterEditor);
    }

    public void ShowBaseSelection()
    {
        DisplayModalInterface(_baseSelection);
    }

    public void EnableCharacterEditor()
    {
        //HideBaseSelection();
        DisplayCharacterEditor();
        
        Debug.Log("MERKIT");
    }

    public void EnableBaseSelection()
    {
        plate.BaseArrayIncrease(); // Changes base by increasing array value by 1

        HideCharacterEditor();
        //DisplayBaseSelection();

        Debug.Log("POHJAT");
    }

    void DisplayCharacterEditor()
    {
        _characterEditor.SetAddRemoveButtons(false);
        _characterEditor.SetUpDownButtons(true);
        _characterEditorContent.style.display = DisplayStyle.Flex;
    }

    void HideCharacterEditor()
    {
        _characterEditorContent.style.display = DisplayStyle.None;
    }

    void DisplayBaseSelection()
    {
        //_baseSelectionContent.style.display = DisplayStyle.Flex;
    }

    void HideBaseSelection()
    {
        //_baseSelectionContent.style.display = DisplayStyle.None;
    }
}
