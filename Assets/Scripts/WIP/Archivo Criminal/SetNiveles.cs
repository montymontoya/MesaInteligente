using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNiveles : MonoBehaviour
{
    public GameObject nivelesParent;
    public GameObject[] niveles;
    public int nNiveles;
    public int levels;
    public int lvl;
    private void Start()
    {
        nNiveles = nivelesParent.transform.childCount;
        niveles = new GameObject[nNiveles];

        for (int i = 0; i < nNiveles; i++)
        {
            niveles[i] = nivelesParent.transform.GetChild(i).gameObject;
        }

    }
    public void LateUpdate()
    {
        if (lvl != levels)
        {
            int idx = 0;
            foreach (var nivel in niveles)
            {
                if (nivel.transform != transform)
                {
                    if (idx < levels)
                        nivel.SetActive(true);
                    else
                        nivel.SetActive(false);
                }

                idx++;
            }
        }
        lvl = levels;
    }
    public void SetLevel(int lvl)
    {
        levels = lvl;
        int idx = 0;
        foreach (var nivel in niveles)
        {
            if (nivel.transform != transform)
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
