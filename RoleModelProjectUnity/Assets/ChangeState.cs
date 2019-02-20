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

    private float startAlpha = 1;
    private float minAlpha = 0;
    private float maxAlpha = 1f;
    private float currAlpha;

    public float speed = 3.0f;

    private Vector3 targetScale;
    private Vector3 baseScale;
    private int currScale;

    public SpriteRenderer rend;
   

    private int index;


    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
        transform.localScale = baseScale * startSize;
        currScale = startSize;
        targetScale = baseScale * startSize;

        currAlpha = startAlpha;
       
        rend.color = new Color(1f, 1f, 1f, currAlpha);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, 
            targetScale, speed * Time.deltaTime);
        
        if(Input.GetKeyDown("up"))
        {
            //obj.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime;
            //ChangeSize(true);
            ChangeAlpha(true);
            currAlpha += .5f;
            
            //  Debug.Log("working");
        }
        if(Input.GetKeyDown("down"))
        {
            //obj.transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime;
            //ChangeSize(false);
            ChangeAlpha(false);
            currAlpha -= .5f;
        }
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
    public void ChangeAlpha(bool trans)
    {
        if(trans)
        {
            currAlpha++;
        }
        else
        {
            currAlpha--;
        }
        currAlpha = Mathf.Clamp(currAlpha, minAlpha, maxAlpha + 1);
    }

}
