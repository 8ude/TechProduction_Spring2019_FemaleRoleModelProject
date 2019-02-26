using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputVal : MonoBehaviour
{

    public float bsiValue = 0;
    public SpriteRenderer[] emotes;
    private int counter = 0;
   // private int minCount = 0;
   // private int maxCount = 100;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < emotes.Length; i++)
        {
            emotes[i].enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("up"))
        {
            counter++;
            if (counter < 10 && emotes[0])
            {
                emotes[0].enabled = true;
                bsiValue += .1f;
            }
            if (counter == 10)
            {
                Reset();
            }
            if(counter < 20 && counter > 10 && emotes[1])
            {
                emotes[1].enabled = true;
                emotes[0].enabled = false;
                bsiValue += .1f;
            }
            if(counter == 20)
            {
                Reset();
            }
            if(counter < 30 && counter > 20 && emotes[2])
            {
                emotes[2].enabled = true;
                emotes[1].enabled = false;
                emotes[0].enabled = false;
                bsiValue += .1f;
            }
            if (counter == 30)
            {
                Reset();
            }
            if(counter < 40 && counter > 30 && emotes[3])
            {
                emotes[3].enabled = true;
                emotes[2].enabled = false;
                emotes[1].enabled = false;
                emotes[0].enabled = false;
                bsiValue += .1f;
            }
            if (counter == 40)
            {
                Reset();
            }
            if(counter < 50 && counter > 40 && emotes[4])
            {
                emotes[4].enabled = true;
                emotes[3].enabled = false;
                emotes[2].enabled = false;
                emotes[1].enabled = false;
                emotes[0].enabled = false;
                bsiValue += .1f;
            }
            if(counter == 50)
            {
                Reset();
            }
            //Debug.Log(counter);
            //Debug.Log(bsiValue);
        }
        //if(Input.GetKeyDown("down"))
        //{
        //    bsiValue -= .1f;
        //}
        
    }
    private void Reset()
    {
            bsiValue = 0;
    }
}
