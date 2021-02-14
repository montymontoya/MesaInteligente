using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class createNodes : MonoBehaviour
{

    //// *** General band *** //

    //public bool isReady;

    //// *** JSON *** //

    //public JSONReaderAnalitica json;

    //// *** Nodes *** //

    //private int totalNodes;
    //private List<Tickets> infoNodes;

    //private float axisX;
    //private float axisY;
    //private float axisZ;

    //private GameObject newNode;
    //public GameObject prefabNewNode;
    //public Transform parentNodes;

    //private string contentNewNode;

    //// *** Connections *** //

    //private bool nodesComplete;

    //public GameObject parentConnections;
    //public GameObject prefabConnection;

    //private bool isFirstNewNode;

    //private void Update()
    //{
        
    //    if (!isReady)
    //    {
    //        totalNodes = json.data.Count;

    //        if (totalNodes != 0)
    //        {

    //            infoNodes = json.data;

    //            foreach (Tickets item in infoNodes)
    //            {
    //                // *** Create Nodes *** //

    //                axisX = Random.Range(-49, 50);
    //                axisY = Random.Range(-29, 30);
    //                axisZ = Random.Range(-13, 14);

    //                newNode = Instantiate(prefabNewNode, new Vector3(axisX, axisY, axisZ), Quaternion.identity);
    //                newNode.transform.SetParent(parentNodes, false);

    //                if (!isFirstNewNode)
    //                {
    //                    newNode.name = "Node0";
    //                    isFirstNewNode = true;
    //                }

    //                contentNewNode = "";

    //                if (!string.IsNullOrEmpty(item.descripcion))
    //                {
    //                    contentNewNode = contentNewNode + "Descripción: " + item.descripcion.ToLower() + "\n";
    //                }

    //                if (!string.IsNullOrEmpty(item.idTicket))
    //                {
    //                    contentNewNode = contentNewNode + "Ticket: " + item.idTicket.ToLower() + "\n";
    //                }

    //                if (!string.IsNullOrEmpty(item.origen))
    //                {
    //                    contentNewNode = contentNewNode + "Origen: " + item.origen.ToLower() + "\n";
    //                }

    //                newNode.GetComponentInChildren<Text>().text = contentNewNode;
                    

    //                // *** Create Connections *** //

    //                Instantiate(prefabConnection, new Vector3(0, 0, 0), Quaternion.identity).transform.parent = parentConnections.transform;

    //            }


    //            isReady = true;
    //            nodesComplete = true;
    //        }
    //    }
    //}
}