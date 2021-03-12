using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ReaderManager : MonoBehaviour
{
    public List<SearchOn> DBPath; //variable donde se encuentran las rutas de las bases de datos
    public GameObject t; // objeto vac�o donde se meteran los objetos resultado de la busqueda
    // Start is called before the first frame update
    public void SetData(List<SearchOn> dbPath, List<int> queBuscar) // externamente se llama a esta funci�n metiendo una lista de bases de datos
    {
        foreach (var item in GetComponentsInChildren<Transform>()) // si este objeto tiene hijos
        {
            if (item != transform) // si el hijo no es este objeto
            {
                Destroy(item.gameObject);//se elimina el hijo
            }

        }
        DBPath = dbPath; // la varibale local DBPath es rellenada con la variable externa dbPath
        int idx = 0; // se inicializa el indice con 0
        foreach (var path in DBPath) // por cada ruta dentro de la lista de rutas
        {
            var obj = Instantiate<GameObject>(t); // se instancia un objeto vac�o t(idx)
            obj.transform.parent = this.transform; //se emparenta el objeto t(idx) a este objeto
            obj.name = "base de dato " + idx; // se le asigna el nombre de la base de dato as� como el indice de la misma

            foreach (var item in path.buscarEsto)
            {  /* por cada par�metro "item" a buscar dentro de la lista de par�metros 
                "buscarEsto" de cada ruta "path" dentro de la lista de rutas "DBPath"
                */
                var baseDato = idx;
                var obj_ = Instantiate<GameObject>(t); // se instancia otro objeto vac�o t, diferente al primero
                SetObject(obj_, baseDato, queBuscar[idx]);// se llama a la funci�n SetObject inyectando al objeto vac�o y al �ndice de la base de datos
                obj_.transform.parent = obj.transform; //se emparenta este objeto "t" al objeto t(idx)
                obj_.name = item; // se le pone el nombre al objeto igual al par�metro que se est� buscando
                if (obj_.GetComponent<JSONReaderBase>()) // si el objeto contiene un lector basado en JSONReaderBase
                {
                    obj_.GetComponent<JSONReaderBase>().InitRemotePath(item); // se realiza la busqueda
                }
                
            }
            idx++;
        }
    }
    public virtual void SetObject(GameObject obj, int i, int j)
    {

    }
}
