using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleActive : MonoBehaviour
{
    public GameObject objToToggle;
    private bool status;
    public bool onlyON = false;
    public bool onlyOff = false;
    private void Start()
    {
        status = objToToggle.activeSelf;
    }

    public void ToggleState()
    {
        status = !status;
        if (onlyON)
        {
            objToToggle.SetActive(true);
        }
        else if (onlyOff)
        {
            objToToggle.SetActive(false);
        }
        else
        {
            objToToggle.SetActive(status);
        }
    }
}
