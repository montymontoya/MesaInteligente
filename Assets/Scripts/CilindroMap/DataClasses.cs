
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Incidencia
{
    public string idTicket;
    public Direccion direccion;
    public string tipo;
}


[Serializable]
public class CatalogoIncidencias
{
    public List<Incidencia> incidencias;
}



