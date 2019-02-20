using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputVal : MonoBehaviour
{

    public float bsiValue = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("up"))
        {
            bsiValue += .1f;
        }
        if(Input.GetKeyDown("down"))
        {
            bsiValue -= .1f;
        }
        
    }
}
