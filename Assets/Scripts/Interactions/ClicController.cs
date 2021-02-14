using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicController : MonoBehaviour
{
    public bool rightBtn;
    public int btn;
    private float t, th = 0.27f;
    public int btnDCount, btnUCount;
    public bool doubleClick = false, oneClick = false;

    private Transform _hitObject;

    private void Start()
    {
        btn = (rightBtn) ? 1 : 0;
    }

    private RaycastHit rayHit;
    private GameObject hitObject;

    // Update is called once per frame
    void Seleccion(Usable obj)
    {
        switch (btnDCount)
        {
            case 0: // si no se ha presionado el botón
                if (BtnPressed("down", btn))// se identifica si se presionó el botón
                {
                    obj.ClickDown(btn);
                }

                break;
            case 1:// si se ha presionado el botón 1 vez
                obj.ClickStay(btn);
                if (btnUCount < 1 && BtnPressed("up", btn))// se pregunta si ya se soltó el botón
                {
                    obj.ClickUp(btn);
                }


                t += Time.deltaTime; // se comienza a contar tiempo desde que se apretó por primera vez el botón
                if (t < th)// si el tiempo es menor a un umbral
                {
                    if (BtnPressed("down", btn))// se pregunta si se volvió a presionar 
                    {
                        t = 0;
                    }
                }
                else
                {
                    if (btnUCount > 0)
                    {
                        Debug.Log("Un Click");
                        obj.OnOneClick(btn);
                        Resetea();
                    }

                }

                break;
            case 2: // si se ha presionado el botón por 2da vez
                if (BtnPressed("up", btn))// se pregunta si se ha soltado el botón por 2da vez)
                {
                    Debug.Log("Doble Click");
                    obj.OnDoubleClick(btn);
                    Resetea();
                }

                break;

        }
    }

    void FixedUpdate()
    {
        bool mouse = Input.GetMouseButtonDown(btn);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out rayHit))
        {
            _hitObject = rayHit.transform;// detectamos al objeto (sea el padre o no) que tiene algun script interactable 

            if (_hitObject.GetComponent<Usable>())
            {
                Usable bak = _hitObject.GetComponent<Usable>();

                if (hitObject != null && hitObject == _hitObject.gameObject)
                {
                    Seleccion(bak);
                    bak.RayStay(hitObject);
                    Debug.Log("STAY");
                }
                else
                {
                    bak.RayExit(hitObject);
                    hitObject = rayHit.transform.gameObject;
                    bak.RayEnter(hitObject);
                    Debug.Log("ENTER");
                }
            }

        }
        else
        {
            if (hitObject != null)
            {
                Debug.Log("EXIT");
                hitObject.GetComponent<Usable>().RayExit(hitObject);
                hitObject = null;
            }


        }
    }
    /*******ESTO SIRVE PARA DETECTAR AL PADRE DEL NIVEL MÁS ALTO********/

    private void Resetea()
    {
        oneClick = false;
        doubleClick = false;
        btnDCount = 0;
        btnUCount = btnDCount;
        t = 0;
    }

    public bool BtnPressed(string taip, int idx)
    {
        switch (taip)
        {
            case "down":
                if (Input.GetMouseButtonDown(idx))
                {
                    btnDCount++;
                    return true;
                }
                break;
            case "up":
                if (Input.GetMouseButtonUp(idx))
                {
                    btnUCount++;
                    return true;
                }
                break;
            default:
                return false;
        }
        return false;
    }
}
