using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Not used???
public class TouchSelect : MonoBehaviour
{
    public GameObject swipeObject;
    public GameObject triggerUp;
    public GameObject triggerDown;

    // private bool activeTouch = false; // Kommenttina koskaa herjaa enkä jaksa katella, updatella samit

    // Start is called before the first frame update
    void Start()
    {
        
    }

/*
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount != 1)
        {
            activeTouch = false;
            return;
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
        }
    }
    */
}
