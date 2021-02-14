//Attach this script to your Canvas GameObject.
//Also attach a GraphicsRaycaster component to your canvas by clicking the Add Component button in the Inspector window.
//Also make sure you have an EventSystem in your hierarchy.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class LockMove : MonoBehaviour
{

    public bool mstay;

    public bool mEnable;

    public Camera cam;

    private RaycastHit hit;
    void Start()
    {
        if (cam == null)
            cam = Camera.main;
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
                if (hit.transform.CompareTag("panel"))
                    cam.GetComponent<MoveController>().canMove = false;

        }
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
            cam.GetComponent<MoveController>().canMove = true;

    }
    
}