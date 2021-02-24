using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MyButton : Usable
{
    public bool rightClick;
    public UnityEvent OneClick, DoubleClick;
    public UnityEvent OnClickStay;
    private int mButton = 0;

    private void Start()
    {
        if (rightClick)
        {
            mButton = 1;
        }
    }

    public override void OnOneClick(int idxButton)
    {
        if (mButton == idxButton)
            OneClick.Invoke();
    }

    public override void OnDoubleClick(int idxButton)
    {
        if (mButton == idxButton)
            DoubleClick.Invoke();
    }

    public override void ClickStay(int idxButton)
    {
        if (mButton == idxButton)
        {
            OnClickStay.Invoke();
        }
    }


    /*
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (debugEnabled) { Debug.Log("ENTER"); }
        mStay = true;

        MouseEnter.Invoke();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (debugEnabled) { Debug.Log("EXIT"); }
        mStay = false;

        MouseExit.Invoke();
    }
    */


}
