using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfSpin : MonoBehaviour
{
    public float spinSpeed = 1f;
    public enum axis
    {
        x,y,z
    }
    public axis eje = axis.x;

    // Update is called once per frame
    void Update()
    {
        if (eje == axis.x)
            transform.RotateAround(transform.position, Vector3.right, spinSpeed * Time.deltaTime);

        if (eje == axis.y)
            transform.RotateAround(transform.position, Vector3.up, spinSpeed * Time.deltaTime);

        if (eje == axis.z)
            transform.RotateAround(transform.position, Vector3.forward, spinSpeed * Time.deltaTime);


    }
}
