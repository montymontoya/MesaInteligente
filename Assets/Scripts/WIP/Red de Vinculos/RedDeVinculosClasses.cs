using System.Collections;
using System.Collections.Generic;
using System;

#region Nodos
[Serializable]
public class Nodo
{
    public Sujeto sujeto;
    public Banda banda;
    public Caso caso;
    public Arma arma;
    public Vehiculo vehiculo;

}

#endregion
#region Clases para SUJETO

[Serializable]
public class Sujeto
{
    public string id;
    public DatosGenerales datosGenerales;
    public MediaFiliacion mediafiliacion;
    public Multimedia multimedia;
    public List<Direccion> ubicacionesProbables;
    public List<Delito> historialDelictivo;
    public List<Vinculo> vinculos;
}

[Serializable]
public class DatosGenerales
{
    /****Sujeto****/
    public string nombre;
    public string alias;
    public Banda banda;
    public string sexo;
    public string edad;
    public string nivelDeActividad; /*Banda tambien*/
    public string nivelDePeligrosidad; /*Banda tambien*/
    /****Banda****/
    public string lider;
    /****Arma*****/
    public string tipo; /*Vehiculo tambien*/
    public string marca; /*Vehiculo tambien*/
    public string modelo; /*Vehiculo tambien*/
    public string calibre;
    public string registro;
    /****Caso****/

    /****Vehiculo****/
    public string version;
    public string color;
    public string año;

}

[Serializable]
public class MediaFiliacion
{
    public List<Seña> señas;
    public List<Tatuaje> tatuajes;
    public string Acento;
    public string Estatura;
    public string Complexion;
    public string Tez;

}

[Serializable]
public class Tatuaje { public string tatuaje; }

[Serializable]
public class Seña { public string seña; }

[Serializable]
public class Multimedia
{
    public List<Fotografia> fotografias;
    public List<Identificacion> identificaciones;
    public List<Video> videos;
    public List<Audio> audios;
}

[Serializable]
public class Fotografia { public string fotografia; }
[Serializable]
public class Identificacion { public string identificacion; }
[Serializable]
public class Video { public string video; }
[Serializable]
public class Audio { public string audio; }

[Serializable]
public class Delito
{
    public string descripcion;
    public Direccion direccion;
    public DateTime fecha;
}


#endregion

#region Clases para Banda
[Serializable]
public class Miembros
{
    public string miembrosEstimado;
    public List<Vinculo> miembrosConocidos;
}
[Serializable]
public class Direccion
{
    public string calle;
    public string numero;
    public string interior;
    public string colonia;
    public string cp;
    public string zona;
    public string comandancia;
    public string ciudad;
    public string estado;
    public string pais;
    public string longitud;
    public string latitud;
}
[Serializable]
public class Logo
{
    public string logo;
}
[Serializable]
public class SeñasParticulares
{
    public string seña;
}
[Serializable]
public class Signos
{
    public List<Logo> logos;
    public List<Seña> señasParticulares;
}
[Serializable]
public class Vinculo
{
    public string nombre;
    public string id;
}
[Serializable]
public class Banda
{
    public string id;
    public string nombre;
    public Miembros miembros;
    public Direccion ubicacion;
    public Signos signos;
    public DatosGenerales datosGenerales;
    public List<Delito> historialDelictivo;
}
#endregion

#region CASO  TODO DELITO EN ADELANTE
[Serializable]
public class Caso
{
    public DatosGenerales datosGenerales;
    public Eventos eventos;
}
[Serializable]
public class Eventos
{
    public Delito delito;
    public PreDelito preDelito;
}
[Serializable]
public class PreDelito
{

}
#endregion

#region ARMA TODO RELLENAR

[Serializable]
public class Arma
{
    public string id;
    public DatosGenerales datosGenerales;
    public List<Vinculo> vinculos;
}



#endregion