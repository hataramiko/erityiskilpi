using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public PlateManager plate;

    // Start is called before the first frame update
    void Start() // private void OnEnable???
    {
        var root = GetComponent<UIDocument>().rootVisualElement; // var == VisualElement???

        //baseSelectButton = root.Q<Button>("ButtonBaseSelect");

        Button arrayValue = root.Q<Button>("ButtonArrayValue");
        Button addRemove = root.Q<Button>("ButtonArrayCount");
        Button baseSelect = root.Q<Button>("ButtonBaseSelect");

        //arrayValue.clicked += () => ;
        //addRemove.clicked += () => ;
        baseSelect.clicked += () => plate.BaseArrayIncrease();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
