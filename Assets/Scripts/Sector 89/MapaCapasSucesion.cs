using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/* con este código se muestran los marcadores de la incidencia esperada vs real vs ajuste
 * concepto:
 *  se tienen 3 métodos
 *      1- toggle de marcadores de incidencia esperada
 *      2- toggle de marcadores de incidencia real
 *      3- toggle de marcadores de ajuste en la incidencia
 *  Cada método debe ser llamado externamente por botones
 * Al inicio de la ejecución, por medio de llamados de función, se muestran los marcadores de los 3 componentes (esperado, real, ajuste)  
 *  Después, se tendrán 2 métodos de llenado externo (por si se quiere cambiar la información) y 1 interno (calculo de ajuste)
 *      1 - incidencia esperada con info nueva/diferente
 *      2 - incidencia real con info nueva/diferente
 *      3 - ajuste de incidencia (llamar siempre después de un cambio)
 */

public class MapaCapasSucesion : MonoBehaviour
{
    public TextAsset iEsperada, iReal;
    private TextAsset iAjuste;

    public CapasIncidencias inEsperada, inReal, inAjuste;

    public bool isReady;

    public bool eStatus = true;
    public bool rStatus = true;
    public bool aStatus = true;

    private void Start()
    {
        inEsperada.InitLocalPath(iEsperada.text);

        inReal.InitLocalPath(iReal.text);

        //inAjuste
    }

    private void Update()
    {
        if (!isReady && inEsperada.isReady && inEsperada.isReady)
        {
            isReady = true;
            Debug.Log("incidencia ajuste");
            /*Insertar ajuste aquí*/
            /*
             * ajuste.listIncidencias=ajusteCalculado;
             * ajuste.SetDataWith(ajuste);
             * 
             */

        }
    }

    public void ToggleEsperado()
    {

        eStatus = !eStatus;
        foreach(var item in inEsperada.markers)
        {
            item.SetActive(eStatus);
        }
    }
    public void ToggleReal()
    {
        rStatus = !rStatus;
        foreach (var item in inReal.markers)
        {
            item.SetActive(rStatus);
        }
    }
    public void ToggleAjuste()
    {
        aStatus = !aStatus;
        foreach (var item in inAjuste.markers)
        {
            item.SetActive(aStatus);
        }
    }
}
 