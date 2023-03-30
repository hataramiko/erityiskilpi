using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class CharacterEditor : UIComponent
{
    public static event Action characterEditorShown;

    const string CHARACTERS = "characters";

    VisualElement _characters;

    public override void ShowComponent()
    {
        base.ShowComponent();
        characterEditorShown?.Invoke();
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        _characters = _root.Q<VisualElement>(CHARACTERS);
    }

    protected override void RegisterButtonCallbacks()
    {
        // ?
    }
}
