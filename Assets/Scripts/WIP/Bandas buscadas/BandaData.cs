using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Networking;
public class BandaData : MonoBehaviour
{
    public Banda banda;
    /*    public string id;
    public Miembros miembros;
    public Direccion ubicacion;
    public Signos signos;
    public DatosGenerales datosGenerales;
    public List<Delito> historialDelictivo;
    public List<Vinculo> vinculos;*/

    public TMP_Text nombre;
    public TMP_Text lider;
    public TMP_Text miembros;
    public TMP_Text ubicacion;
    public SetNiveles nivelDeActividad;
    public SetNiveles nivelDePeligrosidad;

    // Start is called before the first frame update
    void Start()
    {
        nombre.text = banda.datosGenerales.nombre;
        lider.text = banda.datosGenerales.lider;
        miembros.text = banda.miembros.miembrosEstimado;
        ubicacion.text = banda.ubicacion.ciudad + " , " + banda.ubicacion.estado;
        var lvl = Convert.ToInt32(banda.datosGenerales.nivelDeActividad);
        nivelDeActividad.SetLevel(lvl);
        nivelDePeligrosidad.SetLevel(Convert.ToInt32(banda.datosGenerales.nivelDePeligrosidad));

    }
    /*
    IEnumerator SetPicture(string MediaUrl)
    {
        if (MediaUrl.Length < 2)
        {
            MediaUrl = "https://sumaleeboxinggym.com/wp-content/uploads/2018/06/Generic-Profile-1600x1600.png";
        }

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprt = Sprite.Create(tex,
            new Rect(0, 0, tex.width, tex.height), Vector2.zero);
            fotoDePerfil.sprite = sprt;
            fotoDePerfil.color = Color.white;
        }
    }
    */
}
