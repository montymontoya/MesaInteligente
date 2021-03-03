using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ReaderManager : MonoBehaviour
{
    public List<SearchOn> DBPath;
    public GameObject t;
    // Start is called before the first frame update
    public void SetData(List<SearchOn> dbPath)
    {
        foreach (var item in GetComponentsInChildren<Transform>())
        {
            if (item != transform)
            {
                Destroy(item.gameObject);
            }

        }
        DBPath = dbPath;
        int idx = 0;
        foreach (var path in dbPath)
        {
            var obj = Instantiate<GameObject>(t);
            obj.transform.parent = this.transform;
            obj.name = "base de dato " + idx;
            foreach (var item in path.buscarEsto)
            {
                var obj_ = Instantiate<GameObject>(t);
                SetObject(obj_, idx);
                obj_.transform.parent = obj.transform;
                obj_.name = item;
                if (obj_.GetComponent<JSONReaderBase>())
                {
                    obj_.GetComponent<JSONReaderBase>().InitRemotePath(item);
                }
                
            }
            idx++;
        }
    }
    public virtual void SetObject(GameObject obj, int i)
    {

    }
}
