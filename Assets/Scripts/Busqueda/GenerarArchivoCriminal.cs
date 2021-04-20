using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using TMPro;
public class GenerarArchivoCriminal : MonoBehaviour
{
    public ManagerData managerData;
    public Data jsonData;
    public ManagerData nextManagerData;
    public UnityEvent genericEvent;

    public GameObject resultadosContainer;
    public GameObject perfilContainer;
    [Header("Variables propias de ArchivoCriminal")]
    public TMP_Text nombre;
    public TMP_Text alias;
    public TMP_Text banda;
    public TMP_Text sexo;
    public TMP_Text edad;
    public SetNiveles nivelDeActividad;
    public SetNiveles nivelDePeligrosidad;
    public Image fotoDePerfil;
    
    public void GeneraArchivo()
    {
        if (managerData.jsonData!=null)
        {
           
            jsonData = managerData.jsonData;
            nextManagerData.jsonData = jsonData;
           nombre.text = jsonData.datosGenerales.nombre;
            alias.text = jsonData.datosGenerales.alias;
            banda.text = jsonData.datosGenerales.banda;
            edad.text = jsonData.datosGenerales.edad;
            nivelDeActividad.SetLevel(Convert.ToInt32(jsonData.datosGenerales.nivelDeActividad));
            nivelDePeligrosidad.SetLevel(Convert.ToInt32(jsonData.datosGenerales.nivelDePeligrosidad));
            sexo.text = jsonData.datosGenerales.sexo;
            StartCoroutine(SetPicture(jsonData.multimedia.fotografias[0].fotografia));
            perfilContainer.SetActive(true);
            genericEvent.Invoke();
        }
        
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
            perfilContainer.SetActive(true);
            resultadosContainer.SetActive(false);
        }
    }
}
