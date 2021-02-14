using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWaitSeconds : MonoBehaviour
{

    public GameObject obj;
    public float t = 1f;
    private void Start()
    {
        StartCoroutine(start());
    }
    IEnumerator start()
    {
        yield return new WaitForSeconds(t);
        obj.SetActive(true);
    }
}
