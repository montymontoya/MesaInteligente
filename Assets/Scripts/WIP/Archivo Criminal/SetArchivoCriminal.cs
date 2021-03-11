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

    [Header("Variables generales jsonReaderBase")]
    public List<dataType> drawData; // se declara una variable para guardar los datos

    public override void SetDataFrom(List<Data> jData)
    {
        drawData = new List<dataType>();
        foreach (var data in jData)
        {
            var dato = data.perfil;
            drawData.Add(
                new dataType
                {
                    nombre = dato.nombre,
                    alias = dato.alias,
                    banda = dato.banda,
                    edad = dato.edad,
                    nivelDeActividad = dato.nivelDeActividad,
                    nivelDePeligrosidad = dato.nivelDePeligrosidad,
                    sexo = dato.sexo,
                    foto = dato.foto
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

