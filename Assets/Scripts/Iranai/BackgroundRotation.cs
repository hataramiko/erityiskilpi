using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Simple script for rotating the background,
    to be replaced with a better solution later.
*/
public class BackgroundRotation : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -Time.deltaTime * speed, Space.Self);
    }
}
