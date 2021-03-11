using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicks : MonoBehaviour
{
    public int ClickDown, ClickUp;
    public int button;

    public int state;
    Usable usable;
    private void Start()
    {
        usable = GetComponent<Usable>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(button)) ClickDown++;
        if (Input.GetMouseButtonUp(button)) ClickUp++;

        if (ClickDown == 1)
        {
            if (state == 0)
            {
                usable.ClickDown(button);
                usable.OnOneClick(button);
                state++;
            }
            else
            {
                usable.ClickStay(button);
            }
        }
        else if (ClickDown == 2)
        {
        }

        switch (state)
        {
            case 0: // sin clic
                break;
            case 1: //
                break;
            case 2:
                break;
            case 3:
                break;

        }
    }
}
