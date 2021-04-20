using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Networking;
public class SujetoData : MonoBehaviour
{
    public Sujeto sujeto;


    public TMP_Text nombre;
    public TMP_Text alias;
    public TMP_Text banda;
    public TMP_Text sexo;
    public TMP_Text edad;
    public SetNiveles nivelDeActividad;
    public SetNiveles nivelDePeligrosidad;
    public Image fotoDePerfil;


    // Start is called before the first frame update
    void Start()
    {
        nombre.text = sujeto.datosGenerales.nombre;
        alias.text = sujeto.datosGenerales.alias;
        banda.text = sujeto.datosGenerales.banda;
        edad.text = sujeto.datosGenerales.edad;
        var lvl = Convert.ToInt32(sujeto.datosGenerales.nivelDeActividad);

        nivelDeActividad.SetLevel(lvl);
        nivelDePeligrosidad.SetLevel(Convert.ToInt32(sujeto.datosGenerales.nivelDePeligrosidad));
        sexo.text = sujeto.datosGenerales.sexo;
        StartCoroutine(SetPicture(sujeto.multimedia.fotografias[0].fotografia));
    }

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
    
}
