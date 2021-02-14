using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CilindroController : MonoBehaviour
{
    private RaycastHit rayHit;
    private GameObject hitObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out rayHit))
        {
            var obj = rayHit.transform.gameObject;// detectamos al objeto (sea el padre o no) que tiene algun script interactable 

            if (obj.GetComponent<Usable>())
            {
                Usable bak = obj.GetComponent<Usable>();

                if (hitObject != null && hitObject == obj)
                {
                    bak.RayStay(hitObject);
                }
                else
                {
                    //bak.RayExit(hitObject);
                    hitObject = obj;
                    bak.RayEnter(hitObject);
                }
            }

        }
        else
        {
            if (hitObject != null)
            {
                hitObject.GetComponent<Usable>().RayExit(hitObject);
                hitObject = null;
            }
        }
    }

}
