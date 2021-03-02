using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*CAMBIAR DATA POR LA CLASE EN CUESTION*/
using dataType = Data;
public class TestJsonReader : JSONReaderBase
{
    
    [Header("TEST JSON READER")]
    public List<dataType> drawData; // se declara una variable para guardar los datos

    public override void SetDataFrom(List<Data> jData)
    {
        drawData = new List<dataType>();
        foreach (var data in jData)
        {
            drawData.Add(
                new dataType
                {
                    /*
                     * Agregar aquí la asignación de valores
                     * para la clase deseada
                     * ejemplo:
                     *  idTicket = data.idTicket,
                     *  direccion = data.direccion,
                     *  
                     */
                    direccion = data.direccion,
                }
                );
        }
        foreach (dataType value in drawData)
        {
            /*Agregar aquí lo que se desea hacer con la lista recien formada
             Ejemplo:
            double lng = Convert.ToDouble(value.direccion.lgt);
            double lat = Convert.ToDouble(value.direccion.lat);
            */
        }
        isReady = true; // se activa la bandera para indicar que ya terminó su función
    }
}
