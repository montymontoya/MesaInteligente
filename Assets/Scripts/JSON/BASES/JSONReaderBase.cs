using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

[Serializable]
public class JSONReaderBase : MonoBehaviour
{
    /*
    public enum jsonPath
    {
        local,
        url,
    }
    public jsonPath opcion = jsonPath.url;
    
    [Header("LOCAL JSON PATH")]
    public TextAsset json;
    [Header("URL JSON PATH")]
    public string baseURL = "http://eonproduccion.net:31000";
    public string basePath = "v2017001/API";
    public string api = "Analitica";
    public string api_ = "911";
    public string params_ = "tickets";
    public string authHeader = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOiIxNTEzODEwMjc3IiwiaWF0IjoiMTUxMzgxMDI3NyIsImlkUHJvZmlsZSI6MSwianRpIjoiOTZCM0JCRTUtRUYxNS00RjQxLUIzOEItRjJCMUNFRDc0RkZCIiwic2VjcmV0IjoiSkwyU0daQ1BOM0NIRE9NSlpXQkozRjRNT0lWSVI3WFlSWlpQQ0g3QlJORlpBV1FFR0pNN1gzU1VHRDRIV01LS1I1WFVERENNNjNFN1FEVUtES0hRUjczQkRDVzJHU0U1VFdUTEJDWSIsInN1YiI6MSwidmFsaWRpdHkiOjB9.go9Nudv0toho05HhzkLsV6OikO5KmDvZMrFdn6p2JwQ=";
    
    [HideInInspector]
    public string jsonText;
    [HideInInspector]
    public string errorText;
    
    [Header("url resultante")]
    public string URL;
    [Header("Catálogo de Tickets resultate/Debug")]
    */

    [Header("TEST JSON READER")]

    public bool isReady = false; // esta bandera sirve de apoyo para indicarle al sistema hasta cuando dejar de ejecutarse.
    public bool listReady; // esta bandera sirve de apoyo para saber en qué momento ya existen datos
    public string texto;
    public List<Data> jsonData;

    public void InitLocalPath(string localPath)
    {
        StartCoroutine(GetLocalJsonData(localPath));

    }

    IEnumerator GetLocalJsonData(string jsonText)
    {
        jsonData = JsonUtility.FromJson<Root>(jsonText).data;
        StartCoroutine(Whilee());
        yield return 0;
    }

    public void InitRemotePath(string remotePath)
    {
        texto = "";
        jsonData = new List<Data>();
        StartCoroutine(GetRemoteJsonData(remotePath, ""));

    }

    IEnumerator GetRemoteJsonData(string URL, string authHeader = "")
    {
        //Debug.Log("GET REMOTE DATA");
        UnityWebRequest www = UnityWebRequest.Get(URL);
        www.SetRequestHeader("Authorization", authHeader);
        yield return www.SendWebRequest();
        if (www.isNetworkError)
        {
            //Debug.Log(www.error);
            //jsonData = JsonUtility.FromJson<Root>(texto.text).data;
            //StartCoroutine(Whilee());
        }
        else
        {
            texto = www.downloadHandler.text;
            Debug.Log(texto.Length);
            if (texto.Length>1)
            {
                var json = JsonUtility.FromJson<Root>(texto);
                jsonData = json.data;
                StartCoroutine(Whilee());
            }
            
        }
    }

    private IEnumerator Whilee()
    {
        //Debug.Log("Whilee");
        while (!isReady) // si aún no se realiza la función con los datos
        {
            if (jsonData != null)
                listReady = (jsonData.Count) > 0 ? true : false; // se pregunta si existen los datos

            
            if (listReady) // si existen los datos
                SetDataFrom(jsonData);
        }
        yield return 0;
    }

    public virtual void SetDataFrom(List<Data> jData)
    {

    }

}




