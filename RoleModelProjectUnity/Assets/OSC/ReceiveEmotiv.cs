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
	[SerializeField] float attentionVal = 0f, stressVal = 0f, relaxVal = 0f, meditationVal = 0f;

	//the dummy slider is for testing when we don't have the brainbit connected
	[Range(0f,100f)]public float dummySlider;
	public bool useDummySlider;

	public enum EmotionalState {attention = 0, stress = 1, relax = 2, meditation = 3, neutralState = 4, numEntries}

	public EmotionalState currentState;

	public float[] stateValues;

	public delegate void ChangeState();
	public event ChangeState OnChangeState;

	public RevisedAudioPicker audioPicker;

	//time until we repeat the same dialogue
	public float sameStateRepeatTime = 30f;
	public float sameStateTimer = 0f;

	// Use this for initialization
	void Start () {

		//osc addresses:
		//currently there are 4 locations (T3, T4, 01, 02),
		//each with /alpha, /beta, /gamma, and /theta frequencies
		//this demo scene maps 3 of the beta values to color, and the 4th to a scale value
		osc.SetAddressHandler("/Attention", AttentionToStoredFloat);
		osc.SetAddressHandler("/Stress", StressToStoredFloat);
		osc.SetAddressHandler("/Relax", RelaxToStoredFloat);
		osc.SetAddressHandler("/Meditation", MeditationToStoredFloat);

		stateValues = new float[(int)EmotionalState.numEntries];

		currentState = (EmotionalState)4;
	}

	// Update is called once per frame
	void Update () {
		if (useDummySlider) {
			inputVal.inputBCIValue = dummySlider;
		}
		else {
			UpdateEmotionalState();
		}
	}

	//Maps T3 beta values to the Red color channel
	void AttentionToStoredFloat(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		Mathf.Clamp(inputFloat, minimumBetaValue, maximumBetaValue);

		attentionVal = inputFloat;

	}

	//Maps T4 beta values to the Green color channel
	void StressToStoredFloat(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		inputFloat = Mathf.Clamp(inputFloat, minimumBetaValue, maximumBetaValue);

		stressVal = inputFloat;
	}

	//Maps 01 beta values to the Blue color channel
	void RelaxToStoredFloat(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		inputFloat = Mathf.Clamp(inputFloat, minimumBetaValue, maximumBetaValue);
		relaxVal = inputFloat;

	}

	//Map 02 beta values to scale the object
	void MeditationToStoredFloat(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		inputFloat = Mathf.Clamp(inputFloat, minimumBetaValue, maximumBetaValue);
		meditationVal = inputFloat;
	}


	public float AverageInputValues(float value1, float value2, float value3, float value4) {
		return (value1 + value2 + value3 + value4) / 4f;
	}

	public void UpdateEmotionalState() {
		stateValues[(int)EmotionalState.attention] = attentionVal;
		stateValues[(int)EmotionalState.stress] = stressVal;
		stateValues[(int)EmotionalState.relax] = relaxVal;
		stateValues[(int)EmotionalState.meditation] = meditationVal;
		stateValues[(int)EmotionalState.neutralState] = 0f;


		EmotionalState previousState = currentState;

		for (int i = 0; i < (int)EmotionalState.numEntries; i++) {
			if (stateValues[i] > stateValues[(int)currentState])
			{
				currentState = (EmotionalState)i;
			}
		}

		if (previousState != currentState && !audioPicker.isPlayingVO)
		{

			//This sends out an event that can let other scripts know that the emotional state
			//has been changed
			EmotionalStateChanged();

			switch (currentState) {
				case EmotionalState.attention:
					audioPicker.PlayAttentionClips();
					break;
				case EmotionalState.stress:
					audioPicker.PlayStressClips();
					break;
				case EmotionalState.relax:
					audioPicker.PlayRelaxClips();
					break;
				case EmotionalState.meditation:
					audioPicker.PlayMeditationClips();
					break;
				default:
					break;
			}
		} else {
			// check to see if we've passed the time limit, then repeat the audio clips

			sameStateTimer += Time.deltaTime;
			if (sameStateTimer >= sameStateRepeatTime && !audioPicker.isPlayingVO)
			{
				RepeatAudioClips();
			}
		}

	}

	public void EmotionalStateChanged() {
		if (OnChangeState != null) OnChangeState();
	}

	public void RepeatAudioClips() {

		audioPicker.ResetPlayedList();

		switch (currentState) {
			case EmotionalState.attention:
				audioPicker.PlayAttentionClips();
				break;
			case EmotionalState.stress:
				audioPicker.PlayStressClips();
				break;
			case EmotionalState.relax:
				audioPicker.PlayRelaxClips();
				break;
			case EmotionalState.meditation:
				audioPicker.PlayMeditationClips();
				break;
			default:
				break;
		}

		sameStateTimer = 0f;

	}
}
