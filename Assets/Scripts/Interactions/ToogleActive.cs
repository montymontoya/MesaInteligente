using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleActive : MonoBehaviour
{
    public GameObject objToToggle;
    private bool status;
    private void Start()
    {
        status = objToToggle.activeSelf;
    }

    void ToggleState()
    {
        status = !status;
        objToToggle.SetActive(status);
    }
}
