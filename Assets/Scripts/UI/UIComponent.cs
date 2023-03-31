using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public abstract class UIComponent : MonoBehaviour
{
    [SerializeField] protected string _componentName;
    [SerializeField] protected UIManager _UIManager;
    [SerializeField] protected UIDocument _UIDocument;

    protected VisualElement _component;
    protected VisualElement _root;

    public event Action ComponentEnable;
    public event Action ComponentDisable;

    protected virtual void OnValidate()
    {
        if(string.IsNullOrEmpty(_componentName))
        {
            _componentName = this.GetType().Name;
        }
    }

    protected virtual void Awake()
    {
        if(_UIManager == null)
        {
            _UIManager = GetComponent<UIManager>();
        }

        if(_UIDocument == null)
        {
            _UIDocument = GetComponent<UIDocument>();
        }

        if(_UIDocument == null && _UIManager != null)
        {
            _UIDocument = _UIManager.UIDocument;
        }

        if(_UIDocument == null)
        {
            Debug.LogWarning(_componentName + ": missing UIDocument. Check Script Execution Order.");
            return;
        }
        else
        {
            SetVisualElements();
            RegisterButtonCallbacks();
        }
    }

    protected virtual void SetVisualElements()
    {
        if(_UIDocument != null)
        {
            _root = _UIDocument.rootVisualElement;
        }

        _component = GetVisualElement(_componentName);
    }

    protected virtual void RegisterButtonCallbacks()
    {

    }

    public bool IsVisible()
    {
        if(_component == null)
        {
            return false;
        }

        return (_component.style.display == DisplayStyle.Flex);
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
        if(string.IsNullOrEmpty(elementName) || _root == null)
        {
            return null;
        }

        return _root.Q(elementName);
    }

    public virtual void ShowComponent()
    {
        ShowVisualElement(_component, true); //Debug.Log(_component);
        ComponentEnable?.Invoke();
    }

    public virtual void HideComponent()
    {
        if(IsVisible())
        {
            ShowVisualElement(_component, false);
            ComponentDisable?.Invoke();
        }
    }
}
