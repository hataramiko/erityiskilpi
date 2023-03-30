using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//[RequireComponent(typeof(TabbedMenu))]
public class BaseSelection : UIComponent
{
    const string EURO_BASES = "bases-euro-content";
    const string WHITE_BASES = "bases-white-content";
    const string BLACK_BASES = "bases-black-content";
    //const string RESOURCE_PATH = "AppData/Bases";

    /*
    [Header("Base button")]
    [SerializeField] VisualTreeAsset m_ShopItemAsset;
    [SerializeField] GameIconsSO m_GameIconsData;
    */

    VisualElement _euroBases;
    VisualElement _whiteBases;
    VisualElement _blackBases;
    TabbedMenu _tabbedMenu;

    void OnEnable()
    {
        //BaseSelectionController. += ;
    }

    void OnDisable()
    {
        //BaseSelectionController. -= ;
    }

    protected override void Awake()
    {
        base.Awake();

        if(_tabbedMenu == null)
        {
            _tabbedMenu = GetComponent<TabbedMenu>();
        }
    }

    public override void ShowComponent()
    {
        base.ShowComponent();
        _tabbedMenu?.SelectFirstTab();
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        _euroBases = _root.Q<VisualElement>(EURO_BASES);
        _whiteBases = _root.Q<VisualElement>(WHITE_BASES);
        _blackBases = _root.Q<VisualElement>(BLACK_BASES);
    }

    public void SelectTab(string tabName)
    {
        _tabbedMenu?.SelectTab(tabName);
    }
}
