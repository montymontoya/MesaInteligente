using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeConnection : MonoBehaviour
{
    public Transform coreNode; // nodo principal
    public Transform childrenNodesParent; // contenedor de nodos hijos
    public Rigidbody coreNodeRB; // rigidBody del nodo principal
    public int prevQtyChildren;
    public int actualQtyChildren;
    public Transform[] childrenNodes; // nodos hijos
    private Vector3 coreNodeLocalPosition;

    private NodeEdge nodeEdge;
    private NodeData nodeData;
    void Start()
    {
        prevQtyChildren = actualQtyChildren = 0;
    }


    // Update is called once per frame
    void Update()
    {
        
        actualQtyChildren = childrenNodesParent.childCount; // se lee la cantidad de hijos (nodos) en el padre de los nodos
        
        if (actualQtyChildren > prevQtyChildren) // si hay más nodos
        {
            childrenNodes = new Transform[actualQtyChildren]; // se limpia la lista de nodos creando una nueva con un tamaño igual a la cantidad de nodos
            var idx = 0; // se inicializa el contador con 0;
            foreach (Transform item in childrenNodes) // para cada nodo en la lista de nodos
            {
                childrenNodes[idx] = childrenNodesParent.GetChild(idx).GetChild(0);
                /* 
                 * el nodo con indice idx de la lista será el primer hijo (GetChild(0)) de cada nodo (GetChild(idx))
                 * del padre de nodos o contenedor de nodos (childrenNodesParent)
                 */
                nodeEdge = childrenNodes[idx].GetComponent<NodeEdge>();
                nodeEdge.NodeToAttatch = coreNode;


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
            prevQtyChildren = actualQtyChildren;
        }
        
    }

}
