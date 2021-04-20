using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using dataType = SetSujetosMasBuscados;

public class SujetosBuscadosManager : ReaderManager
{
    public GameObject cerrado;
    public GameObject abierto;
    public Transform parent;

    public Search searhEngine;
    public TMP_InputField[] txtObj;
    public List<Sujeto> sujetosMasBuscadas;
    public string texto;
    public int searchType; // 0 = sujetos, 1 = casos, 2 = armas, 3 = bandas, 4 = vehiculos 

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
        sujetosMasBuscadas = new List<Sujeto>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        
        foreach (var item in searhEngine.inputFields)
        {
            item.text = "";
        }

        txtObj = new TMP_InputField[searhEngine.inputFields.Length];
        txtObj[searchType] = searhEngine.inputFields[searchType];
        txtObj[searchType].text = texto;

        searhEngine.SearchWithThisData(searhEngine.DBPaths, txtObj);
        StartCoroutine(ops());
    }

    public override void SetObject(GameObject obj, int noDB, int typeOfSearch)
    {
        var t = obj.AddComponent<dataType>();
        t.dbIndex = typeOfSearch;
        t.topList = sujetosMasBuscadas;
    }

    private IEnumerator ops()
    {
        yield return new WaitForSeconds(0.5f);

            var temp = SimplyfyList(sujetosMasBuscadas);
        sujetosMasBuscadas = new List<Sujeto>();
        sujetosMasBuscadas = temp;

        for (int i = 0; i < parent.childCount; i++)
        {
            Destroy(parent.GetChild(i).gameObject);
        }
        /*        public string nombre;
    public string alias;
    public Banda banda;
    public string sexo;
    public string edad;
    public string nivelDeActividad;
    public string nivelDePeligrosidad;*/

        foreach (var item in sujetosMasBuscadas)
        {
            var obj_c = Instantiate<GameObject>(cerrado);
            var obj_a = Instantiate<GameObject>(abierto);

            obj_a.transform.GetChild(0).GetComponent<ToogleActive>().objToToggle = obj_c; //abrir el C
            obj_a.transform.GetChild(1).GetComponent<ToogleActive>().objToToggle = obj_a;//cerrar el A

            obj_c.transform.GetChild(0).GetComponent<ToogleActive>().objToToggle = obj_a; //abrir el A
            obj_c.transform.GetChild(1).GetComponent<ToogleActive>().objToToggle = obj_c;//cerrar el C

            obj_a.SetActive(false);
            obj_c.transform.SetParent(parent);
            obj_a.transform.SetParent(parent);

            obj_a.GetComponent<SujetoData>().sujeto = obj_c.GetComponent<SujetoData>().sujeto = item;

        }
        
    }

    public List<Sujeto> SimplyfyList(List<Sujeto> list) // simplificar lista de un conjunto de sujetos
    {
        var t = new List<Sujeto>(); //creamos una nueva lista de respaldo
        var idxList = new List<string>(); // creamos una nueva lista de ids
        idxList.Add(list[0].id); // agregamos a la lista de ids el primer id
        t.Add(list[0]);

        for (int i = 0; i < list.Count; i++) // revisamos en la lista de ids
        {
            if (!idxList.Contains(list[i].id))
            {
                idxList.Add(list[i].id);
                t.Add(list[i]);
            }
        }
        return t;
    }
}
