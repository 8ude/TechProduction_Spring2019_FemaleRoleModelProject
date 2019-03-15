using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bottextmanager : MonoBehaviour {
    public Text bottomNN;
    public Text bottomNN2;
    public Text bottomshow;
    private Queue<string> bottext;
	// Update is called once per frame
	void Update () {
        bottext = new Queue<string>();
	}
    public void Startbottext(bot worktext)
    {
        bottomNN.text = worktext.bottomN;
        bottomNN2.text = worktext.bottomN2;
        bottext.Clear();

        foreach(string bots in worktext.bots)
        {
            bottext.Enqueue(bots);
        }
        Displaybottext();
    }
    public void Displaybottext()
    {
        if (bottext.Count == 0)
        {
            Endbot();
            return;
        }
        string bots = bottext.Dequeue();
        bottomshow.text = bots;
    }
    void Endbot()
    {
        Debug.Log("End");
    }
}
