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
    public bool isReady = false; // esta bandera sirve de apoyo para indicarle al sistema hasta cuando dejar de ejecutarse.
    public bool listReady; // esta bandera sirve de apoyo para saber en qué momento ya existen datos
    public TextAsset texto;


    void Start()
    {
        if (texto != null)
        {
            LocalJSONRead(texto.text);
        }
        StartCoroutine(Whilee());
    }

    public void InitLocalPath(string localPath)
    {
        texto = new TextAsset(localPath);
        LocalJSONRead(texto.text);
        StartCoroutine(Whilee());
    }

    public void InitRemotePath(string remotePath)
    {
        texto = new TextAsset(remotePath);
        URLJSONRead(texto.text);
        StartCoroutine(Whilee());
    }

    private IEnumerator Whilee()
    {
        while(!isReady) // si aún no se realiza la función con los datos
        {
            listReady = (jsonData.Count) > 0 ? true : false; // se pregunta si existen los datos

            if (listReady) // si existen los datos
            {
                drawData = GetDataFrom(jsonData);
                SetDataWith(drawData);  // se ejecuta la función de llenado de datos
                isReady = true; // se activa la bandera para indicar que ya terminó su función
            }
        }
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
        return listData;
    }

    public void SetDataWith(List<dataType> data) // PONER AQUI LO QUE SE QUIERE HACER con los datos
    {

        foreach (dataType value in data)
        {
            /*Agregar aquí lo que se desea hacer con la lista recien formada
             Ejemplo:
            double lng = Convert.ToDouble(value.direccion.lgt);
            double lat = Convert.ToDouble(value.direccion.lat);
            */
        }
    }
}
