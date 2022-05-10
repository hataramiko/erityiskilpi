using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentPosition : MonoBehaviour
{
    RectTransform rectTransform;

    public BaseSelection _base;
    public GameObject lettersParent;
    public GameObject letterA;
    public GameObject letterB;
    public GameObject letterC;
    public GameObject digitsParent;
    public GameObject digit1;
    public GameObject digit2;
    public GameObject digit3;
    public GameObject hyphen;

    public Vector2 euro;
    public bool evro;

    
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        TransformContent();
    }

    public void CheckBaseProperties()
    {
        if(_base.isEuro == true && _base.isTall != true)
        {
            evro = true;
        }
        else
        {
            evro = false;
        }
    }

    public void TransformContent()
    {
        CheckBaseProperties();

        if(evro == true)
        {
            rectTransform.localPosition = euro;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TransformContent();
    }

    /*

    Käyttää BaseSelectionin iffejä?
    Myöhemmin myös niitä merkkien määriä että saa keskelle?

    Jos EU-matala nii vähä sivuun
    Jos pieni nii scalea alas
    Jos korkea nii väliviiva vittuu ja kirjaimet ja numerot päällekkäin

    */
}
