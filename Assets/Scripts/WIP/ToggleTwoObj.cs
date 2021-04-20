using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTwoObj : MonoBehaviour
{
    public GameObject objToOn;
    public GameObject objToOff;

    public void Toogle()
    {
        if (objToOn && objToOff)
        {
            objToOn.SetActive(true);
            objToOff.SetActive(false);
        }
        
    }
}
