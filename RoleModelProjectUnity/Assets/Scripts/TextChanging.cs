using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanging : MonoBehaviour {

    public string[] textPrompts;

    public Text textBox;

    public float timeToChangeText;

    private int currentTextIndex;
    private float textTimer;
    
    // Start is called before the first frame update
    void Start() {
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

        int newIndex = Random.Range(0, textPrompts.Length);

        if (newIndex == currentTextIndex) {
            newIndex = (currentTextIndex + 1) % textPrompts.Length;
        }
        
        textBox.text = textPrompts[newIndex];
        currentTextIndex = newIndex;
    }
    
}
