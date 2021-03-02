using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

/*CAMBIAR DATA POR LA CLASE EN CUESTION*/
using dataType = Nodo;
public class GetVinculos : JSONReaderBase
{
    [Header("Variables propias de GetVinculos")]
    public Transform nodeParent;
    public GameObject node;

    public Color32   color;

    [Header("Variables generales jsonReaderBase")]
    public List<dataType> drawData; // se declara una variable para guardar los datos

    public override void SetDataFrom(List<Data> jData)
    {
        drawData = new List<dataType>();
        foreach (var data in jData)
        {
            drawData.Add(
                new dataType
                {

                    datosGenerales = data.datosGenerales,
                    mediafiliacion = data.mediafiliacion,
                    multimedia = data.multimedia,
                    ubicacionesProbables = data.ubicacionesProbables,
                    historialDelictivo = data.historialDelictivo

                }
                );
        }
        foreach (dataType value in drawData)
        {
            var nodo = Instantiate<GameObject>(node);
            nodo.transform.parent = nodeParent;
            nodo.transform.localScale = new Vector3(50, 50, 50);
            
            nodo.transform.GetChild(0).GetComponent<NodeEdge>().ChangeLineColor(color, color);


            //node.transform.localPosition = 
            /*Agregar aquí lo que se desea hacer con la lista recien formada
             Ejemplo:
            double lng = Convert.ToDouble(value.direccion.lgt);
            double lat = Convert.ToDouble(value.direccion.lat);
            */
        }
        isReady = true; // se activa la bandera para indicar que ya terminó su función
    }

}

