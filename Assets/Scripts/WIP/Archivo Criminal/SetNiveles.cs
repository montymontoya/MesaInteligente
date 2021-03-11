using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNiveles : MonoBehaviour
{
    public Transform[] niveles;
    private void Start()
    {
        niveles = GetComponentsInChildren<Transform>();

    }
    public void SetLevel(int lvl)
    {
        int idx = 0;
        foreach (var nivel in niveles)
        {
            if (nivel != transform)
            {
                if (idx < lvl)
                    nivel.gameObject.SetActive(true);
                else
                    nivel.gameObject.SetActive(false);
            }

            idx++;
        }
    }
}
