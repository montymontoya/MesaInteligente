using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisMapControl : Usable
{
    Collider col, planeCol;
    public OnlineMaps map;
    Transform children;
    Transform parent;
    public Vector2 mapDataPosition;
    public float mapZoom;


    // Start is called before the first frame update
    void Start()
    {
        map = OnlineMaps.instance;

        col = GetComponent<Collider>();
        planeCol = transform.GetChild(0).GetComponent<Collider>();
        parent = transform.parent;
        children = parent.GetComponentInChildren<Transform>();
        
        mapDataPosition = map.position;
        mapZoom = map.zoom;
    }

    
    public override void RayEnter()
    {

    }

    public override void RayStay()
    {
        if (gameObject)
        {
            mapDataPosition = map.position;
            mapZoom = map.zoom;

            foreach (Transform child in children)
            {
                var item = child.GetComponent<OnlineMaps>();
                item.position = map.position;
                item.zoom = map.zoom;
            }

        }
        /*
        else
        {
            planeCol.enabled = true;
            col.enabled = false;
        }*/
    }

    public override void ClickUp(int idxButton)
    {

    }

    IEnumerator Mapas()
    {

        yield return 0;
    }

    public override void RayExit()
    {

    }
    
}
