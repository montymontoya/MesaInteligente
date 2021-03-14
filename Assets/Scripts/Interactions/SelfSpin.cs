using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfSpin : MonoBehaviour
{
    public float spinSpeed = 1f;
    public enum axis
    {
        x,y,z,xy,xz,yz,xyz
    }
    public axis eje = axis.x;

    // Update is called once per frame
    void Update()
    {
        switch (eje)
        {
            case axis.x:
                transform.RotateAround(transform.position, Vector3.right, spinSpeed * Time.deltaTime);
                break;
            case axis.y:
                transform.RotateAround(transform.position, Vector3.up, spinSpeed * Time.deltaTime);
                break;
            case axis.z:
                transform.RotateAround(transform.position, Vector3.forward, spinSpeed * Time.deltaTime);
                break;
            case axis.xy:
                transform.RotateAround(transform.position, Vector3.right, spinSpeed * Time.deltaTime);
                transform.RotateAround(transform.position, Vector3.up, spinSpeed * Time.deltaTime);
                break;
            case axis.xz:
                transform.RotateAround(transform.position, Vector3.right, spinSpeed * Time.deltaTime);
                transform.RotateAround(transform.position, Vector3.forward, spinSpeed * Time.deltaTime);
                break;
            case axis.yz:
                transform.RotateAround(transform.position, Vector3.up, spinSpeed * Time.deltaTime);
                transform.RotateAround(transform.position, Vector3.forward, spinSpeed * Time.deltaTime);
                break;
            case axis.xyz:
                transform.RotateAround(transform.position, Vector3.right, spinSpeed * Time.deltaTime);
                transform.RotateAround(transform.position, Vector3.up, spinSpeed * Time.deltaTime);
                transform.RotateAround(transform.position, Vector3.forward, spinSpeed * Time.deltaTime);
                break;

        }

            


    }
}
