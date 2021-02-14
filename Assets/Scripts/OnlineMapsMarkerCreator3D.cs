using UnityEngine;
using System.Collections;

public class OnlineMapsMarkerCreator3D : MonoBehaviour
{
    public GameObject marker;
    private OnlineMapsMarker3D mark;
    public bool canMark;
    public bool isReady;

    public OnlineMapsControlBase map;
    public OnlineMapsMarker3DManager manager;

    private void Start()
    {

        //map = OnlineMapsControlBase3D.instance;
        //manager = map.GetComponent<OnlineMapsMarker3DManager>();
        Debug.Log(map.name);

        map.OnMapClick += OnMapClick;
    }


    private void OnMapClick()
    {
        
        if (isReady)
        {
            double lng, lat;
            map.GetCoords(out lng, out lat);
            
            // Create a new marker.
            mark = manager.Create(lng, lat, marker);
            mark.label = marker.name;
            mark.OnClick += OnMarkerClick;
            mark.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            mark.transform.GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 0.5f);
            mark.transform.localRotation = Quaternion.Euler(0, 0, 0);
           // markers.Add(mark3D.transform.gameObject);

            mark.OnLongPress += OnMarkerLongPress;
            //mark.Init
            isReady = false;
        }

    }


    public void ChangeMarker(GameObject t)
    {
        marker = t;
        isReady = true;
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