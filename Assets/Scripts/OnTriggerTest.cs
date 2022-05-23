using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ontrigger
    }

    private void OnTriggerEnter(Collider what)
    {
        Debug.Log("trigger");
    }
}
