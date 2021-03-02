using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public class SearchOn
{
    public List<string> buscarEsto;
}

public class Search : MonoBehaviour
{
    public GameObject[] inputContainerParent; // GameObject padre de un TMP_InputField
    public TMP_InputField[] inputFields; //Componente TMP_InputField

    public GameObject[] DBPaths; // GameObject que contiene una componente SimpleText
    public List<SearchOn> dondeBuscar;

    private List<string> temp;
    private int idx,jdx;

    public List<string> searchOn;

    public ReaderManager manager;

    //ESTE MÉTODO SIRVE PARA BUSCAR UNO POR UNO
    public void SearchNow()
    {
        dondeBuscar = new List<SearchOn>();
        jdx = 0;
        //foreach (var DBPath in DBPaths)
        for (int i = 0; i < DBPaths.Length; i++)
        {
            if (DBPaths[i].activeSelf)
            {
                var DBPathText = DBPaths[i].GetComponent<SimpleText>().Text;
                temp = new List<string>(); idx = 0;
                foreach (var input in inputFields)
                {
                    if (inputContainerParent[idx].activeSelf)
                    {
                        temp.Add(DBPathText + "/" + input.text);
                    }
                    idx++;
                }
                dondeBuscar.Add(new SearchOn { buscarEsto = temp });
            }
            jdx++;
        }

        manager.SetData(dondeBuscar);
    }

         //ESTE MÉTODO SIRVE PARA BUSCAR TODO JUNTO
    /*public void SearchNow()
    {
        searchOn = new List<string>();
        idx = 0;
        var finalString = "ruta";
        foreach (var input in inputFields)
        {
            if (inputContainerParent[idx].activeSelf)
            {
                finalString += "/" + input.text;
            }
            idx++;
        }
        idx = 0;
        foreach (var DBPath in DBPaths)
        {
            var DBPathText = DBPath.GetComponent<SimpleText>().Text;
            if (DBPath.activeSelf)
                searchOn.Add(DBPathText + "/" + finalString);

        }
    }
     
    */
}
