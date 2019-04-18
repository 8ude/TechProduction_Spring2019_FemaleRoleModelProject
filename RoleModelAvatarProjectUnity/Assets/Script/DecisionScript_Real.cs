using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionScript_Real : MonoBehaviour


{
    public Button button1, button2, continuebut;

    public GameObject continuebox;
    public GameObject button_1;
    public GameObject button_2;
    public GameObject score;
    public GameObject dialougebox;

    public Animator anim;

    public Text dialougetext;
    public Text button1text, button2text;
    public Text scoretext;
    [TextArea(3, 10)]
    public string[] dialouge;
    [TextArea(3, 10)]
    public string[] dialouge2;
    [TextArea(3, 10)]
    public string[] scenedialouge;
    public string[] buttons1;
    public string[] buttons2;
    public string[] animate;

    public GameObject[] background;
    //public string[] backanim;

    int button1counter = 0;
    int button2counter = 0;
    int index = 0;
    int butindex1 = 0;
    int butindex2 = 0;
    int diaindex = 0;
    int off = 1;
    int on = 1;

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
        background[0].SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {

        int i;
        for (i = 0; i > dialouge.Length; i++)
        {
            //Debug.Log("Dialouge " + i);
        }
        int i2;
        for (i2 = 0; i2 > dialouge2.Length; i2++)
        {
            //Debug.Log("Dialouge " + i);
        }
        int t;
        for (t = 0; t > scenedialouge.Length; t++)
        {
            //Debug.Log("SceneDialouge " + t);
        }
        int b;
        for (b = 0; b > buttons1.Length; b++)
        {
            //Debug.Log("Buttons " + b);
        }
        int b2;
        for (b2 = 0; b2 > buttons2.Length; b2++)
        {
            //Debug.Log("Buttons " + b);
        }
        int a;
        for (a = 0; a > animate.Length; a++)
        {

        }
        //Changes dialouge text based on the scene dialouge array
        button1text.text = buttons1[butindex1];
        button2text.text = buttons2[butindex2];




        if (index == scenedialouge.Length)
        {
            button_1.SetActive(false);
            button_2.SetActive(false);
            continuebox.SetActive(false);
            dialougebox.SetActive(false);
            score.SetActive(true);
            float but1 =(button1counter / 3.0f) * 100;
            float but2 =(button2counter / 3.0f) * 100;

            scoretext.text = "Your score was Male = " + but1 + "%" + " Female = " + but2 + "%";
        }

<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 5b661b2... Updated Decision Script Working
        if(background[2])
        {
            background[1].SetActive(false);
        }


<<<<<<< HEAD
>>>>>>> parent of 5b661b2... Updated Decision Script Working
=======
>>>>>>> parent of 5b661b2... Updated Decision Script Working
    }

    void Button1()
    {
        //Debug.Log("button1 was clicked!" + button1counter);
        //On left button click
        if (dialougetext.text == scenedialouge[index])
        {
            dialougetext.text = dialouge[diaindex];
            continuebox.SetActive(true);
            button_1.SetActive(false);
            button_2.SetActive(false);
          //  anim.SetBool(animate[0], true);
        }

        button1counter++;



    }
    void Button2()
    {
        //Debug.Log("button2 was clicked!" + button2counter);
        //On right button click
        if (dialougetext.text == scenedialouge[index])
        {
            dialougetext.text = dialouge2[diaindex];
            continuebox.SetActive(true);
            button_2.SetActive(false);
            button_1.SetActive(false);
           // anim.SetBool(animate[0], true);

        }
       
        button2counter++;


    }
    void NextScene()
    {

        index++;
        on++;
        off--;
        dialougetext.text = scenedialouge[index];
        butindex1++;
        butindex2++;
        diaindex++;
        Debug.Log("Continue = " + index);

        continuebox.SetActive(false);
        button_1.SetActive(true);
        button_2.SetActive(true);
        background[off].SetActive(false);
        background[on].SetActive(true);

    }
}
