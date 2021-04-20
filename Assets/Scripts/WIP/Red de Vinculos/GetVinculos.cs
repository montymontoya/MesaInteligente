using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

/*CAMBIAR DATA POR LA CLASE EN CUESTION*/
using dataType = Nodo;
public class GetVinculos : JSONReaderBase
{
    [Header(" Variables de switcheo de pantallas")]
    public GameObject redDeVinculosParent;
    public GameObject archivoCriminalParent;

    [Header("Variables propias de GetVinculos")]
    public int dbIndex;
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
        int idx = 0;
        foreach (dataType value in drawData)
        {
            /*Node Creation and Transform Setting*/
            var nodo = Instantiate<GameObject>(node);
            nodo.transform.parent = nodeParent;
            nodo.transform.localPosition = Vector3.zero;
            nodo.transform.localScale = new Vector3(50, 50, 50);
            /* Edge Connection*/
            var edge = nodo.transform.GetComponent<NodeEdge>();
            edge.ChangeLineColor(color, color);
            /* Data Setting */
            var data = nodo.transform.GetComponent<NodeData>();
            data.data = value;
            data.jData = jData[idx];
            if (value.sujeto.id!=null)
            {

                data.title = value.sujeto.datosGenerales.alias;
                data.vinculos = value.sujeto.vinculos;
                
            }
            else if (value.banda.id != null)
            {

                data.title = value.banda.datosGenerales.nombre;
            }
            else if (value.arma.id != null)
            {

                data.title = value.arma.datosGenerales.tipo;
            }
            else if (value.caso.id != null)
            {

                data.title = value.caso.datosGenerales.carpetaDeInvestigacion;
            }

            else if (value.vehiculo.id != null)
            {
 
                data.title = value.vehiculo.datosGenerales.modelo;
            }
            idx++;
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
        var vinculos = new List<Vinculo>();
        
        switch (dbIndex)
        {
            case 0: // sujeto
                sujeto = new Sujeto
                {
                    id = data.id,
                    datosGenerales = data.datosGenerales,
                    mediafiliacion = data.mediafiliacion,
                    multimedia = data.multimedia,
                    ubicacionesProbables = data.ubicacionesProbables,
                    historialDelictivo = data.historialDelictivo,
                    vinculos = data.vinculos
                };
                break;
            case 3: // banda
                banda = new Banda
                {
                    id = data.id,
                    datosGenerales = data.datosGenerales,
                    miembros = data.miembros,
                    ubicacion = data.ubicacion,
                    historialDelictivo = data.historialDelictivo,
                    signos = data.signos,
                    vinculos = data.vinculos
                };
                break;
            case 1: // caso
                caso = new Caso
                {
                    id = data.id,
                    datosGenerales = data.datosGenerales,
                    eventos = data.eventos,
                    evidencias = data.evidencias,
                    adn_d = data.adn_d,
                    vinculos = data.vinculos
                };
                break;
            case 2: // arma
                arma = new Arma
                {
                    id = data.id,
                    datosGenerales = data.datosGenerales,
                    vinculos = data.vinculos
                };
                break;
            case 4: // vehiculo
                vehiculo = new Vehiculo
                {
                    id = data.id,
                    datosGenerales = data.datosGenerales,
                    placa = data.placa,
                    arcos = data.arcos
                };
                break;

        }


        drawData.Add(
                new dataType
                {
                    sujeto = sujeto,
                    banda = banda,
                    caso = caso,
                    arma = arma,
                    vehiculo = vehiculo,
                    vinculos = data.vinculos

                }
                );
    }
}

