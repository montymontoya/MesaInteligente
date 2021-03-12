using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
public class NodeData : MonoBehaviour
{
    public Nodo data;
    public string title;
    public TMP_Text titleContainer;

    public GameObject node;
    public Transform nodeParent;

    private string tp;

    public List<Vinculo> vinculos;

    public bool isReady = false;
    // Start is called before the first frame update
    void Start()
    {


        //titleContainer.text = title;
    }

    private void Update()
    {
        if (!isReady)
        {
            if (data != null)
            {
                selectTitle(data);

                var nodoData = data;
                vinculos = new List<Vinculo>();
                switch (tp)
                {
                    case "sujeto":
                        vinculos = nodoData.sujeto.vinculos;
                        break;
                    case "arma":
                        vinculos = nodoData.arma.vinculos;
                        break;
                }
                isReady = true;
            }
        }
    }

    void selectTitle(Nodo nodoData)
    {
        if (nodoData.sujeto.datosGenerales.alias != null)
        {
            titleContainer.text = nodoData.sujeto.datosGenerales.alias;
        }
        else if (nodoData.arma.datosGenerales.tipo != null)
        {
            titleContainer.text = nodoData.arma.datosGenerales.tipo;
        }
        
    }

    public void setVinculos()
    {


        int idx = 0;

        foreach (var vinculo in vinculos)
        {
            var nodo = Instantiate<GameObject>(node);
            var data = nodo.transform.GetChild(0).GetComponent<NodeData>();
            data = new NodeData();

            nodo.transform.parent = nodeParent;
            nodo.transform.localScale = new Vector3(50, 50, 50);
            /* Edge Connection*/
            var edge = nodo.transform.GetChild(0).GetComponent<NodeEdge>();
            // edge.ChangeLineColor(color, color);
            /* Data Setting */
           
            data.titleContainer.text = vinculo.nombre;
            idx++;
        }
    }
    
}
