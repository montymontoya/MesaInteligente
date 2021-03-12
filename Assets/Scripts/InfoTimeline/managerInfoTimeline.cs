using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEngine.UI;
using TMPro;

using dataType = Accion;

public class managerInfoTimeline : JSONReaderBase
{
    // *** Variables para leer json *** //

    public TextAsset texto; // Json doc 
    private List<dataType> listAcciones; // Lista para guardar la información del json
    private bool isReady = false; // Valida la ejecución del código
    private bool isListReady; // Valida existencia de datos

    // *** Variables para mostrar los datos *** //

    public GameObject generalContainer;
    public GameObject prefabContainerInfo;
    public TextMeshProUGUI prefabTextInfo;

    void Start()
    {
     
        if (texto != null)
        {
            //LocalJSONRead(texto.text);
        }

        StartCoroutine(Whilee());
    }

    // *** Función que llama a las funciones para obtener datos y mostrarlos solo cuando existan datos en el archivo json.  *** //
    // *** La variable isReady asegura que lo anterior solo se realice una vez. *** //

    private IEnumerator Whilee()
    {
        if (!isReady)
        {
            isListReady = (jsonData.Count) > 0 ? true : false; 

            if (isListReady) 
            {
                listAcciones = GetDataFrom(jsonData);
                SetDataWith(listAcciones);
                isReady = true; 
            }
        }
        yield return 0;
    }

    // *** Función para generar una lista con la información que se necesita del Json.  *** //

    public List<dataType> GetDataFrom(List<Data> jData)
    {
        List<dataType> listData = new List<dataType>();
/*
        foreach (var item in jsonData)
        {
            foreach (var accion in item.acciones)
            {
                listData.Add(
                    new dataType
                    {
                        comentario = accion.comentario,
                    }
                );
            }
        }*/
        return listData;
    }

    // *** Función para mostrar los datos en el entorno 3D *** //

    public void SetDataWith(List<dataType> data) // PONER AQUI LO QUE SE QUIERE HACER con los datos
    {

        foreach (dataType item in listAcciones)
        {
            var containerInfo = Instantiate(prefabContainerInfo, new Vector3(0, 0, 0), Quaternion.identity);
            containerInfo.transform.SetParent(generalContainer.transform, false);

            var textInfo = Instantiate(prefabTextInfo, new Vector3(0, 0, 0), Quaternion.identity);
            textInfo.transform.SetParent(containerInfo.transform.GetChild(0).transform, false);
            textInfo.text = CapitalizeFirstLetter(item.comentario.ToLower());

        }

        // TODO: Esto debe cambiar de acuerdo a la hora
        generalContainer.transform.GetChild(0).gameObject.GetComponentInChildren<CanvasGroup>().alpha = 1;
    }

    private string CapitalizeFirstLetter(string textToChange)
    {
        char[] newText = textToChange.ToCharArray();

        newText[0] = char.ToUpper(newText[0]);

        return new string(newText);
    }

}
