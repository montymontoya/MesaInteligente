using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using dataType = SetSujetosMasBuscados;

public class SujetosBuscadosManager : ReaderManager
{
    public GameObject[] cerrado;
    public GameObject[] abierto;
    public Transform parent;

    public Search searhEngine;
    public TMP_InputField[] txtObj;
    public List<Banda> bandasMasBuscadas;
    public string texto;
    public int searchType; // 0 = sujetos, 1 = casos, 2 = armas, 3 = bandas, 4 = vehiculos 

    public int prevQtyChildren, actualQtyChildren;
    void Start()
    {/*
        txtObj = new TMP_InputField[searhEngine.inputFields.Length];
        txtObj[searchType] = searhEngine.inputFields[searchType];
        texto = txtObj[searchType].text = "bandasMasBuscadas";

        searhEngine.SearchWithThisData(searhEngine.DBPaths, txtObj);
        */
    }

    // Update is called once per frame
    public void searchNow()
    {
        bandasMasBuscadas = new List<Banda>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        actualQtyChildren = transform.childCount;

        foreach (var item in searhEngine.inputFields)
        {
            item.text = "";
        }

        txtObj = new TMP_InputField[searhEngine.inputFields.Length];
        txtObj[searchType] = searhEngine.inputFields[searchType];
        texto = txtObj[searchType].text = "bandasMasBuscadas";

        searhEngine.SearchWithThisData(searhEngine.DBPaths, txtObj);
        StartCoroutine(ops());
    }

    public override void SetObject(GameObject obj, int noDB, int typeOfSearch)
    {
        var t = obj.AddComponent<dataType>();
        t.dbIndex = typeOfSearch;
        t.bandasMasBuscadas = bandasMasBuscadas;
    }

    private IEnumerator ops()
    {
        yield return new WaitForSeconds(0.5f);
        actualQtyChildren = bandasMasBuscadas.Count;

            var temp = bandasMasBuscadas;
            bandasMasBuscadas = new List<Banda>();
            for (int i = 1; i < temp.Count; i++)
            {
                bandasMasBuscadas.Add(temp[i]);
            }

        foreach (var item in bandasMasBuscadas)
        {
            
        }
        
    }


}
