using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;


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
    public List<Data> jsonData;

    public void LocalJSONRead(string jsonText)
    {
        jsonData.Clear();
        StartCoroutine(GetLocalJsonData(jsonText));
    }

    IEnumerator GetLocalJsonData(string jsonText)
    {
        jsonData = JsonUtility.FromJson<Root>(jsonText).data;
        yield return 0;
    }

    public void URLJSONRead(string URL, string authHeader = "")
    {
        jsonData.Clear();
        StartCoroutine(GetTickets(URL, authHeader));
    }

    IEnumerator GetTickets(string URL, string authHeader ="")
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        www.SetRequestHeader("Authorization", authHeader);
        yield return www.SendWebRequest();
        jsonData = JsonUtility.FromJson<Root>(www.downloadHandler.text).data;
    }

}



