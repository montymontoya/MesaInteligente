using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineMapsStartPosition : MonoBehaviour
{
    public double longitude, latitude;
    public float zoom = 10;
    // Start is called before the first frame update
    void Start()
    {
        
        var map = GetComponent<OnlineMaps>();
        map.SetPositionAndZoom(longitude, latitude, zoom);
    }

}
