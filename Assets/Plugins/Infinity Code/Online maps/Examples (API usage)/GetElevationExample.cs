﻿/*         INFINITY CODE         */
/*   https://infinity-code.com   */

using UnityEngine;

namespace InfinityCode.OnlineMapsExamples
{
    /// <summary>
    /// Example of get elevation value in the coordinate using Google Elevation API.
    /// </summary>
    [AddComponentMenu("Infinity Code/Online Maps/Examples (API Usage)/GetElevationExample")]
    public class GetElevationExample : MonoBehaviour
    {
        public OnlineMapsControlBase controlBase;
        private void Start()
        {
            // Subscribe to click on map event.
            controlBase.OnMapClick += OnMapClick;
        }

        private void OnMapClick()
        {
            // Get the coordinates where the user clicked.
            Vector2 coords = controlBase.GetCoords();

            // Get elevation on click point
            OnlineMapsGoogleElevation.Find(coords).OnComplete += OnComplete;
        }

        private void OnComplete(string response)
        {
            // Get results from response string
            OnlineMapsGoogleElevationResult[] results = OnlineMapsGoogleElevation.GetResults(response);

            if (results == null)
            {
                // If results is null log message
                Debug.Log("Null result");
            }
            else
            {
                // Shows first result elevation
                Debug.Log(results[0].elevation);
            }
        }
    }
}