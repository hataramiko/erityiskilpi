using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public abstract class UIElement : MonoBehaviour
{
    [SerializeField] protected string ElementName;
    [SerializeField] protected UIManager UIManager;
    [SerializeField] protected UIDocument UIDocument;

    protected VisualElement Element;
    protected VisualElement Root;

    public event Action ElementStart;
    public event Action ElementEnd;

    protected virtual void OnValidate()
    {
        if(string.IsNullOrEmpty(ElementName))
        {
            ElementName = this.GetType().Name;
        }
    }

    protected virtual void Awake()
    {
        if(UIManager == null)
        {
            UIManager = GetComponent<UIManager>();
        }

        if(UIDocument == null)
        {
            UIDocument = GetComponent<UIDocument>();
        }

        SetVisualElements();
        RegisterButtonCallbacks();
    }

    protected virtual void SetVisualElements()
    {
        if(UIDocument != null)
        {
            Root = UIDocument.rootVisualElement;
        }

        Element = GetVisualElement(ElementName);
    }

    protected virtual void RegisterButtonCallbacks()
    {

    }

    public bool IsVisible()
    {
        if(Element == null)
        {
            return false;
        }

        return (Element.style.display == DisplayStyle.Flex);
    }

    public static void ShowVisualElement(VisualElement visualElement, bool state)
    {
        if(visualElement == null)
        {
            return;
        }

        visualElement.style.display = (state) ? DisplayStyle.Flex : DisplayStyle.None;
    }

    public VisualElement GetVisualElement(string elementName)
    {
        if(string.IsNullOrEmpty(elementName) || Root == null)
        {
            return null;
        }

        return Root.Q(elementName);
    }

    public virtual void ShowUIElement()
    {
        ShowVisualElement(Element, true);
        ElementStart?.Invoke();
    }

    public virtual void HideUIElement()
    {
        if(IsVisible())
        {
            ShowVisualElement(Element, false);
            ElementEnd?.Invoke();
        }
    }
}
