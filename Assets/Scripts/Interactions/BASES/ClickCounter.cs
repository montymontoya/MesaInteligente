using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCounter : MonoBehaviour
{
    public int button;
    public int ClickUp, ClickDown;
    private bool Status;
    private float t,ts, thTime = 0.2f;
    private bool stay;
    public bool debug;
    public int clicStatus, clcStatus;
    private bool clcD = true, clcU = true;
    /*
     * clicStatus 
     * = 0 cuando no hay clics
     * = 1 cuando hay un clic
     * = 2 cuando hay clic sostenido
     * = 3 cuando hay doble clic
     * = 4 cuando hay doble clic sostenido
     * 
     * clcStatus
     * = 0 cuando no hay clics
     * = 1 cuando click down
     * = 2 cuando click up
     */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(button)) ClickDown++;
        if (Input.GetMouseButtonUp(button)) ClickUp++;

        if (ClickDown == 1 && ClickUp == 0) // inicia primer Clic
        {
            if (clcD==true)
            {
                clcStatus = 1;
                clcD = false;
            }
            ts += Time.deltaTime;
            if (ts > thTime*.9f)
            {
                if (debug) { Debug.Log("CLIC SOSTENIDO"); }
                clicStatus = 2;
                stay = true;
            }    
        }
        else if (ClickDown == 1 && ClickUp == 1) // 1 click
        {
            if (clcU==true)
            {
                clcStatus = 2;
                clcU = false;
            }
            if (stay)
            {
                ClickDown = ClickUp = 2;
            }
            else
            {
                t += Time.deltaTime;
                if (t > thTime)
                {
                    if (debug) { Debug.Log("UN CLIC"); }
                    clicStatus = 1;
                    clcStatus = ClickDown = ClickUp = 0;
                    clcD = clcU = true;
                    ts = t = 0;
                   
                }
            }
            
        }
        else if (ClickDown == 2 && ClickUp == 1) // inicia segundo clic
        {
            ts += Time.deltaTime;
            if (ts > thTime*1.1f)
            {
                if (debug) { Debug.Log("DOBLE CLIC SOSTENIDO"); }
                clicStatus = 4;
                stay = true;
            }
            
        }
        else if (ClickDown == 2 && ClickUp == 2) // 2 click
        {
            if (!stay)
            {
                if (debug) { Debug.Log("DOBLE CLIC"); }
                clicStatus = 3;
            }
                

            clcStatus = ClickDown = ClickUp = 0;
            clcD = clcU = true;
            ts = t = 0;
            stay = false;
        }
        else if(ClickDown > 2 || ClickUp > 2)
        {
            ClickDown = 1;
            clcStatus = ClickUp = 0;
            clcD = clcU = true;
            ts = t = 0;
            stay = false;
        }
    }
    /*
 * clicStatus 
 * = 0 cuando no hay clics
 * = 1 cuando hay un clic
 * = 2 cuando hay clic sostenido
 * = 3 cuando hay doble clic
 * = 4 cuando hay doble clic sostenido
 */

    public void Clicks(GameObject obj)
    {
        var usable = obj.GetComponent<Usable>();
        switch (clicStatus)
        {
            case 0:
                break;
            case 1:

                usable.OnOneClick(button);
                break;
            case 2:
                usable.ClickStay(button);
                break;
            case 3:
                usable.OnDoubleClick(button);
                
                break;
            case 4:
                
                break;
        }
        switch (clcStatus)
        {
            case 0:
                break;
            case 1:
                usable.ClickDown(button);
                break;
            case 2:
                usable.ClickUp(button);
                break;
        }
        clicStatus = 0;
        clcStatus = 0;
    }

}
