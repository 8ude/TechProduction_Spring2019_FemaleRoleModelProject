using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionScript : MonoBehaviour

    
{
    public Button button1, button2, continuebut;
    public GameObject continuebox;
    public Text dialougetext;
    public Text button1text, button2text;
    [TextArea(3, 10)]
    public string[] dialouge;
    [TextArea(3, 10)]
    public string[] scenedialouge;
    public string[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(Button1);
        button2.onClick.AddListener(Button2);
        continuebut.onClick.AddListener(NextScene);
        dialougetext.text = scenedialouge[0];
        continuebox.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        int i;
        for(i = 0; i > dialouge.Length; i++)
        {
            Debug.Log("Dialouge " + i);
        }
        int t;
        for (t = 0; i > scenedialouge.Length; t++)
        {
            Debug.Log("SceneDialouge " + t);
        }
        int b;
        for (b = 0; b > buttons.Length; i++)
        {
            Debug.Log("Buttons " + b);
        }
        //Changes dialouge text based on the scene dialouge array
        if(dialougetext.text == scenedialouge[0])
        {
            button1text.text = buttons[0];
            button2text.text = buttons[1];
        }
        if(dialougetext.text == scenedialouge[1])
        {
            button1text.text = buttons[2];
            button2text.text = buttons[3];
        }
        

    }

    void Button1()
    {
        Debug.Log("button1 was clicked!");
        //On left button click
        if(dialougetext.text == scenedialouge[0])
        {
            dialougetext.text = dialouge[0];
            continuebox.SetActive(true);
        }
        if(dialougetext.text == scenedialouge[1])
        {
            dialougetext.text = dialouge[2];
            continuebox.SetActive(true);
        }
        


    }
    void Button2()
    {
        Debug.Log("button2 was clicked!");
        //On right button click
        if(dialougetext.text == scenedialouge[0])
        {
            dialougetext.text = dialouge[1];
            continuebox.SetActive(true);
        }
        if (dialougetext.text == scenedialouge[1])
        {
            dialougetext.text = dialouge[3];
            continuebox.SetActive(true);
        }


    }
    void NextScene()
    {
        dialougetext.text = scenedialouge[1];
        continuebox.SetActive(false);
    }
}
