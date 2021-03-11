using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Create12Hours : MonoBehaviour
{
    public GameObject mapHour;
    public JSONReaderAnalitica json;
    public List<Data> mjson;
    public bool setMaps = true;

    public GameObject markerPrefab;
    private OnlineMapsMarker3D mark3D;
    private int qtyEvents;
    private int idx;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    private void Update()
    {
        if (qtyEvents == 0)
        {
            qtyEvents = json.data.Count;
        }
        else
        {
            if (setMaps)
            {
                mjson.Add(json.data[1]);
                mjson.Add(json.data[3]);
                mjson.Add(json.data[5]);
                mjson.Add(json.data[7]);
                mjson.Add(json.data[9]);
                mjson.Add(json.data[11]);
                mjson.Add(json.data[13]);
                mjson.Add(json.data[15]);

                foreach (var item in mjson)
                {
                    var map = Instantiate(mapHour).transform;
                    //item.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Legacy Shaders/Diffuse"));
                    map.parent = transform;
                    map.localPosition = new Vector3(0, idx, 0);

                    //oMaps.SetPosition(19.03793f , - 98.20346f);
                    //map.GetComponent<OnlineMaps>().position = new Vector2(19.03793f, -98.20346f);
                    //string label = "Marker Analitica id: " + item.identificacion + "\n" + (item.descripcion);

                    double lng = Convert.ToDouble(item.direccion.longitud);
                    double lat = Convert.ToDouble(item.direccion.latitud);

                    // Create a new marker.
                    mark3D = OnlineMapsMarker3DManager.CreateItem(lng, lat, markerPrefab);
                    mark3D.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    mark3D.transform.GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 0.5f);
                    mark3D.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                    //mark3D.range = new OnlineMapsRange(1, 10);
                    idx++;
                }
                setMaps = false;
            }
            else
            {

            }
        }
        

    }

}
