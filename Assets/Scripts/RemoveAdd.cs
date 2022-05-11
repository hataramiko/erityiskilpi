using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAdd : MonoBehaviour
{
    public GameObject character;
    public GameObject self;
    public GameObject counterpart;

    // Start is called before the first frame update
    void Start()
    {
        if(character.activeSelf != true)
        {
            self.SetActive(false);
            counterpart.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(character.activeSelf != true)
        {
            self.SetActive(false);
            counterpart.SetActive(true);
        }
    }
}
