using System.Collections;
using System.Collections.Generic;
using System;


[Serializable]
public class Data
{
    /****General*****/
    public string id; // todos lo tienen
    public string descripcion; 
    public Direccion direccion; //No todos lo tienen
    public List<Vinculo> vinculos; // Todos lo tienen
    /*+++++++  SUJETO  ++++++++++*/

    public DatosGenerales datosGenerales; // todos lo tienen
    public MediaFiliacion mediafiliacion; 
    public Multimedia multimedia;
    public List<Direccion> ubicacionesProbables;
    public List<Delito> historialDelictivo; // compartido con banda


    /****** BANDA ******/
    public Miembros miembros;
    public Direccion ubicacion;
    public Signos signos;

    /********* ARMA ***********/
    //Clases compartidas: "datosGenerales", "vinculos", "id"

    /********* Para Caso ***********/
    // Clases compartidas: "datosGenerales", "vinculos",
    public Eventos eventos;
    public List<Evidencia> evidencias;
    public ADN_D adn_d;

    /********* Para Vehiculo ***********/
    // clases compartidas: "datosGenerales", "vinculos", "id"
    public Placa placa;
    public List<Arco> arcos;
}


#region Nodos
[Serializable]
public class Nodo
{
    public Sujeto sujeto;
    public Banda banda;
    public Caso caso;
    public Arma arma;
    public Vehiculo vehiculo;
    public List<Vinculo> vinculos;

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
    public string id;
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
    public string tipo; /*Vehiculo tambien*/ /*Caso tambien*/
    public string marca; /*Vehiculo tambien*/
    public string modelo; /*Vehiculo tambien*/
    public string calibre;
    public string registro; /* Caso también */
    /****Caso****/
    public string carpetaDeInvestigacion;
    /****Vehiculo****/
    public string version;
    public string color;
    public string año;
}

[Serializable]
public class MediaFiliacion
{
    public List<string> señas;
    public List<string> tatuajes;
    public string Acento;
    public string Estatura;
    public string Complexion;
    public string Tez;

}

[Serializable]
public class Multimedia
{
    public List<string> imagenes;
    public List<Fotografia> fotografias;
    public List<Identificacion> identificaciones;
    public List<Video> videos;
    public List<Audio> audios;
    public List<string> textos;
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
    public List<string> logos;
    public List<string> señasParticulares;
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
    public Miembros miembros;
    public Direccion ubicacion;
    public Signos signos;
    public DatosGenerales datosGenerales;
    public List<Delito> historialDelictivo;
    public List<Vinculo> vinculos;
}
#endregion

#region CASO  TODO DELITO EN ADELANTE
[Serializable]
public class Caso
{
    public string id;
    public DatosGenerales datosGenerales;
    public Eventos eventos;
    public List<Evidencia> evidencias;
    public ADN_D adn_d;
    public List<Vinculo> vinculos;
}
[Serializable]
public class ADN_D
{

}
[Serializable]
public class Eventos
{
    public Delito delito;
    public PreDelito preDelito;
    public PostDelito postDelito;
    public List<Denuncia> denuncias;
    public List<Seguimiento> seguimientos;
}
[Serializable]
public class Evidencia : Multimedia
{

}

[Serializable]
public class PreDelito
{

}
[Serializable]
public class PostDelito
{

}
[Serializable]
public class Denuncia
{

}
[Serializable]
public class Seguimiento
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

#region ARMA TODO RELLENAR

[Serializable]
public class Vehiculo
{
    public string id;
    public DatosGenerales datosGenerales;
    public Placa placa;
    public List<Arco> arcos;
    public List<Vinculo> vinculos;
}
[Serializable]
public class Placa
{
    public string estado;
    public string pais;
    public string numero;
}
[Serializable]
public class Arco
{
    public DateTime fecha;
    public Direccion ubicacion;
}
#endregion