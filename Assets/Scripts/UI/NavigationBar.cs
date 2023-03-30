using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NavigationBar : UIComponent
{
    const string NAV_BAR_CHARACTERS_BUTTON = "nav-bar-button1";
    const string NAV_BAR_BASES_BUTTON = "nav-bar-button2";

    //const string ACTIVE_MODE_MARKER = "";

    Button _navBarFirst;
    Button _navBarSecond;

    //VisualElement _activeModeMarker;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        _navBarFirst = _root.Q<Button>(NAV_BAR_CHARACTERS_BUTTON);
        _navBarSecond = _root.Q<Button>(NAV_BAR_BASES_BUTTON);

        //_activeModeMarker = _root.Q<VisualElement>(ACTIVE_MODE_MARKER);
    }

    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();

        _navBarFirst?.RegisterCallback<ClickEvent>(DisplayChars);
        _navBarSecond?.RegisterCallback<ClickEvent>(DisplayBases);
    }

    void DisplayChars(ClickEvent evt)
    {
        ActivateButton(_navBarFirst);
        _UIManager?.EnterEditMode();
        ClickMarker(evt);
    }

    void DisplayBases(ClickEvent evt)
    {
        ActivateButton(_navBarSecond);
        _UIManager?.EnterBaseSelect();
        ClickMarker(evt);
    }

    void ActivateButton(Button navBarButton)
    {
        if(navBarButton == null)
        {
            return;
        }

        HighlightElement(navBarButton, _root);

        //Label label = navBarButton.Q<Label>(className: CONST_labelInactiveClass);
        //HighlightElement(label, CONST_labelInactiveClass, CONST_labelActiveClass, _root);
    }

    void ClickMarker(ClickEvent evt)
    {
        //Debug.Log("ClickMarker kai sen nyt kuulus liikkuu mut ei oo sitä nii");
    }

    void HighlightElement(VisualElement visualElement, VisualElement root)
    {
        if(visualElement == null)
        {
            return;
        }
    }
}
