using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Georeferenciar : MonoBehaviour
{
    public ManagerData managerData;
    public Data jsonData;
    public ManagerData nextManagerData;


    public GameObject marker;
    private OnlineMapsMarker3D mark;
    public OnlineMapsControlBase map;
    public OnlineMapsMarker3DManager manager;
    public UnityEvent genericEvent;

    public void GeoRef()
    {
        double lng, lat;
        lng = Convert.ToDouble(jsonData.direccion.longitud);
        lat = Convert.ToDouble(jsonData.direccion.latitud);
        // Create a new marker.
        mark = manager.Create(lng, lat, marker);
        mark.label = marker.name;
        mark.OnClick += OnMarkerClick;
        mark.transform.GetChild(0).localPosition = new Vector3(UnityEngine.Random.insideUnitCircle.x * 5, UnityEngine.Random.insideUnitCircle.y * 5, 2.5f);
        mark.transform.GetChild(0).localScale = new Vector3(2.5f, 2.5f, 2.5f);
        //mark.transform.GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 0.5f);
        mark.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        // markers.Add(mark3D.transform.gameObject);

        mark.OnLongPress += OnMarkerLongPress;
        genericEvent.Invoke();
        //mark.Init

    }

    private void OnMarkerLongPress(OnlineMapsMarkerBase marker)
    {
        // Starts moving the marker.
        map.dragMarker = marker;
        map.isMapDrag = false;
    }

    private void OnMarkerClick(OnlineMapsMarkerBase marker)
    {
        Debug.Log("mostrar dato del marker " + marker.label);
    }
}
