using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using TMPro;

/*CAMBIAR DATA POR LA CLASE EN CUESTION*/
using dataType = Perfil;
public class SetArchivoCriminal : JSONReaderBase
{
    public GameObject perfilContainer;
    public GameObject resultadosContainer;
    [Header("Variables propias de SetArchivoCriminal")]
    public TMP_Text nombre;
    public TMP_Text alias;
    public TMP_Text banda;
    public TMP_Text sexo;
    public TMP_Text edad;
    public SetNiveles nivelDeActividad;
    public SetNiveles nivelDePeligrosidad;
    public Image foto;

    public Transform dataContainerParent;
    public GameObject dataContainerPrefab;

    public List<Data> jDatas;
    [Header("Variables generales jsonReaderBase")]
    public List<dataType> drawData; // se declara una variable para guardar los datos



    public override void SetDataFrom(List<Data> jData)
    {
        jDatas = jData;
        drawData = new List<dataType>();
        foreach (var data in jData)
        {
                var _dato = data.datosGenerales;
                var _multimedia = data.multimedia;
                drawData.Add(
                                new dataType
                                {
                                    nombre = _dato.nombre,
                                    alias = _dato.alias,
                                    banda = _dato.banda,
                                    edad = _dato.edad,
                                    nivelDeActividad = _dato.nivelDeActividad,
                                    nivelDePeligrosidad = _dato.nivelDePeligrosidad,
                                    sexo = _dato.sexo,
                                    multimedia = _multimedia
                                    
                                }
                                );

            
        }

        foreach (dataType item in drawData)
        {
            var obj = Instantiate<GameObject>(dataContainerPrefab);
            obj.transform.parent = dataContainerParent;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localEulerAngles = Vector3.zero;
            ResultadoSujeto rS = obj.GetComponent<ResultadoSujeto>();
            rS.perfilContainer = perfilContainer;
            rS.resultadosContainer = resultadosContainer;
            rS.nombre = nombre;
            rS.alias = alias;
            rS.banda = banda;
            rS.sexo = sexo;
            rS.edad = edad;
            rS.nivelDeActividad = nivelDeActividad;
            rS.nivelDePeligrosidad = nivelDePeligrosidad;
            rS.fotoDePerfil = foto;
            rS.perfil = item;
            
        }
        isReady = true; // se activa la bandera para indicar que ya terminó su función
    }


}

