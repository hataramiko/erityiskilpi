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
        //activeMode = defaultMode;
        //SetMode();

        var root = GetComponent<UIDocument>().rootVisualElement; // var == VisualElement???

        //baseSelectButton = root.Q<Button>("ButtonBaseSelect");

        Button navBarFirst = root.Q<Button>("NavBarButton1");
        Button navBarSecond = root.Q<Button>("NavBarButton2");
        //Button navBarThird = root.Q<Button>("NavBarButton3");

        navBarFirst.clicked += () => EnterEditMode();
        navBarSecond.clicked += () => EnterBaseSelect();
        //navBarThird.clicked += () => BaseSelectClick();
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

    public void EnterEditMode()
    {
        Debug.Log("Merkit ylös/alas tilattu'd");
    }

    public void EnterBaseSelect()
    {
        Debug.Log("Nyt vaihtuu pohja");

        plate.BaseArrayIncrease(); // Changes base by increasing array value by 1
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
