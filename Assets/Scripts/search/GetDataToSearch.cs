using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class GetDataToSearch : MonoBehaviour
{
    public TMP_InputField[] inputField;
    public string[] inputText;

    public UnityEvent OnClic;
    
    public void OnClick()
    {
        int idx = 0;
        foreach (var input in inputField)
        {
            inputText[idx] = inputField[idx].text;
        }

        OnClic.Invoke();
    }
}
