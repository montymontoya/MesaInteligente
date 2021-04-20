using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerData : MonoBehaviour
{
    public Data jsonData;
    public GameObject openOnLoad;
    public Data Get() { return jsonData; }

    public void Set(Data externJsonData) { jsonData = externJsonData;
        if (openOnLoad)
        {
            openOnLoad.SetActive(true);
        }
    }

}
