using UnityEngine;
using System.Collections;

public class OnlineMapsMarkerCreator2D : MonoBehaviour
{
    public Texture2D texture;
    private OnlineMapsMarker mark;
    public bool canMark;
    public bool isReady;

    
    
    private void Start()
    {
        OnlineMapsControlBase.instance.OnMapClick += OnMapClick;
    }



    private void OnMapClick()
    {
        if (isReady)
        {
            double lng, lat;
            OnlineMapsControlBase.instance.GetCoords(out lng, out lat);

            string label = "Marker " + (OnlineMapsMarkerManager.CountItems + 1);

            // Create a new marker.
            mark = OnlineMapsMarkerManager.CreateItem(lng, lat, label);

            mark.texture = texture;
            mark.OnLongPress += OnMarkerLongPress;
            mark.OnClick += onMarkerClick;
            mark.Init();
            isReady = false;
        }




        
        /*gets GeoPosition
        double x, y;
        mark.GetPosition(out x, out y);
        */
    }


    public void ChangeMarker(Texture2D t)
    {
        texture = t;
        isReady = true;
    }

    private void OnMarkerLongPress(OnlineMapsMarkerBase marker)
    {
        // Starts moving the marker.
        OnlineMapsControlBase.instance.dragMarker = marker;
        OnlineMapsControlBase.instance.isMapDrag = false;
    }

    private void onMarkerClick(OnlineMapsMarkerBase marker)
    {
        Debug.Log("mostrar dato del marker " + marker.label);
    }
}