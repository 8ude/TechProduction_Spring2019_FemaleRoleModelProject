using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour {

    public Text NPCnt;
    public Text textshow;

    private Queue<string> newtext;
	
	// Update is called once per frame
	void Update () {
        newtext = new Queue<string>();  
	}
    public void Starttext(text playtext)
    {

        NPCnt.text = playtext.NPCn;

        newtext.Clear();

        foreach(string texts in playtext.texts)
        {
            newtext.Enqueue(texts); 
        }

        DisplayNewText();
    }
    public void DisplayNewText()
    {
        if(newtext.Count == 0)
        {
            Endtext();
            return;
        }
        string texts = newtext.Dequeue();
        textshow.text = texts;
    }
    void Endtext()
    {
        Debug.Log("End");
    }
}

