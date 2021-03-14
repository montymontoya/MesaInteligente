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

    public int tp;

    public List<Vinculo> vinculos;

    public bool isReady = false;
    // Start is called before the first frame update
    void Start()
    {


        titleContainer.text = title;
    }


   

    public void setVinculos()
    {


        int idx = 0;

        foreach (var vinculo in vinculos)
        {
            var nodo = Instantiate<GameObject>(node);
            var data = nodo.transform.GetChild(0).GetComponent<NodeData>();
            nodo.transform.localPosition = Vector3.zero;
            nodo.transform.localScale = new Vector3(50, 50, 50);
            nodo.transform.parent = nodeParent;

           
            /* Edge Connection*/
            var edge = nodo.transform.GetChild(0).GetComponent<NodeEdge>();
            //edge.ChangeLineColor(color, color);
            /* Data Setting */
           
            //data.titleContainer.text = vinculo.nombre;
            idx++;
        }
    }
    
}
