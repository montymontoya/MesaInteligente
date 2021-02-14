using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShowPanelOnClick : MonoBehaviour
{
    public GameObject PanelToShow;

    public GameObject PanelToHide1;
    public GameObject PanelToHide2;
    public GameObject PanelToHide3;

    public void OpenPanel()
    {
        if (PanelToShow != null)
        {
            PanelToShow.SetActive(true);
        }

        PanelToHide1.SetActive(false);
        PanelToHide2.SetActive(false);
        PanelToHide3.SetActive(false);
    }
}
