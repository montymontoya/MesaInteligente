using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using dataType = SetArchivoCriminal;
public class ArchivoCriminalManager : ReaderManager
{
    //General
    public string texto;
    public Transform resultadoParent;
    public GameObject resultadoPrefab;
    //Propias
    [Header("Variables propias de ArchivoCriminal")]
    public TMP_Text nombre;
    public TMP_Text alias;
    public TMP_Text banda;
    public TMP_Text sexo;
    public TMP_Text edad;
    public SetNiveles nivelDeActividad;
    public SetNiveles nivelDePeligrosidad;
    public Image fotoDePerfil;
    //
    public override void SetObject(GameObject objT, int i)
    {
        var t = objT.AddComponent<dataType>();
        t.dataContainerParent = resultadoParent;
        t.dataContainerPrefab = resultadoPrefab;

        t.nombre = nombre;
        t.alias = alias;
        t.banda = banda;
        t.edad = alias;
        t.nivelDeActividad = nivelDeActividad;
        t.nivelDePeligrosidad = nivelDePeligrosidad;
        t.sexo = sexo;
        t.foto = fotoDePerfil;
        t.texto = texto;
    }
}
