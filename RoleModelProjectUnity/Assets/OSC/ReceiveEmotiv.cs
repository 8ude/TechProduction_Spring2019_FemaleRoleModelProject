using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveEmotiv : MonoBehaviour {

	//Currently this script is configured to 
	public OSC osc;

	//note - if this is left blank, there will be a null ref exception!
	//any renderer is fine, doesn't have to be a sphere
	public Renderer sphereRenderer;

	//using this for test visualization
	private Material sphereMat;

	public float smoothingValue;

	public float minimumBetaValue = 0f;
	public float maximumBetaValue = 500f;


	// Use this for initialization
	void Start () {
		sphereMat = sphereRenderer.material;
		
		//osc addresses:
		//currently there are 4 locations (T3, T4, 01, 02),
		//each with /alpha, /beta, /gamma, and /theta frequencies 
		//this demo scene maps 3 of the beta values to color, and the 4th to a scale value
		osc.SetAddressHandler("/T3/beta", TThreeToRed);
		osc.SetAddressHandler("/T4/beta", TFourToGreen);
		osc.SetAddressHandler("/O1/beta", OOneToBlue);
		osc.SetAddressHandler("/02/beta", OTwoToScale);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Maps T3 beta values to the Red color channel
	void TThreeToRed(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		Mathf.Clamp(inputFloat, minimumBetaValue, maximumBetaValue);
		Debug.Log("TThreeValue: " + inputFloat);

		Color cachedColor = sphereMat.color;

		cachedColor.r = Remap(inputFloat, minimumBetaValue, maximumBetaValue, 0f, 1f);

		Color newColor = Color.Lerp(sphereMat.color, cachedColor, smoothingValue);
		
		sphereMat.SetColor("_Color", newColor);
	}
	
	//Maps T4 beta values to the Green color channel
	void TFourToGreen(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		inputFloat = Mathf.Clamp(inputFloat, minimumBetaValue, maximumBetaValue);
		Debug.Log("TFourValue: " + inputFloat);

		Color cachedColor = sphereMat.color;

		cachedColor.g = Remap(inputFloat, minimumBetaValue, maximumBetaValue, 0f, 1f);

		Color newColor = Color.Lerp(sphereMat.color, cachedColor, smoothingValue);
		
		sphereMat.SetColor("_Color", newColor);
	}
	
	//Maps 01 beta values to the Blue color channel
	void OOneToBlue(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		inputFloat = Mathf.Clamp(inputFloat, minimumBetaValue, maximumBetaValue);
		Debug.Log("OOneValue: " + inputFloat);

		Color cachedColor = sphereMat.color;

		cachedColor.b = Remap(inputFloat, minimumBetaValue, maximumBetaValue, 0f, 1f);

		Color newColor = Color.Lerp(sphereMat.color, cachedColor, smoothingValue);
		
		sphereMat.SetColor("_Color", newColor);
	}
	
	//Map 02 beta values to scale the object
	void OTwoToScale(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		inputFloat = Mathf.Clamp(inputFloat, minimumBetaValue, maximumBetaValue);
		Debug.Log("OTwoValue: " + inputFloat);

		float newScaleValue = Remap(inputFloat, minimumBetaValue, maximumBetaValue, 0.3f, 5f);

		sphereRenderer.gameObject.transform.localScale *= Mathf.Lerp(1.0f, newScaleValue, smoothingValue); 
	
	}

	//helper method to linearly remap a number
	//from one number range (fromMin, fromMax) to another (toMin, toMax).
	public static float Remap (float from, float fromMin, float fromMax, float toMin,  float toMax)
	{
		var fromAbs  =  from - fromMin;
		var fromMaxAbs = fromMax - fromMin;      
       
		var normal = fromAbs / fromMaxAbs;
 
		var toMaxAbs = toMax - toMin;
		var toAbs = toMaxAbs * normal;
 
		var to = toAbs + toMin;
       
		return to;
	}
}
