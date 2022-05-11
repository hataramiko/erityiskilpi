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

    public Vector2 defaultPosition;
    public Vector3 defaultScale;
    public Vector2 euroOffset;
    private bool offset;
    public Vector3 smallScale;
    public Vector2 positionRight1;
    public Vector2 positionRight2;
    public Vector2 positionLeft1;
    public Vector2 lettersDefaultPos;
    public Vector2 digitsDefaultPos;
    public Vector2 lettersPosition0;
    public Vector2 lettersPosition1;
    public Vector2 digitsPosition0;
    public Vector2 digitsPosition1;
    public Vector2 digitsPosition2;
    
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        CheckBase();
    }

    public void CheckBase()
    {
        if(_base.isTall == true)
        {
            hyphen.SetActive(false);
            rectTransform.localPosition = defaultPosition;
            rectTransform.localScale = defaultScale;

            TransformTall();
        }
        else
        {
            hyphen.SetActive(true);
            lettersParent.GetComponent<RectTransform>().localPosition = lettersDefaultPos;
            digitsParent.GetComponent<RectTransform>().localPosition = digitsDefaultPos;

            Transform();
        }
    }

    public void Transform()
    {
        Vector2 position;

        if(_base.isShort == true && letterA.activeSelf == true && digit3.activeSelf == true)
        {
            //letterA.SetActive(false);
            digit3.SetActive(false);
        }

        if(letterA.activeSelf == false && digit2.activeSelf != true) // BC-1
        {
            position = positionRight1;
        }
        else if(letterA.activeSelf == false && digit3.activeSelf != true) // BC-12
        {
            position = defaultPosition;
        }
        else if(letterA.activeSelf == false) // BC-123
        {
            position = positionLeft1;
        }
        else if(digit2.activeSelf != true) // ABC-1
        {
            position = positionRight2;
        }
        else if(digit3.activeSelf != true) // ABC-12
        {
            position = positionRight1;
        }
        else // ABC-123
        {
            position = defaultPosition;
        }

        if(_base.isSmall == true)
        {
            rectTransform.localScale = smallScale;
        }
        else
        {
            rectTransform.localScale = defaultScale;
        }

        if(_base.isEuro == true && _base.isTall != true)
        {
            Vector2 offsetPosition = position;

            offsetPosition.x = euroOffset.x;
            offsetPosition.y = euroOffset.y;

            position = offsetPosition;
        }

        rectTransform.localPosition = position;
    }

    public void TransformTall()
    {
        if(letterA.activeSelf == false)
        {
            lettersParent.GetComponent<RectTransform>().localPosition = lettersPosition1;
        }
        else
        {
            lettersParent.GetComponent<RectTransform>().localPosition = lettersPosition0;
        }

        if(digit2.activeSelf != true)
        {
            digitsParent.GetComponent<RectTransform>().localPosition = digitsPosition2;
        }
        else if(digit3.activeSelf != true)
        {
            digitsParent.GetComponent<RectTransform>().localPosition = digitsPosition1;
        }
        else
        {
            digitsParent.GetComponent<RectTransform>().localPosition = digitsPosition0;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        CheckBase();
    }
}
