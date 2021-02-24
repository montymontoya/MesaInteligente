using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// *** PRINCIPAL CLASSES *** //

[Serializable]
public class Root
{
    public string api_exception;
    [SerializeField]
    public List<Data> data;// ESTE ES EL CAMPO IMPORTANTE
    public int error_code;
    public string error_message;
    public bool result;
    //public string _0;
}


[Serializable]
public class Data
{
    public CatDelito CatDelito;
    public CatEstatus CatEstatus;
    public CatPrioridad CatPrioridad;
    public string descripcion;
    public Direccion direccion;
    public string fechaAtendio;
    public string fechaCerro;
    public string fechaCreacion;
    public string fechaSucedio;
    public bool figurasPublicas;
    public string fk_idDelito;
    public int fk_idPrioridad;
    public int fk_idStatus;
    public string Icono;
    public Identificacion identificacion;
    public string idTicket;
    public bool mediosComunicacion;
    public string origen;
    public bool relevante;
    public object streaming;
    public List<Accion> acciones;
    public List<Red> red;
    public Banda banda;
    public Bandas bandas;
}

public class Banda
{
    public string nombre;
    public string lider;
    public string delitos;
    public string lugar;
}

public class Bandas
{
    List<Banda> bandas;
}



// *** CLASSES FOR PRINCIPAL CLASS *** //


// *** ACCIONES *** //

[Serializable]
public class Accion
{
    public string comentario;
    public DateTime fecha;
    public string fk_idTicket;
    public int fk_idUsuario;
    public int idcomentario;
    public Direccion direccion;
}

[Serializable]
public class Acciones
{
    public List<Accion> data;

}


// *** ¿? *** //

[Serializable]
public class Identificacion
{
    public string calle;
    public string colonia;
    public string cp;
    public object Cuadrante;
    public string estado;
    public string identificador;
    public string lat;
    public string lgt;
    public string municipio;
    public string propietario;
    public string usuarioEmergencia;
}

[Serializable]
public class CatDenuncia
{
    public int id;
    public string title;
}
[Serializable]
public class CatHecho
{
    public CatDenuncia CatDenuncia;
    public int fk_idDenuncia;
    public int id;
    public string nombre;
}
[Serializable]
public class CatIcono
{
    public int id;
    public string nombre;
    public string nombreEncryptado;
}
[Serializable]
public class CatSeguimiento
{
    public int id;
    public string title;
}
[Serializable]
public class CatDelito
{
    public CatHecho CatHecho;
    public CatIcono CatIcono;
    public CatSeguimiento CatSeguimiento;
    public string descripcion;
    public int fk_idHecho;
    public int fk_idIcono;
    public int fk_idSeguimiento;
    public int id;
    public string nombre;
}
[Serializable]
public class CatEstatus
{
    public int id;
    public string title;
}
[Serializable]
public class CatPrioridad
{
    public string colors;
    public int id;
    public string prioridad;
    public string prioridad_desc;
    public int prioridad_urgency;
}
[Serializable]
public class CatEstado
{
    public int id;
    public string title;
}
[Serializable]
public class CatMunicipio
{
    public CatEstado catEstado;
    public int fk_idEstado;
    public int id;
    public string nombre;
}
[Serializable]
public class Direccion
{
    public string calle;
    public object CatMunicipio;
    public string colonia;
    public string cp;
    public string entrecalles;
    public string entrecalles2;
    public string ext;
    public int fk_idMunicipio;
    public string @int;
    public string lat;
    public string lgt;
    public string referencias;
}

// *** RED DE VINCULOS *** //

[Serializable]
public class Node
{
    public string id;
    public string label;
    public int x;
    public int y;
    public int size;
}

[Serializable]
public class Edge
{
    public string id;
    public string source;
    public int target;
}
[Serializable]
public class Red
{
    public List<Node> nodes;
    public List<Edge> edges;
}


// *** SUJETOS *** //
public class CatRasgo
{
    public int id;
    public string title;
}

public class CatMediafiliacion
{
    public CatRasgo catRasgo;
    public int fk_idRasgo;
    public int id;
    public string nombre;
}

public class Mediafiliacion
{
    public CatMediafiliacion Cat_mediafiliacion;
    public bool estatus;
    public DateTime fecha;
    public int fk_idMediafiliacion;
    public int idSujetoMediafiliacion;
}

[Serializable]
public class Sujeto
{
    public string alias;
    public string apellidoMaterno;
    public string apellidoPaterno;
    public bool clasificacion;
    public string detencion;
    public Direccion direccion;
    public DateTime fecha;
    public object fechadetencion;
    public int fk_idDireccion;
    public int fk_idObjetivo;
    public string fk_idTicket;
    public int fk_idVehiculo;
    public string foto;
    public int idSujeto;
    public bool isObjetivo;
    public List<Mediafiliacion> mediafiliacion;
    public string nombre;
    public string rasgosdist;
    public Vehiculo vehiculo;
}

// *** VEHICULOS *** //

[Serializable]
public class CatColor
{
    public int id;
    public string title;
}
[Serializable]
public class CatMarca
{
    public int id;
    public string title;
}
[Serializable]
public class CatModelo
{
    public CatMarca catMarca;
    public int fk_idMarca;
    public int id;
    public string nombre;
}
[Serializable]
public class CatTipo
{
    public int id;
    public string title;
}
[Serializable]
public class CatUso
{
    public int id;
    public string title;
}

[Serializable]
public class Vehiculo
{
    public string anio;
    public string aseguradora;
    public CatColor catColor;
    public CatModelo catModelo;
    public CatTipo CatTipo;
    public CatUso CatUso;
    public bool clasificacion;
    public string descripcion;
    public Direccion direccion;
    public DateTime fecha;
    public int fk_idColorVehiculo;
    public int fk_idModeloVehiculo;
    public int fk_idObjetivo;
    public string fk_idTicket;
    public int fk_idTipo;
    public int fk_idUso;
    public string foto;
    public int idVehiculo;
    public bool isObjetivo;
    public string placa;
    public string propietario;
    public string repuve;
    public string seriemotor;
    public string serievehiculo;
}




