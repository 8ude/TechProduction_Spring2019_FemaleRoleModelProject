using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScript : MonoBehaviour {

    private float randomNumber;
    private float timer = 0;
	// Use this for initialization
	void Start () {
        randomNumber = Mathf.Round(Random.Range(1.0f, 100.0f));
    }
	
	// Update is called once per frame
	void Update () {
        timer++;
        if (timer % 20 == 0)
        {
            randomNumber = Mathf.Round(Random.Range(randomNumber * .8f, randomNumber * 1.1f));
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            randomNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            randomNumber--;
        }

        Debug.Log(randomNumber);
	}
}
