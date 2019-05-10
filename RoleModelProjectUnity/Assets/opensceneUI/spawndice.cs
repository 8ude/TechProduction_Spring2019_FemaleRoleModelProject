using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawndice : MonoBehaviour
{
    public GameObject dice;


    void FixedUpdate()
    {
        Instantiate(dice, transform.position, Quaternion.identity);
    }
}
