using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnDisButton : MonoBehaviour
{
    public MyButton objToEnDis, objToDisEn;

    public void EnableIt()
    {
        objToEnDis.enabled = true;
        objToDisEn.enabled = false;
    }

    public void DisbleIt()
    {
        objToEnDis.enabled = false;
        objToDisEn.enabled = true;
    }

}
