using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragOBJ : MonoBehaviour
{
    private bool isMouseDragging;
    private Vector3 positionOfScreen;
    private Vector3 offsetValue;

    Vector3 targetAngle;


    public float _sensitivity;
    public Vector3 _mouseReference;
    public Vector3 _mouseOffset;
    public Vector3 _rotation;


    public int btnMove = 0;
    public int btnRotate = 1;
    public int btnZoom = 2;
    void Start()
    {
        _sensitivity = 0.4f;
        _rotation = Vector3.zero;
    }



    void Update()
    {


        if (Input.GetMouseButtonDown(btnMove))
        {
            positionOfScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offsetValue = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
        }
        else if (Input.GetMouseButtonDown(btnRotate))
        {
            _mouseReference = Input.mousePosition;
        }

        if (Input.GetMouseButton(btnMove))
        {
                Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);
                Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;
                gameObject.transform.position = currentPosition;
        }
        else if (Input.GetMouseButton(btnRotate))
        {
            _mouseOffset = (Input.mousePosition - _mouseReference);
            _rotation.x = -(_mouseOffset.y ) * _sensitivity;
            transform.Rotate(_rotation);
            var _Rotation = new Vector3();
            _Rotation.y = -(_mouseOffset.x) * _sensitivity;
            transform.GetChild(1).Rotate(_Rotation);
            _mouseReference = Input.mousePosition;
        }
    }
}
