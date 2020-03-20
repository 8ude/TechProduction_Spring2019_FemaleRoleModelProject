using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionScript_Real : MonoBehaviour


{
    public Button rightButton, leftButton, continuebut, contbut, creditsButton;

    public GameObject continuebox;
    public GameObject RightButton;
    public GameObject LeftButton;
    public GameObject score;
    public GameObject dialougebox;
    public GameObject contbutton;

    public GameObject[] MaleAnimations;
    public GameObject[] FemaleAnimations;

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

    string Male;
    string Female;

    public GameObject[] background;

    public AudioClip[] sounds;
    public AudioClip[] demon;
    public AudioSource demonAud;
    public AudioSource audioS;
    public AudioSource diaAudio;
    //public string[] backanim;
    public AudioClip[] diaS;
    public AudioClip ChoiceOneOptionsAudio;

    int button1counter = 0;
    int button2counter = 0;
    int index = 0;
    int butindex1 = 0;
    int butindex2 = 0;
    int diaindex = 0;
    int sound = 0;

    int off = 1;
    int on = 0;

    public bool isoffice;
    public bool iscloseup;
    public bool isplayground;

    public AudioClip office;
    public AudioClip closeup;
    public AudioClip coffee;
    public AudioClip mud;
    public AudioClip tag;

    // Start is called before the first frame update
    void Start()
    {
        //Adds button functions
        rightButton.onClick.AddListener(RightButtonClicked);
        leftButton.onClick.AddListener(LeftButtonClicked);
        //Add continue button function
        continuebut.onClick.AddListener(NextScene);
        contbut.onClick.AddListener(Continuebut);

        creditsButton.onClick.AddListener(OnCreditsButton);

        dialougetext.text = scenedialouge[0];
        dialougebox.SetActive(false);
        continuebox.SetActive(false);
        contbutton.SetActive(false);
        score.SetActive(false);
        RightButton.SetActive(false);
        LeftButton.SetActive(false);
        background[0].SetActive(true);
        audioS = GetComponent<AudioSource>();
        audioS.clip = sounds[0];
        StartCoroutine(Waitforaudio());
        



    }

    // Update is called once per frame
    void Update()
    {



        Male = PlayerPrefs.GetString("Player Gender", "Male");
        Female = PlayerPrefs.GetString("Player Gender", "Female");

        button1text.text = buttons1[butindex1];
        button2text.text = buttons2[butindex2];




        if (audioS.clip == sounds[1])
        {
            if(isplayground == true)
            {
                FemaleAnimations[0].SetActive(true);
            }
            if(isoffice == true)
            {
                MaleAnimations[0].SetActive(true);

            }



        }

        if(audioS.clip == mud)
        {
            if(isplayground == true)
            {
                MaleAnimations[0].SetActive(true);
                StartCoroutine(Waitforanim());
            }


        }
        if(audioS.clip == sounds[3])
        {
            if(isoffice ==true)
            {
                MaleAnimations[1].SetActive(true);
            }

            if(isplayground == true)
            {
                FemaleAnimations[1].SetActive(true);
            }
        }

        if (audioS.clip == office)
        {
            FemaleAnimations[0].SetActive(true);
        }


        if(audioS.clip == coffee)
        {
            FemaleAnimations[1].SetActive(true);
        }

        
         if(audioS.clip == tag)
        {
            MaleAnimations[2].SetActive(true);
        }



        //Changes dialouge text based on the scene dialouge array
        if (index == scenedialouge.Length)
        {
            RightButton.SetActive(false);
            LeftButton.SetActive(false);
            continuebox.SetActive(false);
            dialougebox.SetActive(false);
            background[2].SetActive(false);
            score.SetActive(true);
            float malePercent = (ScoringScript.Instance.MaleScore / ScoringScript.Instance.TotalScore)*100f;
            float femalePercent = (ScoringScript.Instance.FemaleScore / ScoringScript.Instance.TotalScore)*100f;

            scoretext.text = "Your score was Male = " + malePercent + "%" + "\n" + " Female = " + femalePercent + "%";
        }

        if(contbutton.activeInHierarchy)
        {
            audioS.Stop();
        }



    }
    //Plays audio and waits for it to finish
    public IEnumerator Waitforaudio()
    {
        //Playes audio till the end
        audioS.clip = diaS[0];
        audioS.Play();
        yield return new WaitWhile(() => audioS.isPlaying == true);
        audioS.clip = sounds[0];
        audioS.Play();
        yield return new WaitWhile(() => audioS.isPlaying == true);

        audioS.clip = ChoiceOneOptionsAudio;
        audioS.Play();
        yield return new WaitWhile(() => audioS.isPlaying == true);

        audioS.clip = sounds[1];
        audioS.Play();
        yield return new WaitWhile(() => audioS.isPlaying == true);
        if(background[0] && isoffice == true)
        {
            MaleAnimations[0].SetActive(false);
            audioS.clip = office;
            audioS.Play();
            yield return new WaitWhile(() => audioS.isPlaying == true);
            FemaleAnimations[0].SetActive(false);
            contbutton.SetActive(true);

        }
        if(background[0]&&isplayground == true)
        {
            audioS.clip = mud;
            audioS.Play();
            yield return new WaitWhile(() => audioS.isPlaying == true);
            //MaleAnimations[0].SetActive(true);
            contbutton.SetActive(true);
        }
        else
        {
            contbutton.SetActive(true);
        }
        


        //do something


    }
    public IEnumerator Waitforaudio2()
    {
        audioS.clip = sounds[2];
        audioS.Play();
        yield return new WaitWhile(() => audioS.isPlaying == true);
        audioS.clip = sounds[3];
        audioS.Play();
        yield return new WaitWhile(() => audioS.isPlaying == true);
        if(background[1]&&isoffice == true)
        {
            audioS.clip = coffee;
            audioS.Play();
            yield return new WaitWhile(() => audioS.isPlaying == true);
            FemaleAnimations[1].SetActive(false);
            contbutton.SetActive(true);
        }
        if(background[1]&&isplayground == true)
        {
            audioS.clip = tag;
            audioS.Play();
            yield return new WaitWhile(() => audioS.isPlaying == true);
            contbutton.SetActive(true);
        }
        else
        {
            contbutton.SetActive(true);
        }
    }
    public IEnumerator Waitforaudio3()
    {
        audioS.clip = sounds[4];
        audioS.Play();
        yield return new WaitWhile(() => audioS.isPlaying == true);
        audioS.clip = sounds[5];
        audioS.Play();
        if(isoffice == true)
        {
            MaleAnimations[2].SetActive(true);
        }
        else
        {
            MaleAnimations[2].SetActive(false);
        }
        yield return new WaitWhile(() => audioS.isPlaying == true);
        MaleAnimations[2].SetActive(false);
        if (background[2]&&iscloseup == true)
        {
            audioS.clip = closeup;
            audioS.Play();
            FemaleAnimations[2].SetActive(true);
            yield return new WaitUntil(() => audioS.isPlaying == true);
            contbutton.SetActive(true);
        }
        else
        {
            FemaleAnimations[2].SetActive(false);
            contbutton.SetActive(true);
        }
    }
    public IEnumerator Waitforanim()
    {
        //Start second animation if needed
        yield return new WaitForSeconds(4);
        MaleAnimations[1].SetActive(true);
        yield return new WaitForSeconds(4);
        MaleAnimations[1].SetActive(false);
        //contbutton.SetActive(true);
    }

    void RightButtonClicked()
    {
        //Debug.Log("button1 was clicked!" + button1counter);
        //On left button click
        if (dialougetext.text == scenedialouge[index])
        {
            dialougetext.text = dialouge[diaindex];
            continuebox.SetActive(true);
            RightButton.SetActive(false);
            LeftButton.SetActive(false);

        }

        //right Button corresponds to female score
        ScoringScript.Instance.AddToFemaleScore();

        //button1counter++;

        //if (Female == PlayerPrefs.GetString("Player Gender", "Female"))
        //{
        //    FemaleAnimations[0].SetActive(true);
        //}



    }
    void LeftButtonClicked()
    {
        //Debug.Log("button2 was clicked!" + button2counter);

        if (dialougetext.text == scenedialouge[index])
        {
            dialougetext.text = dialouge2[diaindex];
            continuebox.SetActive(true);
            LeftButton.SetActive(false);
            RightButton.SetActive(false);


        }

        ScoringScript.Instance.AddToMaleScore();
       
        //button2counter++;
        //if (Male == PlayerPrefs.GetString("Player Gender", "Male"))
        //{
        //    MaleAnimations[0].SetActive(true);
        //}


    }
    void NextScene()
    {

        index++;
        on++;
        off = on - 1;
        //off--;
        dialougetext.text = scenedialouge[index];

        butindex1++;
        butindex2++;
        diaindex++;
        Debug.Log("Continue = " + index);

        continuebox.SetActive(false);
        RightButton.SetActive(false);
        LeftButton.SetActive(false);
        dialougebox.SetActive(false);
        background[on].SetActive(true);

        background[off].SetActive(false);
        if(audioS.clip == office)
        {
            StartCoroutine(Waitforaudio2());
        }
        //if(audioS.clip == sounds[1])
        //{
        //    StartCoroutine(Waitforaudio2());
        //}
        if (audioS.clip == coffee)
        {
            StartCoroutine(Waitforaudio3());
        }
        if(audioS.clip == mud)
        {
            StartCoroutine(Waitforaudio2());
        }


    }
    void Continuebut()
    {
        Debug.Log("turrning on buttons");
        sound++;
        contbutton.SetActive(false);
        RightButton.SetActive(true);
        LeftButton.SetActive(true);
        dialougebox.SetActive(true);

        if (dialougetext.text == scenedialouge[0])
        {
            //diaAudio.clip = diaS[0];
            //diaAudio.Play();
            Debug.Log("Audio is Working");
            
        }
        if (dialougetext.text == scenedialouge[1])
        {
            diaAudio.clip = diaS[1];
            diaAudio.Play();

        }
        if (dialougetext.text == scenedialouge[2])
        {
            diaAudio.clip = diaS[2];
            diaAudio.Play();

        }

        //if(background[1]&&isoffice == true)
        //{
        //    MaleAnimations[1].SetActive(true);
        //    FemaleAnimations[1].SetActive(true);
        //}
        //else
        //{
        //    MaleAnimations[1].SetActive(false);
        //    FemaleAnimations[1].SetActive(false);
        //}


    }

    public void OnCreditsButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("endingScene");
    }
}
