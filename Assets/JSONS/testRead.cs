using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class testRead : MonoBehaviour
{
    public string json;
    public Root jsonData;
    public string remotePath;
    public void Start( )
    {
        Debug.Log(remotePath);
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
            Debug.Log(www.error);
            //jsonData = JsonUtility.FromJson<Root>(texto.text).data;
            //StartCoroutine(Whilee());
        }
        else
        {
            json = www.downloadHandler.text;
            jsonData = JsonUtility.FromJson<Root>(json);
            //StartCoroutine(Whilee());
        }

    }
}
