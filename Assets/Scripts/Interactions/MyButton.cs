using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MyButton : Usable
{
    public bool rightClick;
    public UnityEvent OneClick, DoubleClick;
    public UnityEvent OnClickDown, OnClickStay, OnClickUp;

    public UnityEvent MouseEnter, MouseStay, MouseExit;
    public bool debugEnabled = false;

    bool mStay = false;
    private bool btnStay = false;
    private int mButton = 0;

    private void Start()
    {
        if (rightClick)
        {
            mButton = 1;
        }
    }


    private void Update()
    {
        if (mStay)
        {
            if (debugEnabled) { Debug.Log("STAY"); }
            MouseStay.Invoke();
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

    public override void ClickDown(int idxButton)
    {
        if (mButton == idxButton)
        {
            OnClickDown.Invoke();
            btnStay = true;
        }
    }

    public override void ClickUp(int idxButton)
    {
        if (mButton == idxButton)
        {
            OnClickUp.Invoke();
            btnStay = false;
        }
    }

    public override void ClickStay(int idxButton)
    {
        if (btnStay && mButton == idxButton)
        {
            OnClickStay.Invoke();
        }
    }

    public override void RayStay(GameObject hitObject)
    {
        MouseStay.Invoke();
        mStay = true;
    }

    public override void RayEnter(GameObject hitObject)
    {
        MouseEnter.Invoke();
        mStay = true;
    }

    public override void RayExit(GameObject hitObject)
    {
        MouseExit.Invoke();
        mStay = false;
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
