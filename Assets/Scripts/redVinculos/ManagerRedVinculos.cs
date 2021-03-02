using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using dataType = Data;

public class ManagerRedVinculos : JSONReaderBase
{
    // *** Variables para leer json *** //

    public TextAsset texto; // Json doc 

    void Start()
    {
        if (texto != null)
        {
           // LocalJSONRead(texto.text);
        }
    }
   
}
