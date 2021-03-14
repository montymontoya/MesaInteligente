using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class setCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ConstraintSource cam = new ConstraintSource();
        cam.sourceTransform = Camera.main.transform;
        GetComponent<LookAtConstraint>().SetSource(0, cam);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
