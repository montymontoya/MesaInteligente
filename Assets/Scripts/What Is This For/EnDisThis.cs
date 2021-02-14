using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnDisThis : MonoBehaviour
{
    private GameObject obj;

    private void Start()
    {
        obj = this.gameObject;
    }
    public void EnableThis()
    {
        obj = this.gameObject;
        obj.SetActive(true);
    }
    public void DisableThis()
    {
        obj = this.gameObject;
        obj.SetActive(false);
    }
}
