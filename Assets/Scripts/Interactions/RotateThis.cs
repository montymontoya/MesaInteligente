using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis : MonoBehaviour
{
    private Transform obj;
    public float speed = 10;
    public int btn = 0;
    Vector3 toAng;
    Quaternion fromAng;
    // Start is called before the first frame update
    void Start()
    {
        obj = transform;
        toAng = fromAng.eulerAngles;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            toAng -=  new Vector3(0,45,0);
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            toAng += new Vector3(0, 45, 0); ;
            
        }
        fromAng = obj.rotation;
        obj.rotation = Quaternion.Slerp(fromAng, Quaternion.Euler(toAng), Time.deltaTime * speed);
        /*
        var clicDown = Input.GetMouseButton(btn);
        var clicUp = Input.GetMouseButtonUp(btn);
        if (clicDown && !clicUp)
        {
            obj.Rotate(rotAxis, Time.deltaTime * speed * Input.GetAxis("Mouse X"));
        }
        */

    }
}
