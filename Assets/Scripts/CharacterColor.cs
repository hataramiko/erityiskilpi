using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColor : MonoBehaviour
{
    public GameObject hyphen;
    public GameObject[] characters;

    private Color charColor;
    
    // Start is called before the first frame update
    void Start()
    {
        SetCharacterColor();
    }

    public void CheckBaseColor()
    {
        /*
        if(BaseSelection.isBlack == true)
        {
            charColor = Color.white;
        }
        else
        {
            charColor = Color.black;
        }
        */
    }

    public void SetCharacterColor()
    {
        // Ensin korjaa toi että saa BaseSelectionista isBlackin toho ylempään iffiin
        // Sitten tämä muuttaa hyphenin charColoriksi
        // Sit ku hyphenin väri skulaa eli systeemi skulaa, nii toimimaa myös noille muille merkeille
    }

    // Update is called once per frame
    void Update()
    {
        SetCharacterColor();
    }
}
