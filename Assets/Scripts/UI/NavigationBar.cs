using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NavigationBar : UIElement
{
    const string NavBarCharsButton = "nav-bar-button1";
    const string NavBarBasesButton = "nav-bar-button2";

    //const string ActiveMarker = "";

    Button navBarFirst;
    Button navBarSecond;

    //VisualElement activeMarker;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        navBarFirst = Root.Q<Button>(NavBarCharsButton);
        navBarSecond = Root.Q<Button>(NavBarBasesButton);
    }

    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();

        navBarFirst?.RegisterCallback<ClickEvent>(DisplayChars);
        navBarSecond?.RegisterCallback<ClickEvent>(DisplayBases);
    }

    void DisplayChars(ClickEvent evt)
    {
        ActivateButton(navBarFirst);
        //UIManager?.EnterEditMode();
        ClickMarker(evt);
    }

    void DisplayBases(ClickEvent evt)
    {
        ActivateButton(navBarSecond);
        //UIManager?.EnterBaseSelect();
        ClickMarker(evt);
    }

    void ActivateButton(Button navBarButton)
    {
        if(navBarButton == null)
        {
            return;
        }

        HighlightElement(navBarButton, Root);
    }

    void ClickMarker(ClickEvent evt)
    {
        Debug.Log("ClickMarker kai sen nyt kuulus liikkuu mut ei oo sitä nii");
    }

    void HighlightElement(VisualElement visualElement, VisualElement root)
    {
        if(visualElement == null)
        {
            return;
        }
    }
}
