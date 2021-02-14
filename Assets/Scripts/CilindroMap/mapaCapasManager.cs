using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class mapaCapasManager : MonoBehaviour
{
    public TextAsset iEsperada, iReal;
    public CapasIncidencias incidenciaReal;
    public CapasIncidencias incidenciaEsperada;
    public CapasIncidencias ajuste = new CapasIncidencias();
    public void Start()
    {
        //incidenciaReal.InitLocalPath(iEsperada.text);
        incidenciaEsperada.InitLocalPath(iReal.text);
    }
    /*
    private void Update()
    {
        if (incidenciaEsperada.isReady && incidenciaReal.isReady)
        {
            /*Insertar ajuste aquí*/
            /*
             * ajuste.listIncidencias=ajusteCalculado;
             * ajuste.SetDataWith(ajuste);
             * 
             *

        }
    }
 
    /*
     * error = datoEsperado - datoReal
     * ajuste = datoEsperado+error
     * ajuste = datoEsperado+datoEsperado-datoReal
     * ajuste = datoEsperado(1-datoReal)
     */
}
