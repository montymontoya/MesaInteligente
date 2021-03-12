using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using dataType = GetVinculos;
public class RedDeVinculosManager : ReaderManager
{
    [Header("Variables propias de GetVinculos")]
    public Transform nodeParent;
    public GameObject Node;

    public string texto;
    public Color32[] color;

    public override void SetObject(GameObject objT, int i, int j)
    {
        if (nodeParent.childCount>0)
        {
            foreach (var child in nodeParent.GetComponentsInChildren<Transform>())
            {
                if (child!=nodeParent)
                {
                    Destroy(child.gameObject);
                }
            }

        }
        var t = objT.AddComponent<dataType>();
        t.dbIndex = j;
        t.node = Node;
        t.color = color[i];
        t.nodeParent = nodeParent;
        t.texto = texto;
          
    } 

}





