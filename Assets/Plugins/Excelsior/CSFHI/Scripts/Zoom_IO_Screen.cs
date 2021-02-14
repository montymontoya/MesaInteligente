using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Zoom_IO_Screen : MonoBehaviour
{
    public Transform screen;

    private Vector3 start_Pos, start_Ang, start_Scale;

    public float speed = 2f;
    public Vector3 end_Pos = new Vector3(0, 0, 2), end_Ang = new Vector3(0, 0, 0);

    public float scale = 2f;

    private bool waitIt = false;

    private bool onMoving = false;

    private bool expand = false, shrink = false;

    private float umbral = 0.1f;

    public bool flag, pFlag = false, sFlag = false;

    private float debug_Distance;

    public UnityEvent onMaxScale, onMinScale;
    // Start is called before the first frame update
    void Start()
    {
        if (screen == null)
        {
            screen = this.transform;
        }
        
        start_Ang = screen.localRotation.eulerAngles;
        start_Pos = screen.localPosition;
        start_Scale = screen.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waitIt)
        {
            if (expand && !shrink)
            {
                debug_Distance = Vector3.Distance(screen.localPosition, end_Pos);
                if (Vector3.Distance(screen.localPosition, end_Pos) >= umbral)
                {
                    screen.localPosition = Vector3.Lerp(screen.localPosition, end_Pos, speed * Time.deltaTime);
                }
                else
                {
                    //screen.localPosition = end_Pos;
                    pFlag = true;
                }
                
                if (Vector3.Magnitude(screen.localScale)<=Vector3.Magnitude(start_Scale*scale*0.95f))
                {
                    screen.localScale = Vector3.Lerp(screen.localScale, start_Scale*scale, speed * Time.deltaTime);
                }
                else
                {
                    //screen.localScale = start_Scale * scale;
                    sFlag = true;
                    onMaxScale.Invoke();
                }

                if (sFlag && pFlag)
                {
                    flag = true;
                    shrink = true;
                    expand = true;
                    sFlag = false;
                    pFlag = false;
                }

            }
            else if (!expand && shrink)
            {
                debug_Distance = Vector3.Distance(screen.localPosition, start_Pos);
                if (Vector3.Distance(screen.localPosition, start_Pos) > umbral)
                {
                    screen.localPosition = Vector3.Lerp(screen.localPosition, start_Pos, speed * Time.deltaTime);
                }
                else
                {
                    //screen.localPosition = start_Pos;
                    pFlag = true;
                }

                if (Vector3.Magnitude(screen.localScale) > Vector3.Magnitude(start_Scale*1.05f))
                {
                    screen.localScale = Vector3.Lerp(screen.localScale, start_Scale, speed * Time.deltaTime);
                }
                else
                {
                    //screen.localScale = start_Scale;
                    sFlag = true;
                    onMinScale.Invoke();
                }


                if (sFlag && pFlag)
                {
                    flag = false;
                    shrink = true;
                    expand = true;
                    sFlag = false;
                    pFlag = false;
                }
            }
            else
            {
                waitIt = true;
            }
        }
    }

    public void ExpandScreen()
    {
        waitIt = false;
        if (flag)
        {
            
        expand = false;
        shrink = true;
        }
        else
        {
        expand = true;
        shrink = false;
        }

   
        
    }

}
