using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texttrigger : MonoBehaviour {

    public text text;

    public void Triggertext()
    {
        FindObjectOfType<textManager>().Starttext(text);
    }
}
