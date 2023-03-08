using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/*
    Handles UI Toolkit based UI interactions
*/
public class UIHandler : MonoBehaviour
{
    public PlateManager plate;
    
    public GameObject[] modes;
    int defaultMode = 0;
    int activeMode;

    // Start is called before the first frame update
    void Start() // private void OnEnable???
    {
        activeMode = defaultMode;
        SetMode();

        var root = GetComponent<UIDocument>().rootVisualElement; // var == VisualElement???

        //baseSelectButton = root.Q<Button>("ButtonBaseSelect");

        Button arrayValue = root.Q<Button>("ButtonArrayValue");
        Button addRemove = root.Q<Button>("ButtonArrayCount");
        Button baseSelect = root.Q<Button>("ButtonBaseSelect");

        arrayValue.clicked += () => ArrayValueClick();
        addRemove.clicked += () => AddRemoveClick();
        baseSelect.clicked += () => BaseSelectClick();
    }

    public void SetMode()
    {
        //
        for(int i = 0; i < modes.Length; i++)
        {
            modes[i].SetActive(false);
        }

        modes[activeMode].SetActive(true);
        //

        if(activeMode == 1)
        {

        }

        Debug.Log("Current mode: " + activeMode);
    }

    public void ArrayValueClick()
    {
        activeMode = 0;

        SetMode();
    }

    public void AddRemoveClick()
    {
        activeMode = 1;

        SetMode();
    }

    public void BaseSelectClick()
    {
        activeMode = 2;

        SetMode();
        plate.BaseArrayIncrease(); // Changes base by increasing array value by 1
    }
}
