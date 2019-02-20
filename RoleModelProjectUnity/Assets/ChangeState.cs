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
    public GameObject obj;

    public InputVal inputval;

    private float currAlpha;

   


    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
        transform.localScale = baseScale * startSize;
        currScale = startSize;
        targetScale = baseScale * startSize;


       
        rend.color = new Color(1f, 1f, 1f, currAlpha);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, 
            targetScale, speed * Time.deltaTime);
        
        
        rend.color = new Color(1f, 1f, 1f, inputval.bsiValue);
        if(rend.color == new Color(1f,1f,1f, 0))
        {
            obj.SetActive(false);
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
 

}
