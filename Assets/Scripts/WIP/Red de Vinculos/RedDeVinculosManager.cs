using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using dataType = GetVinculos;
public class RedDeVinculosManager : ReaderManager
{
    [Header("Variables propias de GetVinculos")]
    public Transform nodeParent;
    public GameObject Node;

    public TextAsset texto;
    public Color32[] color;
    public override void SetObject(GameObject objT, int i)
    {
        if (nodeParent.childCount>0)
        {
            foreach (var child in nodeParent.GetComponentsInChildren<Transform>())
            {
                if (child!=nodeParent)
                {
                    Destroy(child.gameObject);
                }
            }

        }
        var t = objT.AddComponent<dataType>();
        t.node = Node;
        t.color = color[i];
        t.nodeParent = nodeParent;
        t.texto = texto;
        
        
    } 

}

[Serializable]
public class Nodo
{
    public DatosGenerales datosGenerales;
    public MediaFiliacion mediafiliacion;
    public Multimedia multimedia;
    public UbicacionesProbables ubicacionesProbables;
    public HistorialDelictivo historialDelictivo;
}

[Serializable]
public class DatosGenerales
{
    public string nombre;
    public string alias;
    public Banda banda;
    public string Sexo;
    public string Edad;
    public string NivelDeActividad;
    public string NivelDePeligrosidad;
}

[Serializable]
public class MediaFiliacion
{
    public Señas señas;
    public Tatuajes tatuajes;
    public string Acento;
    public string Estatura;
    public string Complexion;
    public string Tez;

}

[Serializable]
public class Tatuajes { List<Tatuaje> tatuajes; }
[Serializable]
public class Tatuaje { public string tatuaje; }
[Serializable]
public class Señas { List<Seña> señas; }
[Serializable]
public class Seña { public string seña; }

[Serializable]
public class Multimedia
{
    public Fotografias fotografias;
    public Identificaciones identificaciones;
    public Videos videos;
    public Audios audios;
}

[Serializable]
public class Fotografias { List<Fotografia> fotografias; }
[Serializable]
public class Fotografia { public string fotografia; }
[Serializable]
public class Identificaciones { List<Identificacion> identificaciones; }
[Serializable]
public class Identificacion { public string identificacion; }
[Serializable]
public class Videos { List<Video> videos; }
[Serializable]
public class Video { public string video; }
[Serializable]
public class Audios { List<Audio> audios; }
[Serializable]
public class Audio { public string audio; }




[Serializable]
public class UbicacionesProbables { public List<UbicacionProbable> ubicacionesProbables; }

[Serializable]
public class UbicacionProbable
{
    public string Calle;
    public string Numero;
    public string NumeroInterior;
    public string Colonia;
    public string CP;
    public string CuadranteoZona;
    public string Comandancia;
    public string Ciudad;
    public string Estado;
    public string Pais;
    public Coordenadas coordenadas;
}

[Serializable]
public class Coordenadas { public double longitude; public double latitude; }

[Serializable]
public class HistorialDelictivo
{

}



