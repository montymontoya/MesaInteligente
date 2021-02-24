using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNode : MonoBehaviour
{
    public Transform nodePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            var child = Instantiate<Transform>(nodePrefab,transform);
            var x = Random.Range(-2, 2);
            var y = Random.Range(-2, 2);
            child.transform.localPosition = new Vector3(x, y, 0);

        }
    }
}
