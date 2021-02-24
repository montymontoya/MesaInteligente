using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnDisMapControl : MonoBehaviour
{
    public GameObject principalMap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Collider col = principalMap.GetComponent<Collider>();
            if (hit.transform == transform)
            {
                col.enabled = true;
                GetComponent<Collider>().enabled = false;
            }
        }

    }

}
