using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(LockMove))]
public class LockMoveController: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<LockMove>().enabled = true;
        //GetComponent<LockMove>().mstay = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        GetComponent<LockMove>().enabled = false;
        //GetComponent<LockMove>().mstay = false;
        Camera.main.GetComponent<MoveController>().canMove = true;
    }
}
