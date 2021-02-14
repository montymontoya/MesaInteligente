﻿/*         INFINITY CODE         */
/*   https://infinity-code.com   */

using UnityEngine;

    /// <summary>
    /// Example of how to create a marker on click.
    /// </summary>
    [AddComponentMenu("Infinity Code/Online Maps/Examples (API Usage)/CreateMarkerOnClick")]
    public class CreateMarkerOnClick:MonoBehaviour
    {
    public Texture2D texture;
    private OnlineMapsMarker mark;


    private void Start()
        {
            // Subscribe to the click event.
            OnlineMapsControlBase.instance.OnMapClick += OnMapClick;
        }

        private void OnMapClick()
        {
            // Get the coordinates under the cursor.
            double lng, lat;
            OnlineMapsControlBase.instance.GetCoords(out lng, out lat);

            // Create a label for the marker.
            string label = "Marker " + (OnlineMapsMarkerManager.CountItems + 1);

            // Create a new marker.
            mark = OnlineMapsMarkerManager.CreateItem(lng, lat, label);
        mark.texture = texture;
        mark.OnLongPress += OnMarkerLongPress;
        mark.Init();
        }

    private void OnMarkerLongPress(OnlineMapsMarkerBase marker)
    {
        // Starts moving the marker.
        OnlineMapsControlBase.instance.dragMarker = marker;
        OnlineMapsControlBase.instance.isMapDrag = false;
    }
}

