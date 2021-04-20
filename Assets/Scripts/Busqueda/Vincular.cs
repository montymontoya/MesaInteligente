using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using dataType = GetVinculos;
public class Vincular : MonoBehaviour
{
    public ManagerData managerData;
    public Data jsonData;
    public ManagerData nextManagerData;

    public Transform nodeParent;
    public GameObject Node;

    public UnityEvent genericEvent;

    public void Vincula()
    {
        if (managerData.jsonData != null)
        {
            jsonData = managerData.jsonData;

        if (nodeParent.childCount > 0)
        {
            foreach (var child in nodeParent.GetComponentsInChildren<Transform>())
            {
                if (child != nodeParent)
                {
                    Destroy(child.gameObject);
                }
            }

        }
        /*Node Creation and Transform Setting*/
        var nodo = Instantiate<GameObject>(Node);
        nodo.transform.parent = nodeParent;
        nodo.transform.localPosition = Vector3.zero;
        nodo.transform.localScale = new Vector3(50, 50, 50);
        /* Edge Connection*/
        var edge = nodo.transform.GetComponent<NodeEdge>();
        edge.ChangeLineColor(Color.red, Color.red);
        /* Data Setting */
        var data = nodo.transform.GetComponent<NodeData>();

        var sujeto = new Sujeto();
        var banda = new Banda();
        var caso = new Caso();
        var arma = new Arma();
        var vehiculo = new Vehiculo();
        var vinculos = new List<Vinculo>();

        sujeto = new Sujeto
                {
                    id = jsonData.id,
                    datosGenerales = jsonData.datosGenerales,
                    mediafiliacion = jsonData.mediafiliacion,
                    multimedia = jsonData.multimedia,
                    ubicacionesProbables = jsonData.ubicacionesProbables,
                    historialDelictivo = jsonData.historialDelictivo,
                    vinculos = jsonData.vinculos
                };

        var nod = new Nodo
        {
            sujeto = sujeto,
            banda = banda,
            caso = caso,
            arma = arma,
            vehiculo = vehiculo,
            vinculos = data.vinculos

        };

        data.data = nod;

        if (nod.sujeto.id != null)
        {

            data.title = nod.sujeto.datosGenerales.alias;
            data.vinculos = nod.sujeto.vinculos;

        }
        else if (nod.banda.id != null)
        {

            data.title = nod.banda.datosGenerales.nombre;
        }
        else if (nod.arma.id != null)
        {

            data.title = nod.arma.datosGenerales.tipo;
        }
        else if (nod.caso.id != null)
        {

            data.title = nod.caso.datosGenerales.carpetaDeInvestigacion;
        }

        else if (nod.vehiculo.id != null)
        {

            data.title = nod.vehiculo.datosGenerales.modelo;
        }

            genericEvent.Invoke();
    }
    }
}
