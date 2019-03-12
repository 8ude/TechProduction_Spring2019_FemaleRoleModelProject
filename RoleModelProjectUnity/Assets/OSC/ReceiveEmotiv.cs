using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveEmotiv : MonoBehaviour {

	//Currently this script is configured to 
	public OSC osc;

	public InputVal inputVal;

	//we need to find a good range of values to work with
	//in the final version, the manufacturers will help us with 
	//our data stream
	public float minimumBetaValue = 0f;
	public float maximumBetaValue = 500f;

	//these are public just so that we can see them, but should not be set in the inspector
	[SerializeField] float o1Val = 0f, o2Val = 0f, t3Val = 0f, t4Val = 0f;
	
	//the dummy slider is for testing when we don't have the brainbit connected
	[Range(0f,100f)]public float dummySlider;
	public bool useDummySlider;


	// Use this for initialization
	void Start () {

		//osc addresses:
		//currently there are 4 locations (T3, T4, 01, 02),
		//each with /alpha, /beta, /gamma, and /theta frequencies 
		//this demo scene maps 3 of the beta values to color, and the 4th to a scale value
		osc.SetAddressHandler("/T3/beta", TThreeToStoredFloat);
		osc.SetAddressHandler("/T4/beta", TFourToStoredFloat);
		osc.SetAddressHandler("/O1/beta", OOneToStoredFloat);
		osc.SetAddressHandler("/02/beta", OTwoToStoredFloat);
	}
	
	// Update is called once per frame
	void Update () {
		if (useDummySlider) {
			inputVal.inputBCIValue = dummySlider;
		}
		else {
			inputVal.inputBCIValue = AverageInputValues(o1Val, o2Val, t3Val, t4Val);
		}
	}

	//Maps T3 beta values to the Red color channel
	void TThreeToStoredFloat(OscMessage message) {
		float inputFloat = message.GetFloat(0);
		
		Mathf.Clamp(inputFloat, minimumBetaValue, maximumBetaValue);

		t3Val = inputFloat;

	}
	
	//Maps T4 beta values to the Green color channel
	void TFourToStoredFloat(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		inputFloat = Mathf.Clamp(inputFloat, minimumBetaValue, maximumBetaValue);

		t4Val = inputFloat;
	}
	
	//Maps 01 beta values to the Blue color channel
	void OOneToStoredFloat(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		inputFloat = Mathf.Clamp(inputFloat, minimumBetaValue, maximumBetaValue);
		o1Val = inputFloat;

	}
	
	//Map 02 beta values to scale the object
	void OTwoToStoredFloat(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		inputFloat = Mathf.Clamp(inputFloat, minimumBetaValue, maximumBetaValue);
		o2Val = inputFloat;


	}


	public float AverageInputValues(float value1, float value2, float value3, float value4) {
		return (value1 + value2 + value3 + value4) / 4f;
	}
}
