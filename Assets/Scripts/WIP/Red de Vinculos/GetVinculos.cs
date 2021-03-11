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

    public List<Data> jDatas;
    [Header("Variables generales jsonReaderBase")]
    public List<dataType> drawData; // se declara una variable para guardar los datos

    public override void SetDataFrom(List<Data> jData)
    {
        jDatas = jData;
        drawData = new List<dataType>();
        foreach (var data in jData)
        {
            rellena(data);
            /*
            drawData.Add(
                new dataType
                {
                    sujeto = data.sujeto,
                    banda = data.banda,
                    caso = data.caso,
                    arma = data.arma,
                    vehiculo = data.vehiculo
                }
                );*/
        }
        foreach (dataType value in drawData)
        {
            /*Node Creation and Transform Setting*/
            var nodo = Instantiate<GameObject>(node);
            nodo.transform.parent = nodeParent;
            nodo.transform.localScale = new Vector3(50, 50, 50);
            /* Edge Connection*/
            var edge = nodo.transform.GetChild(0).GetComponent<NodeEdge>();
            edge.ChangeLineColor(color, color);
            /* Data Setting */
            var data = nodo.transform.GetChild(0).GetComponent<NodeData>();
            data.data = value;

            
        }
        isReady = true; // se activa la bandera para indicar que ya terminó su función
    }

    void rellena(Data data)
    {
        var sujeto = new Sujeto();
        var banda = new Banda();
        var caso = new Caso();
        var arma = new Arma();
        var vehiculo = new Vehiculo();

        if (data.sujeto.id != null)
        {
            sujeto = data.sujeto;
        }
        else
        {
            sujeto = new Sujeto
            {
                datosGenerales = data.datosGenerales,
                id = data.id
            };
        }
        if (data.arma.id != null)
        {
            arma = data.arma;
        }
        else
        {
            arma = new Arma
            {
                datosGenerales = data.datosGenerales,
                id = data.id
            };
        }

        drawData.Add(
                new dataType
                {
                    sujeto = sujeto,
                    banda = banda,
                    caso = caso,
                    arma = arma,
                    vehiculo = vehiculo
                }
                );
    }
}

