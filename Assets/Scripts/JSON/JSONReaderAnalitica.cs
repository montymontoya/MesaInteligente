using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using Datum = Data;
public class JSONReaderAnalitica : MonoBehaviour
{
    //string reqURL = "http://eonproduccion.net:31000/v2017001/API/Analitica/911/tickets/2102100313";
    string reqURL = "http://eonproduccion.net:31000/v2017001/API/Analitica/911/tickets";
    public List<Datum> data;
    private Root eventos;
    public int qtyEvents;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(GetText());

    }
    
    IEnumerator getCadena()
    {
        qtyEvents = eventos.data.Count;
        for (int idx = 0; idx < qtyEvents; idx++)
        {
            data.Add(eventos.data[idx]);
        }
        yield return 0;
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get(reqURL);
        www.SetRequestHeader("Authorization", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOiIxNTEzODEwMjc3IiwiaWF0IjoiMTUxMzgxMDI3NyIsImlkUHJvZmlsZSI6MSwianRpIjoiOTZCM0JCRTUtRUYxNS00RjQxLUIzOEItRjJCMUNFRDc0RkZCIiwic2VjcmV0IjoiSkwyU0daQ1BOM0NIRE9NSlpXQkozRjRNT0lWSVI3WFlSWlpQQ0g3QlJORlpBV1FFR0pNN1gzU1VHRDRIV01LS1I1WFVERENNNjNFN1FEVUtES0hRUjczQkRDVzJHU0U1VFdUTEJDWSIsInN1YiI6MSwidmFsaWRpdHkiOjB9.go9Nudv0toho05HhzkLsV6OikO5KmDvZMrFdn6p2JwQ=");

        Debug.Log(www);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            //Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            //byte[] results = www.downloadHandler.data;
            
             eventos = JsonUtility.FromJson<Root>(www.downloadHandler.text);
             StartCoroutine(getCadena());

        }
    }
}
