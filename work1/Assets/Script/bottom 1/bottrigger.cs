using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottrigger : MonoBehaviour
{

    public bot bott;

    public void Triggertext()
    {
        FindObjectOfType<bottextmanager>().Startbottext(bott);
    }
}
