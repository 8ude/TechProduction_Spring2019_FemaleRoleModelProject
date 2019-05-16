using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particaleSelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10.0f);  
    }

}
