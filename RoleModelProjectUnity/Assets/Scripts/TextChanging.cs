using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanging : MonoBehaviour {

    public string[] textPrompts;

    public Text textBox;

    public float timeToChangeText;

    public bool useTextTimer;

    public ReceiveEmotiv receiveEmotiv;
    
    private int currentTextIndex;
    private float textTimer;

    void OnEnable() {

        receiveEmotiv.OnChangeState += ChangeText;

    }
    
    // Start is called before the first frame update
    void Start() {
        
        //initialize the text with nothing
        textBox.text = " ";
        
        textTimer = 0f;
        currentTextIndex = 0;
    }

    // Update is called once per frame
    void Update() {

        if (textTimer > timeToChangeText) {
            ChangeText();
            textTimer = 0f;
        }
        
        textTimer += Time.deltaTime;

    }

    public void ChangeText() {

        StartCoroutine(ChangingText());
    }

    public IEnumerator ChangingText() {
        textBox.color = new Color(1f, 1f, 1f, 0f);
        
        int newIndex = Random.Range(0, textPrompts.Length);

        if (newIndex == currentTextIndex) {
            newIndex = (currentTextIndex + 1) % textPrompts.Length;
        }
        
        textBox.text = textPrompts[newIndex];
        currentTextIndex = newIndex;

        yield return new WaitForSeconds(2f);

        float timer = 0f;

        while (timer < 1f) {
            textBox.color = new Color(1f, 1f, 1f, timer);
            timer += Time.deltaTime;
            yield return null;
        }
        
        yield return new WaitForSeconds(2f);
        
        while (timer > 0f) {
            textBox.color = new Color(1f, 1f, 1f, timer);
            timer -= Time.deltaTime;
            yield return null;
        }


    }
    
}
