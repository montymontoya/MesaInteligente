using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MapActivator : MonoBehaviour
{
    public GameObject mapBasePrefab;
    public Transform mapa;
    public string tagToCompare = "mapSwitch";
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCompare))
        {
            mapa = Instantiate(mapBasePrefab).transform;
            mapa.SetParent(this.transform);
            mapa.localScale = new Vector3(1,1,1);
            mapa.localPosition = new Vector3(0, 0, -10.5f);
            mapa.localEulerAngles = new Vector3(35,180,0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToCompare))
        {
            Destroy(mapa.gameObject);
        }
    }
}
