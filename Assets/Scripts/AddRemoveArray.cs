using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRemoveArray : MonoBehaviour
{
    public bool addRemoveActive;

    // Start is called before the first frame update
    void Start()
    {
        addRemoveActive = false;
    }

    public void ChangeBooleanState()
    {
        if(addRemoveActive == false)
        {
            addRemoveActive = true;
        }
        else if(addRemoveActive == true)
        {
            addRemoveActive = false;
        }
    }

    public void CheckBoolean()
    {
        if(addRemoveActive == true)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
