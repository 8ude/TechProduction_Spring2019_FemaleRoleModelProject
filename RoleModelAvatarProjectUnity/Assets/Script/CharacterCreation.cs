using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour
{
    // Start is called before the first frame update

    public Button leftbut;
    public Button rightbut;
    public Button continuebut;

    public GameObject L_but;
    public GameObject R_but;
    public GameObject conBut;

    public Text LButtonText;
    public Text RButtonText;

    public string[] leftbutText;
    public GameObject[] leftbutObjects;
    public string[] rightbutText;
    public GameObject[] rightbutObjects;

    private string[] choice;

    int button1counter = 0;
    int button2counter = 0;
    int index = 0;
    void Start()
    {
        leftbut.onClick.AddListener(LeftButClick);
        rightbut.onClick.AddListener(RightButClick);
        continuebut.onClick.AddListener(NextScene);
        conBut.SetActive(false);

        //Turns button text into first array index
        LButtonText.text = leftbutText[0];
        RButtonText.text = rightbutText[0];

    }

    // Update is called once per frame
    void Update()
    {
        //int l;
        //for(l = 0; l > leftbutText.Length; l++)
        //{

        //}
        //int r;
        //for (r = 0; r > rightbutText.Length; l++)
        //{

        //}
        //Turns button text into array text
        LButtonText.text = leftbutText[index];
        RButtonText.text = rightbutText[index];

        //Debug.Log(leftbutText[button1counter]);
        //Debug.Log(rightbutText[button2counter]);
    }

    void LeftButClick()
    {
        if(index == 0)
        {
            Debug.Log("User Chose Male");
            PlayerPrefs.SetString("PlayerGender", "Male");
        }
        leftbutObjects[index].SetActive(true);
        L_but.SetActive(false);
        R_but.SetActive(false);
        conBut.SetActive(true);
        button1counter++;
    }
    void RightButClick()
    {
        if(index == 0)
        {
            Debug.Log("User Chbose Female");
            PlayerPrefs.SetString("PlayerGender", "Female");
        }
        rightbutObjects[index].SetActive(true);
        L_but.SetActive(false);
        R_but.SetActive(false);
        conBut.SetActive(true);
        button2counter++;
    }
    void NextScene()
    {

        index++;
        conBut.SetActive(false);
        L_but.SetActive(true);
        R_but.SetActive(true);
        if (index == leftbutText.Length)
        {
            SceneManager.LoadScene("OfficeScene");
            L_but.SetActive(false);
            R_but.SetActive(false);
            conBut.SetActive(false);
        }
    }

    
}
