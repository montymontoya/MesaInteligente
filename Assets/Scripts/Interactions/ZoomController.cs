using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MouseOrbitImproved))]
public class ZoomController : MonoBehaviour
{
    private MouseOrbitImproved m_moi;
    
    // Start is called before the first frame update
    void Start()
    {
        m_moi = this.GetComponent<MouseOrbitImproved>();
    }

    public void ZoomIn()
    {
        m_moi.distance -= Time.deltaTime;
    }
    public void ZoomOut()
    {
        m_moi.distance += Time.deltaTime;
    }
}
