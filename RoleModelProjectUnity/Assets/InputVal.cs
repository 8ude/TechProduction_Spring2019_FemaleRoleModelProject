using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputVal : MonoBehaviour
{

    //this is the value that we're sending to our image
    //with a range from 0-100
    public float imageValue = 0;
    
    //we're adding another min-to-max scale here so that we can get our data in a usable range
    public float minBCIValue, maxBCIValue;

    public float inputBCIValue;

    public float bsiValue;

    public DialoguePickerScript dialoguepicker;
    
    public SpriteRenderer[] emotes;
    private int counter = 0;
   // private int minCount = 0;
   // private int maxCount = 100;
    // Start is called before the first frame update
    void Start()
    {
        //in the revised version, we do everything with the alpha, and keep the sprites active
        for (int i = 0; i < emotes.Length; i++)
        {
            //emotes[i].enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update() {

        imageValue = MathUtil.Remap(inputBCIValue, minBCIValue, maxBCIValue, 0f, 100f);
        dialoguepicker.inputValue = imageValue;

        //There's an issue here with the counter - we can go up but we can't go back down
        //part of the problem is the way that we're dealing with these two variables, the bsiValue and
        //the counter

        //in some ways, it works well - the bsiValue lets us directly set the opacity on different sprites
        //then we reset after we get to the next sprite value

        //but... this resetting assumes that we are only going up, and makes it so that we can't do any 
        //crossfading
        
        //instead, I'm just passing a float (which I've called imageValue) directly to the
        //ChangeState.cs script different sprites

        
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
        if(Input.GetKeyDown("down"))
        {
            counter--;
            if (counter < 10 && emotes[0])
            {
                emotes[0].enabled = true;
                bsiValue -= .1f;
            }
            if (counter == 10)
            {
                Reset1();
            }
            if(counter < 20 && counter > 10 && emotes[1])
            {
                emotes[1].enabled = true;
                emotes[0].enabled = false;
                bsiValue -= .1f;
            }
            if(counter == 20)
            {
                Reset1();
            }
            if(counter < 30 && counter > 20 && emotes[2])
            {
                emotes[2].enabled = true;
                emotes[1].enabled = false;
                emotes[0].enabled = false;
                bsiValue -= .1f;
            }
            if (counter == 30)
            {
                Reset1();
            }
            if(counter < 40 && counter > 30 && emotes[3])
            {
                emotes[3].enabled = true;
                emotes[2].enabled = false;
                emotes[1].enabled = false;
                emotes[0].enabled = false;
                bsiValue -= .1f;
            }
            if (counter == 40)
            {
                Reset1();
            }
            if(counter < 50 && counter > 40 && emotes[4])
            {
                emotes[4].enabled = true;
                emotes[3].enabled = false;
                emotes[2].enabled = false;
                emotes[1].enabled = false;
                emotes[0].enabled = false;
                bsiValue -= .1f;
            }
            if(counter == 50)
            {
                Reset1();
            }
            
        }
        

    }
    private void Reset()
    {
            bsiValue = 0;
    }
    private void Reset1()
    {
        bsiValue = 1;
    }
}
