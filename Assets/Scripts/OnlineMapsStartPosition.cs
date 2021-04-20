using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineMapsStartPosition : MonoBehaviour
{
    public double longitude, latitude;
    public float zoom = 10;
    public OnlineMapsControlBase3D map;
    // Start is called before the first frame update
    void Start()
    {
        //map.map.position = new Vector2((float)longitude, (float)latitude);
       map.map.SetPositionAndZoom(longitude, latitude, zoom);
 
    }

}
