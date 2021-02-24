using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfSpin : MonoBehaviour
{
    public float spinSpeed = 1f;
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.forward, spinSpeed * Time.deltaTime);
    }
}
