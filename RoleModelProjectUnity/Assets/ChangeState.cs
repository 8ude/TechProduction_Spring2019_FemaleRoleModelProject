using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour
{
    //public GameObject obj2;
    //public GameObject obj;

    public int startSize = 3;
    public int minSize = 1;
    public int maxSize = 6;


    public float speed = 3.0f;

    private Vector3 targetScale;
    private Vector3 baseScale;
    private int currScale;

    public SpriteRenderer rend;

    public InputVal inputval;

    public float currAlpha = 0;

    public ReceiveEmotiv.EmotionalState myState;

    public ReceiveEmotiv receiveEmotivScript;
    
    //trying an alternate way of implementing the fading scripts
    public float bciFadeInStart, bciFadeInEnd, bciFadeOutStart, bciFadeOutEnd;
    public float inputBCIValue;


    void OnEnable() 
    {
        receiveEmotivScript.OnChangeState += CheckStateChange;
    }

    void OnDisable()
    {
        receiveEmotivScript.OnChangeState -= CheckStateChange;
    }
    // Start is called before the first frame update
    void Start()
    {
        //baseScale = transform.localScale;
        //transform.localScale = baseScale * startSize;
        //currScale = startSize;
        //targetScale = baseScale * startSize;


        //rend.color = new Color(1f, 1f, 1f, inputval.bsiValue);

    }
//
    // Update is called once per frame
    void Update() {

        //inputBCIValue = inputval.imageValue;
        
        //BSIChangeOpacity();
        
        
       // transform.localScale = Vector3.MoveTowards(transform.localScale, 
           // targetScale, speed * Time.deltaTime);

        //rend.color = new Color(1f, 1f, 1f, inputval.bsiValue);
        
        //Note - in order to debug effectively, you should 
        //have some more explicit text in the debug log.
        //for example: 
        //Debug.Log(gameObject.name.ToString + " bsiValue is " + inputval.bsiValue)
        //Debug.Log(inputval.bsiValue);
        

    }

    public void ChangeSize(bool bigger)
    {
        if(bigger)
        {
            currScale++;
        }
        else
        {
            currScale--;
        }
        currScale = Mathf.Clamp(currScale, minSize, maxSize + 1);
        targetScale = baseScale * currScale;
    }

    
    //here's what i've added, which seems to be working a little better.  
    //in the inspector, we set our ranges 
    private void BSIChangeOpacity() {
        if (inputBCIValue >= bciFadeInStart && inputBCIValue <= bciFadeInEnd) {
            
            //linearly interpolate from 0 - 1
            float alphaValue = (inputBCIValue - bciFadeInStart) /
                               (bciFadeInEnd - bciFadeInStart);
            
            rend.color = new Color(1f, 1f, 1f, alphaValue);
            

        } else if (inputBCIValue >= bciFadeInEnd && inputBCIValue <= bciFadeOutStart) {
            
            rend.color = new Color(1f, 1f, 1f, 1f);
            
        } else if (inputBCIValue >= bciFadeOutStart && inputBCIValue <= bciFadeOutEnd) {
            
            //linearly interpolate from 1 - 0
            float alphaValue = 1f - ((inputBCIValue - bciFadeOutStart) /
                               (bciFadeOutEnd - bciFadeOutStart));
            
            rend.color = new Color(1f, 1f, 1f, alphaValue);

        }
        else {
            
            rend.color = new Color(1f, 1f,1f, 0f);
            
        }
       
    }

    public void CheckStateChange() {
        
        Debug.Log("Received state change: " + myState.ToString());
        
        //only occures when state is changed
        if (myState == receiveEmotivScript.currentState ) {
            
            Debug.Log("Activating: " + gameObject.name);
            StartCoroutine(FadeSpriteIn());
            
        } else if (rend.color.a > 0) {
            
            //we need to fade out the current sprite
            StartCoroutine(FadeSpriteOut());
            
        }
    }

    IEnumerator FadeSpriteIn() {
        Color startColor = rend.color;

        Color endColor = new Color (1f, 1f, 1f, 1f);

        float timer = 0f;

        while (timer < 1f) {
            rend.color = Color.Lerp(startColor, endColor, timer);
            timer += (Time.deltaTime / 2f);
            yield return null;
        }
        
    }

    IEnumerator FadeSpriteOut() {
        Color startColor = rend.color;

        Color endColor = new Color (1f, 1f, 1f, 0f);

        float timer = 0f;

        while (timer < 1f) {
            rend.color = Color.Lerp(startColor, endColor, timer);
            timer += (Time.deltaTime / 2f);
            yield return null;
        }
        
    }
 

}
