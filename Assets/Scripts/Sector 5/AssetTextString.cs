using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetTextString : MonoBehaviour
{
    public TextAsset txtAsset;
    public string txt;

    private void Start()
    {
        txt = txtAsset.text;
    }
}
