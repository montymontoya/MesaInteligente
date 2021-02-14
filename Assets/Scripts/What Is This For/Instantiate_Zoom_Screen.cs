using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Zoom_IO_Screen))]
public class Instantiate_Zoom_Screen : MonoBehaviour
{
    public GameObject screen;
    public Transform screenParent;

    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createPrefab()
    {
        GameObject obj = Instantiate<GameObject>(screen);
        Transform objT = obj.transform;
        objT.parent = screenParent;
        objT.localPosition = Vector3.zero;
        objT.localRotation = Quaternion.Euler(0, 0, 0);
        objT.GetComponent<Instantiate_Zoom_Screen>().screen = screen;
        objT.GetComponent<Instantiate_Zoom_Screen>().screenParent = screenParent;
        objT.GetComponent<Zoom_IO_Screen>().ExpandScreen();
        
    }
}
