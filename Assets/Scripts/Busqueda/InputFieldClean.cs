using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldClean : MonoBehaviour
{
    public TMP_InputField inputField;
    
    public void CleanInput()
    {
        inputField.text = "";
    }
}
