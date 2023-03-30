using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public struct TabbedMenuIDs
{
    public string tabClassName;

    public string selectedTabClassName;

    public string unselectedContentClassName;

    public string tabNameSuffix;

    public string contentNameSuffix;
}

public class TabbedMenu : MonoBehaviour
{
    [SerializeField] UIDocument _document;

    [SerializeField] string _menuElementName;

    TabbedMenuController _controller;

    VisualElement _menuElement;

    public TabbedMenuIDs tabbedMenuStrings;

    private void OnEnable()
    {
        if(_document == null)
        {
            _document = GetComponent<UIDocument>();
        }

        VisualElement root = _document.rootVisualElement;
        _menuElement = root.Q(_menuElementName);

        _controller = (string.IsNullOrEmpty(_menuElementName) || _menuElement == null) ?
            new TabbedMenuController(root, tabbedMenuStrings) : new TabbedMenuController(_menuElement, tabbedMenuStrings);

            _controller.RegisterTabCallbacks();
    }

    void OnValidate()
    {
        if(string.IsNullOrEmpty(tabbedMenuStrings.tabClassName))
        {
            tabbedMenuStrings.tabClassName = "tab";
        }

        if(string.IsNullOrEmpty(tabbedMenuStrings.selectedTabClassName))
        {
            tabbedMenuStrings.selectedTabClassName = "selected-tab";
        }

        if(string.IsNullOrEmpty(tabbedMenuStrings.unselectedContentClassName))
        {
            tabbedMenuStrings.unselectedContentClassName = "unselected-content";
        }

        if(string.IsNullOrEmpty(tabbedMenuStrings.tabNameSuffix))
        {
            tabbedMenuStrings.tabNameSuffix = "-tab";
        }

        if(string.IsNullOrEmpty(tabbedMenuStrings.contentNameSuffix))
        {
            tabbedMenuStrings.contentNameSuffix = "-content";
        }
    }

    public void SelectFirstTab()
    {
        SelectFirstTab(_menuElement);
    }

    public void SelectFirstTab(VisualElement elementToQuery)
    {
        _controller?.SelectFirstTab(elementToQuery);
    }

    public void SelectTab(string tabName)
    {
        _controller?.SelectTab(tabName);
    }

    public bool IsTabSelected(VisualElement visualElement)
    {
        if(_controller == null || visualElement == null)
        {
            return false;
        }

        return _controller.IsTabSelected(visualElement);
    }
}
