using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poofscript : MonoBehaviour
{
    public GameObject poofParticles;
    public void PlayPoofParticles()
    {
        Instantiate(poofParticles, transform.position, Quaternion.identity);
        Destroy(gameObject, 5.0f);
    }
}
