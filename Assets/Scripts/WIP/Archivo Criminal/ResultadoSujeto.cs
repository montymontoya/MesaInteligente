using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
public class ResultadoSujeto : MonoBehaviour
{
    [Header("Variables propias de ArchivoCriminal")]
    public TMP_Text nombre;
    public TMP_Text alias;
    public TMP_Text banda;
    public TMP_Text sexo;
    public TMP_Text edad;
    public SetNiveles nivelDeActividad;
    public SetNiveles nivelDePeligrosidad;
    public Image fotoDePerfil;

    public Perfil perfil;

    public void setThis()
    {

             nombre.text = perfil.nombre;
             alias.text = perfil.alias;
             banda.text = perfil.nombre;
             edad.text = perfil.edad;
             nivelDeActividad.SetLevel(Convert.ToInt32(perfil.nivelDeActividad));
             nivelDePeligrosidad.SetLevel(Convert.ToInt32(perfil.nivelDePeligrosidad));
             sexo.text = perfil.sexo;
             StartCoroutine(SetPicture(perfil.foto));
    }

    IEnumerator SetPicture(string MediaUrl)
    {
        if (MediaUrl == null)
        {
            MediaUrl = "https://sumaleeboxinggym.com/wp-content/uploads/2018/06/Generic-Profile-1600x1600.png";
        }
        Debug.Log(MediaUrl);
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
            gameObject.SetActive(false);
        }
    }
}