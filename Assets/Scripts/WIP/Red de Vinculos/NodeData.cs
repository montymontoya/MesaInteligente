using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NodeData : MonoBehaviour
{
    public Nodo data;
    public string title;
    public TMP_Text titleContainer;
    // Start is called before the first frame update
    void Start()
    {
        if (data!=null)
        {
            selectTitle(data);
        }
        titleContainer.text = title;
    }

    void selectTitle(Nodo nodoData)
    {
        if (nodoData.sujeto.datosGenerales.alias != null)
        {
            title = nodoData.sujeto.datosGenerales.alias;
        }
        else if (nodoData.arma.datosGenerales.tipo != null)
        {
            title = nodoData.arma.datosGenerales.tipo;
        }

    }
}
