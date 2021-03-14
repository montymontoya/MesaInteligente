using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeConnection : MonoBehaviour
{
    public Transform nodeToAttatch; // nodo principal
    public Transform childrenNodesParent; // contenedor de nodos hijos
    //public Rigidbody coreNodeRB; // rigidBody del nodo principal
    public int prevQtyChildren;
    public int actualQtyChildren;
    public Transform[] childrenNodes; // nodos hijos
    public int angle;
    private Vector3 coreNodeLocalPosition;

    private NodeEdge nodeEdge;
    private NodeData nodeData;
    void Start()
    {
        actualQtyChildren = childrenNodesParent.childCount;
        //prevQtyChildren = actualQtyChildren = 0;
       
    }


    // Update is called once per frame
    void Update()
    {
        
        actualQtyChildren = childrenNodesParent.childCount; // se lee la cantidad de hijos (nodos) en el padre de los nodos
        if (actualQtyChildren != prevQtyChildren && actualQtyChildren > 0) // si hay más nodos
        {
            angle = 360 / actualQtyChildren;
            childrenNodes = new Transform[actualQtyChildren]; // se limpia la lista de nodos creando una nueva con un tamaño igual a la cantidad de nodos
            var idx = 0; // se inicializa el contador con 0;
            
            foreach (var item in childrenNodes) // para cada nodo en la lista de nodos
            {
                
                childrenNodes[idx] = childrenNodesParent.GetChild(idx);
                /* 
                 * el nodo con indice idx de la lista será el primer hijo (GetChild(0)) de cada nodo (GetChild(idx))
                 * del padre de nodos o contenedor de nodos (childrenNodesParent)
                 */
                childrenNodes[idx].localPosition = Vector3.zero;
                childrenNodes[idx].GetChild(0).localPosition = posicion((idx)*angle);
                nodeEdge = childrenNodes[idx].GetComponent<NodeEdge>();
                nodeEdge.nodeToAttatch = nodeToAttatch;


                /*TODO MAGNETIZAR LOS NODOS
                if (!childrenNodes[idx].GetComponent<Rigidbody>()) // si el hijo no tiene un rigidBody
                    childrenNodes[idx].gameObject.AddComponent<Rigidbody>(); // se le agrega uno
                
                SpringJoint childJoint = childrenNodes[idx].gameObject.AddComponent<SpringJoint>();// se agrega una union del nodo hijo
                childJoint.connectedBody = coreNode.GetComponent<Rigidbody>(); // hacia el nodo padre
                childJoint.anchor = Vector3.zero;
                */
                idx++; // se incrementa el contador
                /*esto se realiza en un foreach en lugar de un for para paralelizar la obtención de los hijos*/
            }
            
        }
        prevQtyChildren = actualQtyChildren;
    }



    public Vector3 posicion(float degSeparation)
    {
        var radians = degSeparation * Mathf.PI / 180;

        Vector3 pos = new Vector3();
        pos.x = 2 * Mathf.Cos(radians);
        pos.y = 2 * Mathf.Sin(radians) ;
        pos.z = Random.Range(-1,1);
        //if (degSeparation>180)
          //  pos.z *= -1;
        //Debug.Log(degSeparation+"---" +pos);
        return pos;
    }

}
