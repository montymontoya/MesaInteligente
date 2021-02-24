using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragThis : Usable
{
    private Vector3 positionOfScreen;
    private Vector3 offsetValue;

    public override void ClickDown(int idxButton)
    {
        positionOfScreen = Camera.main.WorldToScreenPoint(transform.position);
        offsetValue = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));

    }
    public override void ClickStay(int idxButton)
    {
        Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;
        transform.position = currentPosition;
    }
}
