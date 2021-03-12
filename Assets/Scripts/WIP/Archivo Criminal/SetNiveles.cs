using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNiveles : MonoBehaviour
{
    public GameObject nivelesParent;
    public GameObject[] niveles;
    private void Start()
    {
        var size = transform.childCount;
        var i = 0;
        
        foreach (var item in niveles)
        {
            niveles[i] = nivelesParent.transform.GetChild(i).gameObject;
            i++;
        }

    }
    public void SetLevel(int lvl)
    {
        
        int idx = 0;
        foreach (var nivel in niveles)
        {
            if (nivel != transform)
            {
                if (idx < lvl)
                    nivel.SetActive(true);
                else
                    nivel.SetActive(false);
            }

            idx++;
        }
    }
}
