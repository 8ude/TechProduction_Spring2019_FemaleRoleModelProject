using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrainWarBar : MonoBehaviour
{
    Image Brainwarebar;
    float maxBrainware = 100f;
    public static float Brainware;
    void Start()
    {
        Brainwarebar = GetComponent<Image>();
        Brainware = maxBrainware;
    }

    // Update is called once per frame
    void Update()
    {
        Brainwarebar.fillAmount = Brainware / maxBrainware;
        if (Input.GetKey(KeyCode.DownArrow))
        {
           Brainware -= 1f;
        }else if (Input.GetKey(KeyCode.UpArrow))
        {
            Brainware += 1f;
        }
    }
}