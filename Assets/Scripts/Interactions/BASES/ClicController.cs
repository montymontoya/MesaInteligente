using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ClickCounter))]
public class ClicController : MonoBehaviour
{
    private Transform _hitObject;
    private RaycastHit rayHit;
    private GameObject hitObject;
    public bool debug;

    public ClickCounter counter;
    // Update is called once per frame
    private void Start()
    {
        counter = GetComponent<ClickCounter>();
    }
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.transform.GetComponent<Usable>())
            {
                _hitObject = rayHit.transform;// detectamos al objeto (sea el padre o no) que tiene algun script interactable 
                if (hitObject != null && hitObject == _hitObject.gameObject) // Si el objeto ya existía
                {
                    if (debug) { Debug.Log("STAY"); }

                    hitObject.GetComponent<Usable>().RayStay();// STAY
                    counter.Clicks(hitObject);
                }
                else
                {
                    if (hitObject != null)
                    {
                        if (debug) { Debug.Log("EXIT"); }
                        hitObject.GetComponent<Usable>().RayExit();// EXIT
                        counter.clicStatus = 0;
                        hitObject = null;
                    }
                    if (debug) { Debug.Log("ENTER"); }

                    hitObject = _hitObject.gameObject;
                    hitObject.GetComponent<Usable>().RayEnter();
                }
            }
        }
        else
        {
            counter.clicStatus = 0;
            if (hitObject != null)
            {
                if (debug) { Debug.Log("EXIT"); }
                hitObject.GetComponent<Usable>().RayExit();// EXIT
                
                hitObject = null;
            }

        }

    }

}
