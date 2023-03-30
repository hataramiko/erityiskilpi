using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class TabbedMenuController
{
    public static event Action tabSelected;

    readonly VisualElement _root;
    readonly TabbedMenuIDs _IDs;

    public TabbedMenuController(VisualElement root, TabbedMenuIDs ids)
    {
        _root = root;
        _IDs = ids;
    }

    public void RegisterTabCallbacks()
    {
        UQueryBuilder<VisualElement> tabs = GetAllTabs();

        tabs.ForEach((t) => {t.RegisterCallback<ClickEvent>(OnTabClick);});
    }

    void OnTabClick(ClickEvent evt)
    {
        VisualElement clickedTab = evt.currentTarget as VisualElement;

        if(!IsTabSelected(clickedTab))
        {
            GetAllTabs().Where((tab) => tab != clickedTab && IsTabSelected(tab)).ForEach(UnselectTab);

            SelectTab(clickedTab);
        }
    }

    VisualElement FindContent(VisualElement tab)
    {
        return _root.Q(GetContentName(tab));
    }

    string GetContentName(VisualElement tab)
    {
        return tab.name.Replace(_IDs.tabNameSuffix, _IDs.contentNameSuffix);
    }

    UQueryBuilder<VisualElement> GetAllTabs()
    {
        return _root.Query<VisualElement>(className: _IDs.tabClassName);
    }

    public VisualElement GetFirstTab(VisualElement visualElement)
    {
        return visualElement.Query<VisualElement>(className: _IDs.tabClassName).First();
    }

    public bool IsTabSelected(string tabName)
    {
        VisualElement tabElement = _root.Query<VisualElement>(className: _IDs.tabClassName, name: tabName);
        return IsTabSelected(tabElement);
    }

    public bool IsTabSelected(VisualElement tab)
    {
        return tab.ClassListContains(_IDs.selectedTabClassName);
    }

    void UnselectOtherTabs(VisualElement tab)
    {
        GetAllTabs().Where((t) => t != tab && IsTabSelected(t)).ForEach(UnselectTab);
    }

    public void SelectTab(string tabName)
    {
        if(string.IsNullOrEmpty(tabName))
        {
            return;
        }

        VisualElement namedTab = _root.Query<VisualElement>(tabName, className: _IDs.tabClassName);

        if(namedTab == null)
        {
            Debug.Log("TabbedMenuController.SelectTab: invalid tab specified");
            return;
        }

        UnselectOtherTabs(namedTab);
        SelectTab(namedTab);
    }

    void SelectTab(VisualElement tab)
    {
        tab?.AddToClassList(_IDs.selectedTabClassName);

        VisualElement content = FindContent(tab);
        content?.RemoveFromClassList(_IDs.unselectedContentClassName);

        tabSelected?.Invoke();
    }

    public void SelectFirstTab(VisualElement visualElement)
    {
        VisualElement firstTab = GetFirstTab(visualElement);

        if(firstTab != null)
        {
            GetAllTabs().Where((tab) => tab != firstTab && IsTabSelected(tab)).ForEach(UnselectTab);

            SelectTab(firstTab);
        }
    }

    void UnselectTab(VisualElement tab)
    {
        tab?.RemoveFromClassList(_IDs.selectedTabClassName);

        VisualElement content = FindContent(tab);
        content?.AddToClassList(_IDs.unselectedContentClassName);
    }
}
