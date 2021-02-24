﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using dataType = Incidencia;
public class CapasIncidencias : JSONReaderBase
{
    #region variables propias de base
    public List<dataType> listIncidencias; // se declara una variable para guardar los datos
    public bool isReady = false; // esta bandera sirve de apoyo para indicarle al sistema hasta cuando dejar de ejecutarse.
    public bool listReady; // esta bandera sirve de apoyo para saber en qué momento ya existen datos
    public bool start, whilee,getData, setData;

    public TextAsset texto;
    #endregion
    #region variables de este código particular

    public GameObject markerPrefab;
    [HideInInspector]
    public OnlineMapsMarker3D mark3D;

    public OnlineMapsMarker3DManager manager;

    public List<GameObject> markers = new List<GameObject>();
    private OnlineMaps map;
    #endregion

    #region Start
    void Start()
    {/*
        if (manager!=null)
        {
            manager = GetComponent<OnlineMapsMarker3DManager>();
        }*/
        start = true;
        map = manager.GetComponent<OnlineMaps>();
        /*if (texto != null)
        {
            LocalJSONRead(texto.text);
        }
        StartCoroutine(Whilee());*/
    }
    #endregion


    public void InitLocalPath(string localPath)
    {
        texto = new TextAsset(localPath);
        markers = new List<GameObject>();
        LocalJSONRead(texto.text);
        StartCoroutine(Whilee());
    }

    public void InitRemotePath(string remotePath)
    {
        texto = new TextAsset(remotePath);
        markers = new List<GameObject>();
        URLJSONRead(texto.text);
        StartCoroutine(Whilee());
    }

    private IEnumerator Whilee()
    {
        while (!isReady) // si aún no se realiza la función con los datos
        {
            listReady = (jsonData.Count) > 0 ? true : false; // se pregunta si existen los datos

            if (listReady) // si existen los datos
            {
                listIncidencias = GetDataFrom(jsonData);
                SetDataWith(listIncidencias);  // se ejecuta la función de llenado de datos
                isReady = true; // se activa la bandera para indicar que ya terminó su función
                
            }
        }
        whilee = true;
        yield return 0;
    }
    public List<dataType> GetDataFrom(List<Data> jData)
    {
        List<dataType> listData = new List<dataType>();
        foreach (var data in jsonData)
        {
            listData.Add(
                new dataType
                {
                    idTicket = data.idTicket,
                    tipo = data.CatDelito.nombre,
                    direccion = data.direccion,
                }
                );
        }
        getData = true;
        return listData;
    }

    public void SetDataWith(List<dataType> data) // PONER AQUI LO QUE SE QUIERE HACER con los datos
    {

        foreach (dataType incidencia in data)
        {
            
            double lng = Convert.ToDouble(incidencia.direccion.lgt);
            double lat = Convert.ToDouble(incidencia.direccion.lat);
            // Create a new marker.
            mark3D = manager.Create(lng, lat, markerPrefab);
            mark3D.label = incidencia.tipo;
            mark3D.OnClick += OnMarkerClick;
            mark3D.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            mark3D.transform.GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 0.5f);
            mark3D.transform.localRotation = Quaternion.Euler(-90, 0, 0);
            markers.Add(mark3D.transform.gameObject);

            
        }
        setData = true;
        Vector2 center; int zoom;
        OnlineMapsUtils.GetCenterPointAndZoom(manager.ToArray(), out center, out zoom);
        //var map = GetComponent<OnlineMaps>();
        map.position = center;
        map.zoom = zoom;
    }
    public void OnReady()
    {

    }
    private void OnMarkerClick(OnlineMapsMarkerBase marker)
    {
        
        Debug.Log(marker.label);
    }
}