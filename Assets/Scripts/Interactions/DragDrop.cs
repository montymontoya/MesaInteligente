﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.Events;


public class DragDrop : MonoBehaviour
{

    private bool isMouseDragging;
    private Vector3 positionOfScreen;
    private Vector3 offsetValue;

    void OnMouseDown()
    {

        isMouseDragging = true;

        positionOfScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offsetValue = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
    }

    void OnMouseUp()
    {
        isMouseDragging = false;
    }

    void Update()
    {

        if (isMouseDragging)
        {

            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;
            gameObject.transform.position = currentPosition;
        }
    }

}