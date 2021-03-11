using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultadoPosition : MonoBehaviour
{
    public int idx;
    // Start is called before the first frame update
    void Start()
    {

        idx = transform.GetSiblingIndex();
        transform.localPosition = new Vector3(0, -idx * 30, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
