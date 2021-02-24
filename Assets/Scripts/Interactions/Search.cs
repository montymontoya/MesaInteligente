using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Search : MonoBehaviour
{
    public GameObject[] inputContainerParent; // GameObject padre de un TMP_InputField
    public TMP_InputField[] inputFields; //Componente TMP_InputField
    public JSONReaderBase[] json;
    public GameObject[] DBPaths; // GameObject que contiene una componente SimpleText
    public List<string> searchOn;
    public int idx;
    [HideInInspector]
    public string CoreNode;

    public void SearchNow()
    {
        searchOn = new List<string>();
        idx = 0;
        CoreNode = "";
        var finalString = "ruta";
        foreach (var input in inputFields)
        {
            if (inputContainerParent[idx].activeSelf)
            {
                finalString += "/" + input.text;
                CoreNode += ", " + input.text;
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
}
