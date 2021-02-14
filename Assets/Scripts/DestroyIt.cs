using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIt : MonoBehaviour
{
    public GameObject esto;
    // Start is called before the first frame update
    void Start()
    {
        esto = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destuir()
    {
        Destroy(esto);
    }
}
