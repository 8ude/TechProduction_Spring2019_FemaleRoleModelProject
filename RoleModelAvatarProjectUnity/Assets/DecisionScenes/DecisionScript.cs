using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionScript : MonoBehaviour

    
{
    public Button button1, button2, continuebut;

    public GameObject continuebox;
    public GameObject button_1;
    public GameObject button_2;
    public GameObject score;
    public GameObject dialougebox;

    public Text dialougetext;
    public Text button1text, button2text;
    public Text scoretext;
    [TextArea(3, 10)]
    public string[] dialouge;
    [TextArea(3, 10)]
    public string[] scenedialouge;
    public string[] buttons;

    int button1counter = 0;
    int button2counter = 0;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Adds button functions
        button1.onClick.AddListener(Button1);
        button2.onClick.AddListener(Button2);
        //Add continue button function
        continuebut.onClick.AddListener(NextScene);

        dialougetext.text = scenedialouge[0];
        continuebox.SetActive(false);
        score.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        int i;
        for(i = 0; i > dialouge.Length; i++)
        {
            //Debug.Log("Dialouge " + i);
        }
        int t;
        for (t = 0; i > scenedialouge.Length; t++)
        {
            //Debug.Log("SceneDialouge " + t);
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
        if (dialougetext.text == scenedialouge[2])
        {
            button1text.text = buttons[4];
            button2text.text = buttons[5];
        }
        if(index == scenedialouge.Length)
        {
            button_1.SetActive(false);
            button_2.SetActive(false);
            continuebox.SetActive(false);
            dialougebox.SetActive(false);
            score.SetActive(true);
            scoretext.text = "Your score was Male = " + button1counter + " Female = "+ button2counter;
        }


    }

    void Button1()
    {
        //Debug.Log("button1 was clicked!" + button1counter);
        //On left button click
        if(dialougetext.text == scenedialouge[0])
        {
            dialougetext.text = dialouge[0];
            continuebox.SetActive(true);
            button_1.SetActive(false);
            button_2.SetActive(false);
        }
        if(dialougetext.text == scenedialouge[1])
        {
            dialougetext.text = dialouge[2];
            continuebox.SetActive(true);
            button_1.SetActive(false);
            button_2.SetActive(false);
        }
        if (dialougetext.text == scenedialouge[2])
        {
            dialougetext.text = dialouge[4];
            continuebox.SetActive(true);
            button_1.SetActive(false);
            button_2.SetActive(false);
        }
        button1counter++;
        


    }
    void Button2()
    {
        //Debug.Log("button2 was clicked!" + button2counter);
        //On right button click
        if(dialougetext.text == scenedialouge[0])
        {
            dialougetext.text = dialouge[1];
            continuebox.SetActive(true);
            button_2.SetActive(false);
            button_1.SetActive(false);
        }
        if (dialougetext.text == scenedialouge[1])
        {
            dialougetext.text = dialouge[3];
            continuebox.SetActive(true);
            button_2.SetActive(false);
            button_1.SetActive(false);
        }
        if (dialougetext.text == scenedialouge[2])
        {
            dialougetext.text = dialouge[5];
            continuebox.SetActive(true);
            button_2.SetActive(false);
            button_1.SetActive(false);
        }
        button2counter++;


    }
    void NextScene()
    {

        index++;
        Debug.Log("Continue = " + index);
        dialougetext.text = scenedialouge[index];
        continuebox.SetActive(false);
        button_1.SetActive(true);
        button_2.SetActive(true);
    }
}
