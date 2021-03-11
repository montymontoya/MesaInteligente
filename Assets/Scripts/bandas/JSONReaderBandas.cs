using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class JSONReaderBandas : MonoBehaviour
{
    public TextAsset jsonFile;
    //public GameObject containerInfoDelitos;
    //public TextMeshProUGUI prefabTextInfoDelito;

    public GameObject[] cells = new GameObject[10];

    public List<Banda> bandasInJson;


    // Start is called before the first frame update
    void Start()
    {
        //bandasInJson = new listJsonUtility.FromJson<Banda>(jsonFile.text);

        foreach (GameObject item in cells)
        {
            Debug.Log(item);

            Debug.Log(item.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text);


            
        }

        //foreach (Banda banda in bandasInJson.bandas)
        //{
        //    Debug.Log(banda.nombre);
        //}


        //foreach (Banda item in bandasInJson.bandas)
        //{
        //var newText = Instantiate(prefabTextInfoDelito, new Vector3(0, 0, 0), Quaternion.identity);
        //newText.text = item.comentario;

        //newText.transform.SetParent(containerInfoDelitos.transform, false);

        //}

        //containerInfoDelitos.transform.GetChild(0).gameObject.GetComponentInChildren<CanvasGroup>().alpha = 1;
    }
}
