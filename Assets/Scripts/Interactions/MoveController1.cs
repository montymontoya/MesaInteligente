using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController1 : MonoBehaviour
{
    public Transform target;
    public float speedX = 1f;
    public float speedY = 1f;
    private float rotX;
    private float rotY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotX = Input.GetAxis("Mouse Y");
        rotY = Input.GetAxis("Mouse X");

        rotX *= Time.deltaTime * speedX;
        rotY *= Time.deltaTime * speedY;
        var fromRotation = transform.rotation;
        var toRotation = Quaternion.Euler(rotY, rotX, 0);
        transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * 10);
    }
}
