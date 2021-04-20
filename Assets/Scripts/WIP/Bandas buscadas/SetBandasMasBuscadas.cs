using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using dataType = Banda;
public class SetBandasMasBuscadas : JSONReaderBase
{
    public List<Data> jDatas;
    public int dbIndex;
    public List<dataType> drawData;
    public List<dataType> topList;
    public override void SetDataFrom(List<Data> jData)
    {
        jDatas = jData;
        //Debug.Log(jData.Count);
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
        //        foreach (dataType value in drawData)
        //      {


        //    }
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

        drawData.Add(banda);
        topList.Add(banda);
    }
}


