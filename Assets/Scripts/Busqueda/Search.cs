using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public struct SearchOn
{
    public List<string> buscarEsto;
}

public class Search : MonoBehaviour
{
    public GameObject[] inputContainerParent; // GameObject padre de un TMP_InputField
    public TMP_InputField[] inputFields; //Componente TMP_InputField

    public bool useAllBDPaths = false;
    public GameObject[] DBPaths; // GameObject que contiene una componente SimpleText
    public string[] param;
    public List<int> queBuscar;
    public List<SearchOn> dondeBuscar;

    private List<string> temp;
    private int idx,jdx;



    public ReaderManager manager;

    //ESTE MÉTODO SIRVE PARA BUSCAR UNO POR UNO
    public void SearchNow()
    {
        SearchWithThisData(DBPaths,inputFields);
    }

    public void SearchWithThisData(GameObject[] DBPaths_,TMP_InputField[] inputFields_)
    {

        dondeBuscar = new List<SearchOn>();
        queBuscar = new List<int>();
        jdx = 0;
        //foreach (var DBPath in DBPaths)
        foreach (var db in DBPaths_)
        {
            
            if (DBPaths[jdx].activeSelf || useAllBDPaths)
            {
                var DBPathText = DBPaths_[jdx].GetComponent<SimpleText>().Text;
                temp = new List<string>();

                idx = 0;
                foreach (var input in inputFields_)
                {
                    if (input != null && input.text.Length > 2)
                    {
                        if (param[idx].Length > 2)
                            temp.Add(DBPathText + "/" + param[idx] + "/" + input.text + ".json");
                        else
                            temp.Add(DBPathText +  "/" + input.text + ".json");

                        queBuscar.Add(idx);
                    }
                    
                    idx++;
                }

                dondeBuscar.Add(new SearchOn { buscarEsto = temp });
            }
            jdx++;
        }
        if (dondeBuscar.Count>0)
        {
            if (dondeBuscar[0].buscarEsto.Count>0)
            {
                manager.SetData(dondeBuscar, queBuscar);
            }
            else
            {
                Debug.Log("Escriba algun parametro");
            }

        }
        else
        {
            Debug.Log("Seleccione alguna base de datos");
        }

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
